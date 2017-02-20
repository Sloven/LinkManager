using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebAPI.Models;
using Entities;
using DataAccess;
using DataAccess.Abstractions;
using DataAccess.Contexts;

namespace WebAPI
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<EFDBContext>()));
            var userStore = new UserStore<ApplicationUser>(defineDBContext(context));
            var manager = new ApplicationUserManager(userStore);
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        /// <summary>
        /// This should be refactored for more robust and secure approach
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static IdentityDbContext<ApplicationUser> defineDBContext(IOwinContext context)
        {
            if(context?.Request?.Headers["isdemo"] != null)
                return context.Get<DemoOWINDBContext>();
            else
                return context.Get<OWINDBContext>();
        }
    }
}
