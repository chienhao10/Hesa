using HesaEngine.SDK;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;
using static XuTwitch.Main;

namespace XuTwitch.Modes
{
    public static class Harass
    {
        public static void DoHarass()
        {
            var w = harassMenu.GetCheckbox("useW") && W.IsReady();
            var e = harassMenu.GetCheckbox("useE") && E.IsReady();
            var estack = harassMenu.GetSlider("heStack");

            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical);

            if (target != null)
            {
                if (w && target.IsValidTarget(W.Range))
                {
                    W.PredictionCast(target, HitChance.High);
                }
                if (e && target.IsValidTarget(E.Range) && target.HasBuff("TwitchDeadlyVenom"))
                {
                    if (GetEStackCount(target) >= estack)
                    {
                        E.Cast();
                    }
                }
            }
        }
    }
}
