﻿using System.CommandLine;
using System.CommandLine.Binding;

namespace CubicBot.Telegram.CLI;

internal class ConfigSetBinder : BinderBase<ConfigChangeSet>
{
    private readonly Option<string?> _botTokenOption;
    private readonly Option<bool?> _enableCommandsModuleOption;
    private readonly Option<bool?> _enableStatsModuleOption;
    private readonly Option<bool?> _enablePersonalCommandsOption;
    private readonly Option<bool?> _enableCommonCommandsOption;
    private readonly Option<bool?> _enableDiceCommandsOption;
    private readonly Option<bool?> _enableConsentNotNeededCommandsOption;
    private readonly Option<bool?> _enableNonVeganCommandsOption;
    private readonly Option<bool?> _enableLawEnforcementCommandsOption;
    private readonly Option<bool?> _enablePublicServicesCommandsOption;
    private readonly Option<bool?> _enableChineseCommandsOption;
    private readonly Option<bool?> _enableChineseTasksCommandsOption;
    private readonly Option<bool?> _enableSystemdCommandsOption;
    private readonly Option<bool?> _enableGrassStatsOption;
    private readonly Option<bool?> _enableCommandStatsOption;
    private readonly Option<bool?> _enableMessageCounterOption;

    public ConfigSetBinder(
        Option<string?> botTokenOption,
        Option<bool?> enableCommandsModuleOption,
        Option<bool?> enableStatsModuleOption,
        Option<bool?> enablePersonalCommandsOption,
        Option<bool?> enableCommonCommandsOption,
        Option<bool?> enableDiceCommandsOption,
        Option<bool?> enableConsentNotNeededCommandsOption,
        Option<bool?> enableNonVeganCommandsOption,
        Option<bool?> enableLawEnforcementCommandsOption,
        Option<bool?> enablePublicServicesCommandsOption,
        Option<bool?> enableChineseCommandsOption,
        Option<bool?> enableChineseTasksCommandsOption,
        Option<bool?> enableSystemdCommandsOption,
        Option<bool?> enableGrassStatsOption,
        Option<bool?> enableCommandStatsOption,
        Option<bool?> enableMessageCounterOption)
    {
        _botTokenOption = botTokenOption;
        _enableCommandsModuleOption = enableCommandsModuleOption;
        _enableStatsModuleOption = enableStatsModuleOption;
        _enablePersonalCommandsOption = enablePersonalCommandsOption;
        _enableCommonCommandsOption = enableCommonCommandsOption;
        _enableDiceCommandsOption = enableDiceCommandsOption;
        _enableConsentNotNeededCommandsOption = enableConsentNotNeededCommandsOption;
        _enableNonVeganCommandsOption = enableNonVeganCommandsOption;
        _enableLawEnforcementCommandsOption = enableLawEnforcementCommandsOption;
        _enablePublicServicesCommandsOption = enablePublicServicesCommandsOption;
        _enableChineseCommandsOption = enableChineseCommandsOption;
        _enableChineseTasksCommandsOption = enableChineseTasksCommandsOption;
        _enableSystemdCommandsOption = enableSystemdCommandsOption;
        _enableGrassStatsOption = enableGrassStatsOption;
        _enableCommandStatsOption = enableCommandStatsOption;
        _enableMessageCounterOption = enableMessageCounterOption;
    }

    protected override ConfigChangeSet GetBoundValue(BindingContext bindingContext) => new(
        bindingContext.ParseResult.GetValueForOption(_botTokenOption),
        bindingContext.ParseResult.GetValueForOption(_enableCommandsModuleOption),
        bindingContext.ParseResult.GetValueForOption(_enableStatsModuleOption),
        bindingContext.ParseResult.GetValueForOption(_enablePersonalCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableCommonCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableDiceCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableConsentNotNeededCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableNonVeganCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableLawEnforcementCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enablePublicServicesCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableChineseCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableChineseTasksCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableSystemdCommandsOption),
        bindingContext.ParseResult.GetValueForOption(_enableGrassStatsOption),
        bindingContext.ParseResult.GetValueForOption(_enableCommandStatsOption),
        bindingContext.ParseResult.GetValueForOption(_enableMessageCounterOption));
}
