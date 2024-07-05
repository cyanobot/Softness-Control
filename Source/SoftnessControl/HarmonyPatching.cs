using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using RimWorld;
using Verse;

namespace SoftnessControl
{
    [HarmonyPatch("SoftWarmBeds.SoftWarmBeds_SpecialInjector", "CalculateSoftness")]
    class HarmonyPatching
    {
        public static StatDef Softness => DefDatabase<StatDef>.GetNamed("Textile_Softness");

        static bool Prefix(ThingDef def, ref float __result)
        {
            //Log.Message("CalcuateSoftness Prefix");
            //Log.Message("softness stat: " + Softness);
            //Log.Message("def: " + def + ", statlistcontains: " + def.statBases.StatListContains(Softness));

            if (def.statBases.StatListContains(Softness))
            {
                __result = def.statBases.GetStatValueFromList(Softness,-1f);
                return false;
            }

            return true;
        }

    }
}
