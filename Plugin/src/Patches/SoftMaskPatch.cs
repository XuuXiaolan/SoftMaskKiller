using HarmonyLib;
using SoftMasking;
using UnityEngine;

namespace SoftMaskKiller.src.Patches;
public static class SoftMaskPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(SoftMask), "OnEnable")]
    static void PrefixSoftMaskOnEnable(SoftMask __instance)
    {
        SoftMaskKiller.Log.LogDebug("Preventing SoftMask from being enabled");
        Object.Destroy(__instance);
    }
}