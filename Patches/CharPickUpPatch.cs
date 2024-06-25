using System;
using HarmonyLib;

namespace BookToggles.Patches
{
    class CharPickUpPatch
    {
        /// <summary>
        /// Closes all toggled books when the user decides to sleep, so that
        /// there's at least some burden to re-open the book, as opposed to
        /// making it permenant.
        /// </summary>
        /// <returns>True, always. So as to not overrite functionality.</returns>
        [HarmonyPatch(typeof(CharPickUp), nameof(CharPickUp.confirmSleep))]
        [HarmonyPrefix]
        static bool confirmSleep()
        {
            Array.ForEach(BookHandlers.Handlers, h => h.CloseBook());
            return true;
        }
    }
}