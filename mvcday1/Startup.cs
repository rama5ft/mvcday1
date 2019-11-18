using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using mvcday1.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcday1.Startup))]
namespace mvcday1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoles();
        }

       
        public async void CreateRoles()
        {
            var rolestore=new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(rolestore);
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("LoanManager"));
            await roleManager.CreateAsync(new IdentityRole("Teller"));
            await roleManager.CreateAsync(new IdentityRole("clerk"));
            

        }
    }
}
