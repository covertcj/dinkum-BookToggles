using System;
using HarmonyLib;

namespace BookToggles.Patches
{
    class WorldManagerPatch
    {
        [HarmonyPatch(typeof(WorldManager), nameof(WorldManager.nextDay))]
        [HarmonyPrefix]
        static bool nextDay()
        {
            Array.ForEach(BookHandlers.Handlers, h => h.closeBook());
            return true;
        }
    }
}