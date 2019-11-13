using AskMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Helper
{
    public class SeedingHelper
    {
        UserManager<User> userManager;
        RoleManager<IdentityRole> roleManager;
        ApplicationDbContext context;
        public SeedingHelper(ApplicationDbContext context)
        {
            this.context = context;
            userManager = new UserManager<User>(new UserStore<User>(context));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public void CreateUser(string name)
        {
            string userName = name + "@AskMe.com";
            string password = name + "A123";

            var userInDb = userManager.FindByName(userName);
            if (userInDb != null) return;
            var PasswordHash = new PasswordHasher();
            var user = new User()
            {
                UserName = userName,
                Email = userName,
                PasswordHash = PasswordHash.HashPassword(password),
            };
            userManager.Create(user);
        }
    

    }
}