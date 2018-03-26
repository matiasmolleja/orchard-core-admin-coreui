using CoreUIAdmin.Drivers;
using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Navigation;
using System;

namespace CoreUIAdmin
{
    public class AdminMenu : INavigationProvider
    {
        public AdminMenu(IStringLocalizer<AdminMenu> localizer)
        {
            T = localizer;
        }

        public IStringLocalizer T { get; set; }

        public void BuildNavigation(string name, NavigationBuilder builder)
        {
            if (!String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            builder
                .Add(T["Configuration"], configuration => configuration
                    .Add(T["Settings"], settings => settings
                        .Add(T["CoreUI Theme"], T["CoreUI Theme"], layers => layers
                            .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = CoreUIThemeSiteSettingsDisplayDriver.GroupId })
                            .LocalNav()
                        )));
        }
    }
}
