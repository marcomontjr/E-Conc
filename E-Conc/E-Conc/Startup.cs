using E_Conc.Data;
using E_Conc.Data.Interfaces;
using E_Conc.Data.Repository;
using E_Conc.Models;
using E_Conc.Services;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration
                .GetConnectionString("DefaultConnection");

            services
               .AddDbContext<Contexto>(options => options
               .UseSqlServer(connectionString));

            services.AddIdentity<Usuario, IdentityRole>()
               .AddEntityFrameworkStores<Contexto>()
               .AddDefaultTokenProviders();

            services.AddSingleton<IEmailService, EmailService>();    

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IItemPedidoRespository, ItemPedidoRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider)
        {
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