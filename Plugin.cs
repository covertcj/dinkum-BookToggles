using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BookToggles.Patches;
using HarmonyLib;

namespace BookToggles
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static new ManualLogSource Logger;

        private readonly ConfigEntry<bool> _enabled;

        public Plugin()
        {
            _enabled = Config.Bind("Options", "Enabled", true, "An easy way to disable this plugin quickly");
        }

        private void Awake()
        {
            Logger = base.Logger;

            if (!_enabled.Value)
            {
                Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is disabled!");
                return;
            }

            Harmony.CreateAndPatchAll(typeof(UseBookPatch));
            Harmony.CreateAndPatchAll(typeof(CharPickUpPatch));
            Harmony.CreateAndPatchAll(typeof(EquipItemToCharPatch));
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
