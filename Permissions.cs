using System.Collections.Generic;
using OrchardCore.Security.Permissions;

namespace CoreUIAdmin
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageCoreUITheme = new Permission("ManageCoreUITheme", "Manage CoreUI Theme");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageCoreUITheme };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageCoreUITheme }
                }
            };
        }
    }
}
