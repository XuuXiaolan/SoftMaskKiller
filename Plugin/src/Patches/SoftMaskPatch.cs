using System;
using HarmonyLib;
using SoftMasking;
using UnityEngine;

namespace SoftMaskKiller.src.Patches;

[HarmonyPatch(typeof(SoftMask))]
static class SoftMaskPatch
{
    [HarmonyPatch(nameof(SoftMask.OnEnable)), HarmonyFinalizer]
    public static Exception PostfixSoftMaskOnEnable(SoftMask __instance, Exception __exception)
    {
        if (__exception != null)
        {
            SoftMaskKiller.Log.LogWarning("Preventing SoftMask from being enabled because of an exception: " + __exception);
            UnityEngine.Object.Destroy(__instance);
            return null;
        }
        return __exception;
    }
    
    [HarmonyPatch(nameof(SoftMask.OnDisable)), HarmonyFinalizer]
    public static Exception PostfixSoftMaskOnDisable(SoftMask __instance, Exception __exception)
    {
        if (__exception != null)
        {
            SoftMaskKiller.Log.LogWarning("Preventing SoftMask from erroring because of an exception: " + __exception);
            return null;
        }
        return __exception;
    }
}