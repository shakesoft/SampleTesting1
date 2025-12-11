using Volo.Abp.Settings;

namespace SampleTesting1.Settings;

public class SampleTesting1SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SampleTesting1Settings.MySetting1));
    }
}
