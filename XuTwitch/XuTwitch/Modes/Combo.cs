using HesaEngine.SDK;
using static XuTwitch.SpellManager;
using static XuTwitch.MenuManager;
using static XuTwitch.Main;
using System.Linq;
using HesaEngine.SDK.GameObjects;

namespace XuTwitch.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            //var qc = comboMenu.GetSlider("qCount");
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var estack = comboMenu.GetSlider("eStack");
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var savee = miscMenu.GetCheckbox("save");

            var target = TargetSelector.GetTarget(650, TargetSelector.DamageType.Physical);
            var qtarget = TargetSelector.GetTarget(GetQRange(), TargetSelector.DamageType.Physical);

            if (q && qtarget.IsValidTarget(GetQRange()))
            {
                if (savee && ObjectManager.Player.ManaPercent > E.ManaCost)
                {
                    Q.Cast();
                }
            }

            if (target != null)
            {
                if (w && target.IsValidTarget(W.Range) && ObjectManager.Player.ManaPercent > E.ManaCost)
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
                if (r && target.IsValidTarget(R.Range))
                {
                    if (savee && ObjectManager.Player.ManaPercent > E.ManaCost)
                    {
                        R.Cast();
                    }
                }
            }
        }

        
    }
}
