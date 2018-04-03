using E_Conc.Data;
using E_Conc.Data.Interfaces;
using E_Conc.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IAlunoRepository, AlunoRespository>();
            services.AddTransient<IItemPedidoRespository, ItemPedidoRepository>();
            services.AddTransient<IOrientadorRepository, OrientadorRepository>();
            services.AddTransient<ICursoRepository, CursoRepository>();
            services.AddMvc();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}