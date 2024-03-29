﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core;
using ECommerce.Core.Abstractions;
using ECommerce.DataAccess;
using ECommerce.DataAccess.Abstraction;
using ECommerce.DataAccess.Implementation;
using ECommerce.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ECommerce.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors ();
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            //Register Context
            services.AddDbContext<EShopContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("EShopContext"), b => b.MigrationsAssembly ("ECommerce.API")));

            //Register Repositories
            services.AddScoped<IRepository<Product>, ProductsRepository> ();
            services.AddScoped<IRepository<User>, UsersRepository> ();
            services.AddScoped<IRepository<Cart>, CartsRepository> ();

            //Register Services
            services.AddScoped<IProductsService, ProductsService> ();
            services.AddScoped<IUsersService, UsersService> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseCors (builder =>
                builder.WithOrigins ("http://localhost:4200"));
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}