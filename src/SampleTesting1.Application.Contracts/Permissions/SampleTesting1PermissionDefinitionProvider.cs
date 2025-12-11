using SampleTesting1.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SampleTesting1.Permissions;

public class SampleTesting1PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SampleTesting1Permissions.GroupName);

        myGroup.AddPermission(SampleTesting1Permissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(SampleTesting1Permissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        // PDF Documents
        var pdfDocumentsPermission = myGroup.AddPermission(SampleTesting1Permissions.PdfDocuments.Default, L("Permission:PdfDocuments"));
        pdfDocumentsPermission.AddChild(SampleTesting1Permissions.PdfDocuments.Create, L("Permission:PdfDocuments.Create"));
        pdfDocumentsPermission.AddChild(SampleTesting1Permissions.PdfDocuments.Edit, L("Permission:PdfDocuments.Edit"));
        pdfDocumentsPermission.AddChild(SampleTesting1Permissions.PdfDocuments.Delete, L("Permission:PdfDocuments.Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(SampleTesting1Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SampleTesting1Resource>(name);
    }
}
