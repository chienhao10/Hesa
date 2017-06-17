using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using System.Linq;

namespace XuJhin.Modes
{
    public static class Flee
    {
        public static void DoFlee()
        {
            var w = fleeMenu.GetCheckbox("useW") && W.IsReady();
            var e = fleeMenu.GetCheckbox("useE") && E.IsReady();
            var Target = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);


            if (w && Target.HasBuff("jhinespotteddebuff"))
            {
                W.PredictionCast(Target, HitChance.VeryHigh);
            }

            if (e && Target.IsValidTarget(E.Range))
            {
                E.PredictionCast(Target, HitChance.High);
            }
        }
    }
}
