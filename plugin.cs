using BepInEx.Configuration;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using GameNetcodeStuff;

namespace SuitFix
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class LethalLogoMod : BaseUnityPlugin
    {
        public const string modGUID = "com.ashk3000.SuitFix";
        public const string modName = "SuitFix";
        public const string modVersion = "1.0.0";

        public static ConfigEntry<string> imagePath;

        private readonly Harmony harmony = new Harmony(modGUID);

        private void Awake()
        {
            harmony.PatchAll(typeof(MenuManagerPatch));
        }
    }

    [HarmonyPatch(typeof(PlayerControllerB))]
    class MenuManagerPatch
    {
        [HarmonyPatch("SetHoverTipAndCurrentInteractTrigger")]
        [HarmonyPostfix]
        static void Postfix(PlayerControllerB __instance)
        {

            if (__instance.cursorTip.text == "Change suit")
            {
                __instance.cursorTip.text = "Change: Decoy suit";
            }
        }
    }
}
