using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace hh.Utilits
{
    public class AdminInitializer
    {
        public static async Task SeedAdminUser( RoleManager<IdentityRole> _roleManager, UserManager<Models.User> userManager)
        {
            var roles = new[] { "user", "company" };
            foreach (var role in roles)
            {
                if (await _roleManager.FindByNameAsync(role) is null)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }
    }
}
