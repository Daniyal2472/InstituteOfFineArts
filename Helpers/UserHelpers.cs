using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstituteOfFineArts.Data;

public static class UserHelpers
{
    public static async Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var usersInRole = new List<ApplicationUser>();
        var role = await roleManager.FindByNameAsync(roleName);
        if (role != null)
        {
            var users = userManager.Users.ToList();
            foreach (var user in users)
            {
                if (await userManager.IsInRoleAsync(user, roleName))
                {
                    usersInRole.Add(user);
                }
            }
        }
        return usersInRole;
    }
}
