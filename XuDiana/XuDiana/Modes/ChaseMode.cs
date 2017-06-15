using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;

namespace XuDiana.Modes
{
    public static class ChaseCombo
    {
        public static void DoChaseCombo()
        {
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var mine = chaseMenu.GetSlider("minRe");
            var qbuff = comboMenu.GetCheckbox("useRbuff");
            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical);

            if (target != null)
            {
                if (q && target.IsInRange(ObjectManager.Player, Q.Range) && Q.MinHitChance > HitChance.Medium)
                {
                    Q.Cast(target);
                }
            }

            if (target != null)
            {
                if (w && target.IsInRange(ObjectManager.Player, W.Range))
                {
                    W.Cast();
                }
            }

            if (target != null)
            {
                if (e && target.IsInRange(ObjectManager.Player, E.Range) && target.Distance(ObjectManager.Player) >= mine)
                {
                    E.Cast();
                }
            }

            if (target != null)
            {
                if (r && target.IsInRange(ObjectManager.Player, R.Range) && qbuff && target.HasBuff("dianamoonlight") && target.Distance(ObjectManager.Player) >= mine)
                {
                    R.Cast(target);
                }
                else
                if (r && target.IsInRange(ObjectManager.Player, R.Range) && !qbuff && target.Distance(ObjectManager.Player) >= mine)
                {
                    R.Cast(target);
                }
            }

            Killsteal.DoKS();
        }
    }
}
