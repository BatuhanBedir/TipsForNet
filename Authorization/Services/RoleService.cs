using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Authorization.Services
{
    public sealed class RoleService : IRoleService
    {
        public bool UserHasRole(string userId, string role)
        {
            AppDbContext context = new ();
            var userHasRole = context.UserRoles.Where(x => x.UserId == Convert.ToInt32(userId)).Include(x => x.Role).Any(x => x.Role.Name == role);
            return userHasRole;
        }
    }
}
