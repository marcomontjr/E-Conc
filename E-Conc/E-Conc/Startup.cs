﻿using E_Conc.Data;
using E_Conc.Data.Interfaces;
using E_Conc.Data.Repository;
using E_Conc.Models;
using E_Conc.Services;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace E_Conc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }   
        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration
                .GetConnectionString("DefaultConnection");

            services
               .AddDbContext<Contexto>(options => options
               .UseSqlServer(connectionString));

            services.AddIdentity<Usuario, IdentityRole>(options => 
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;                
            })
            .AddEntityFrameworkStores<Contexto>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<PhoneNumberTokenProvider<Usuario>>("SMS");
            
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ContinuarLogado";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = "/Conta/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;                
                options.SlidingExpiration = true;                
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
                options.ValidationInterval = TimeSpan.FromSeconds(0)
            );            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISmsService, SmsService>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<SmsSettings>(Configuration.GetSection("SmsSettings"));
       
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoLogRepository, ProdutoLogRepository>();
            services.AddTransient<IItemPedidoRespository, ItemPedidoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<Contexto>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}