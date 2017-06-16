using HesaEngine.SDK;
using static XuTwitch.SpellManager;
using static XuTwitch.MenuManager;
using System.Linq;

namespace XuTwitch.Modes
{
    public static class Flee
    {
        public static void DoFlee()
        {
            var q = fleeMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = fleeMenu.GetCheckbox("useW") && W.IsReady();
            var Target = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);


            if (q)
            {
                Q.Cast();
            }

            if (w && Target.IsValidTarget(W.Range) && ObjectManager.Player.ManaPercent - W.ManaCost > Q.ManaCost)
            {
                W.PredictionCast(Target, HitChance.High);
            }
        }
    }
}
