using System.Runtime.CompilerServices;
using LobbyCompatibility.Enums;
using LobbyCompatibility.Features;

namespace SoftMaskKiller.src.Dependency;
public static class LobbyCompatibilityChecker
{
    private static bool? _enabled;

    public static bool Enabled
    {
        get
        {
            _enabled ??= BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("BMX.LobbyCompatibility");
            return _enabled.Value;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void Init()
    {
        PluginHelper.RegisterPlugin(SoftMaskKiller.GUID, System.Version.Parse(SoftMaskKiller.VERSION), CompatibilityLevel.Everyone, VersionStrictness.Minor);
    }
}