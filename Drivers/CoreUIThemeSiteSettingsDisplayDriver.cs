using CoreUIAdmin.Models;
using CoreUIAdmin.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Entities.DisplayManagement;
using OrchardCore.Settings;
using System.Threading.Tasks;

namespace CoreUIAdmin.Drivers
{
    public class CoreUIThemeSiteSettingsDisplayDriver : SectionDisplayDriver<ISite, CoreUISettings>
    {
        public const string GroupId = "coreUI";

        public override IDisplayResult Edit(CoreUISettings settings, BuildEditorContext context)
        {
            return Shape<CoreUISettingsViewModel>("CoreUISettings_Edit", model =>
            {
                model.FixedActionButtons = settings.FixedActionButtons;
            }).Location("Content:3").OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(CoreUISettings settings, IUpdateModel updater, string groupId)
        {
            if (groupId == GroupId)
            {
                var model = new CoreUISettingsViewModel();

                await updater.TryUpdateModelAsync(model, Prefix);

                settings.FixedActionButtons = model.FixedActionButtons;
            }

            return Edit(settings);
        }
    }
}
