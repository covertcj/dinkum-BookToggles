using System.Linq;
using BookToggles.Handlers;
using HarmonyLib;

namespace BookToggles.Patches
{
    class UseBookPatch
    {
        /// <summary>
        /// Checks to see if the mod can handle overriding the behavior of a
        /// book and does so if it can.
        /// </summary>
        [HarmonyPatch(typeof(UseBook), nameof(UseBook.openBook))]
        [HarmonyPrefix]
        static bool openBook(UseBook __instance, CharMovement ___myChar)
        {
            if (___myChar == null || !___myChar.isLocalPlayer) return true;

            IBookHandler handler = BookHandlers.Handlers.FirstOrDefault(h => h.CanHandleBook(__instance));
            if (handler == null)
            {
                return true;
            }

            bool isOpen = handler.ToggleBook();
            NotificationManager.manage.createChatNotification($"You've {(isOpen ? "opened" : "closed")} your {handler.Name} book");

            return false;
        }

        /// <summary>
        /// Checks to see if the mod can handle overriding the behavior of a
        /// book and blocks the default close behavior if it can.
        /// </summary>
        [HarmonyPatch(typeof(UseBook), nameof(UseBook.closeBook))]
        [HarmonyPrefix]
        static bool closeBook(UseBook __instance, CharMovement ___myChar)
        {
            if (___myChar == null || !___myChar.isLocalPlayer) return true;

            IBookHandler handler = BookHandlers.Handlers.FirstOrDefault(h => h.CanHandleBook(__instance));
            if (handler == null)
            {
                return true;
            }

            return false;
        }
    }
}