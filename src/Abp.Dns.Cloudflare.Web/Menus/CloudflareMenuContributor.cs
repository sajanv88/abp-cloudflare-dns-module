using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Abp.Dns.Cloudflare.Web.Menus;

public class CloudflareMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(CloudflareMenus.Prefix, displayName: "Cloudflare", "~/Cloudflare", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
