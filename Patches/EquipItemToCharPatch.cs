using HarmonyLib;

namespace BookToggles.Patches
{
    public class EquipItemToCharPatch
    {
        [HarmonyPatch(typeof(EquipItemToChar), nameof(EquipItemToChar.catchAndShowBug))]
        [HarmonyPostfix]
        static void catchAndShowBug()
        {
            BookHandlers.BugBookHandler.RefreshBook();
        }

        [HarmonyPatch(typeof(EquipItemToChar), nameof(EquipItemToChar.catchAndShowFish))]
        [HarmonyPostfix]
        static void catchAndShowFish()
        {
            BookHandlers.FishBookHandler.RefreshBook();
        }
    }
}