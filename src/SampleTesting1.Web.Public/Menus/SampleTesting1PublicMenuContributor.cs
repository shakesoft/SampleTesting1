using System;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.Configuration;
using SampleTesting1.Localization;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace SampleTesting1.Web.Public.Menus;

public class SampleTesting1PublicMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public SampleTesting1PublicMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<SampleTesting1Resource>();

        //Home
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SampleTesting1PublicMenus.HomePage,
                l["Menu:Home"],
                "~/",
                icon: "fa fa-home",
                order: 1
            )
        );

        // BlogSample
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SampleTesting1PublicMenus.Blog,
                l["Menu:Blog"],
                "~/blog",
                icon: "fa fa-file-signature",
                order: 2
                )
        );
        
        // Faq
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SampleTesting1PublicMenus.Faq,
                l["Menu:Faq"],
                "~/faq",
                icon: "fa fa-question-circle",
                order: 3
            )
        );

        // Contact Us
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SampleTesting1PublicMenus.ContactUs,
                l["Menu:ContactUs"],
                "~/contact-us",
                icon: "fa fa-phone",
                order: 4
                )
        );

        // PDF Documents
        context.Menu.AddItem(
            new ApplicationMenuItem(
                SampleTesting1PublicMenus.PdfDocuments,
                l["Menu:PdfDocuments"],
                "~/PdfDocuments",
                icon: "fa fa-file-pdf-o",
                order: 5
                )
        );

        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var uiResource = context.GetLocalizer<AbpUiResource>();
        var accountResource = context.GetLocalizer<AccountResource>();

        var authServerUrl = _configuration["AuthServer:Authority"] ?? "~";

        context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{authServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000,  target: "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{authServerUrl.EnsureEndsWith('/')}Account/SecurityLogs", icon: "fa fa-user-shield", target: "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.Sessions", accountResource["Sessions"], url: $"{authServerUrl.EnsureEndsWith('/')}Account/Sessions", icon: "fa fa-clock", target: "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", uiResource["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
