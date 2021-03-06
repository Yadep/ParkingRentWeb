﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingRentWeb.Data;
using ParkingRentWeb.Models;
using ParkingRentWeb.Services;


namespace ParkingRentWeb
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDbContext<ParkingRentDbContext>(options =>
				
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication().AddFacebook(facebookOptions =>
			{
				facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
				facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
			}).AddGoogle(googleOptions =>
			{
				googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
				googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
			});
			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();

			services.AddMvc();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
			var parkingRentContext = service.CreateScope().ServiceProvider.GetService<ParkingRentDbContext>();
			CreateUserRoles(service).Wait();
			SeedDb(parkingRentContext).Wait();
		}

		/// <summary>
		/// Vérifie et créer les differents rôles si besoin : Directeur de mission, Admin, Adhérent
		/// Ainsi que des utilisateur de tests
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns></returns>
		public static async Task CreateUserRoles(IServiceProvider serviceProvider)
		{
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


			IdentityResult roleResult;
			//Ajoute le role Admin
			var role = await RoleManager.RoleExistsAsync("Utilisateur");
			if (!role)
			{
				//Créer le role et l'ajoute a la BDD   
				roleResult = await RoleManager.CreateAsync(new IdentityRole("Utilisateur"));
			}

		}

		public static async Task SeedDb(ParkingRentDbContext parkingRentDbContext)
		{
			if(!parkingRentDbContext.TypeParking.Any())
			{
				var typeParking = new List<TypeParking>
				{
					new TypeParking {Id = 1 , Libelle = "Box"},
					new TypeParking {Id = 2,  Libelle = "Garage"},
					new TypeParking {Id = 3,  Libelle = "Place de parking"},
				};
				parkingRentDbContext.AddRange(typeParking);
				parkingRentDbContext.SaveChanges();
			}
			if(!parkingRentDbContext.TypeUser.Any())
			{
				var typeUser = new List<TypeUser>
				{
					new TypeUser {Id = 1,  Libelle = "Particulier"},
					new TypeUser {Id = 2,  Libelle = "Professionnel"}
				};
				parkingRentDbContext.AddRange(typeUser);
				parkingRentDbContext.SaveChanges();
			}
			if (!parkingRentDbContext.TypeUser.Any())
			{
				var typeVehicule = new List<TypeVehicule>
				{
					new TypeVehicule {Id = 1, Libelle = "Camion"},
					new TypeVehicule {Id = 2, Libelle = "Voiture"},
					new TypeVehicule {Id = 3, Libelle = "Voiture sans permis"}
				};
				parkingRentDbContext.AddRange(typeVehicule);
				parkingRentDbContext.SaveChanges();
			}
		}
	}
}
