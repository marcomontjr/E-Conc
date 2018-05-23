using System;
using System.Threading.Tasks;
using E_Conc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Conc.Roles
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Usuario>>();
            string[] roleNames = { "Admin", "Orientador", "Aluno" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)                
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));                
            }

            var admin = new Usuario
            {
                UserName = Configuration.GetSection("UserSettings")["UserEmail"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]                 
            };

            string adminPassword = Configuration.GetSection("UserSettings")["UserPassword"];

            if (admin != null)
            {
                var createAdmin = await UserManager.CreateAsync(admin, adminPassword);
                if (createAdmin.Succeeded)                                    
                    await UserManager.AddToRoleAsync(admin, "Admin");                
            }
        }
    }
}
