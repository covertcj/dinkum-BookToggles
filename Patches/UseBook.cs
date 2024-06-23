using System;
using HarmonyLib;

namespace BookToggles.Patches
{
    class UseBookPatch
    {
        /// <summary>
        /// <see cref="closeBook"/> can be called when the user never opened a
        /// book in the first place, such as when switching items. So this
        /// field exists to track whether the user opened the book, allowing
        /// us to skip other events.
        /// </summary>
        private static bool _bookWasOpened;

        private static bool _isBugBookOpen;

        [HarmonyPatch(typeof(UseBook), nameof(UseBook.openBook))]
        [HarmonyPrefix]
        static bool openBook()
        {
            Plugin.Logger.LogInfo("You opened a book!");
            _bookWasOpened = true;
            return true;
        }

        [HarmonyPatch(typeof(UseBook), nameof(UseBook.closeBook))]
        [HarmonyPrefix]
        static bool closeBook(UseBook __instance, CharMovement ___myChar)
        {
            if (___myChar == null || !___myChar.isLocalPlayer) return true;

            // skip the book close logic altogether if this wasn't triggered by a book opening
            if (!_bookWasOpened) return false;
            _bookWasOpened = false;

            Plugin.Logger.LogInfo("You closed a book!");

            if (__instance.isBugBook)
            {
                if (_isBugBookOpen)
                {
                    Plugin.Logger.LogInfo("And we'll let it close!");
                    _isBugBookOpen = false;
                    return true;
                }
                else if (AnimalManager.manage.bugBookOpen)
                {
                    Plugin.Logger.LogInfo("But we'll keep it open for you!");
                    _isBugBookOpen = true;
                    return false;
                }
            }

            return true;
        }
    }
}