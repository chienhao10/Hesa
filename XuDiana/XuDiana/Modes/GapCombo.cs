using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;
using System.Linq;

namespace XuDiana.Modes
{
    public static class GapCombo
    {
        public static void DoGapCombo()
        {
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var gaptarget = TargetSelector.GetTarget(Q.Range + R.Range, TargetSelector.DamageType.Magical);
            var rtarget2 = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical);
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget());

            if (gaptarget != null && gaptarget.IsValidTarget(Q.Range + R.Range))
            {
                foreach (var m in minion)
                {
                    if (q && m.IsValidTarget(Q.Range) && !m.IsDead)
                    {
                        Q.PredictionCast(m, HitChance.Low);
                        //Chat.Print("gapq");
                    }
                    if (r && m.IsValidTarget(R.Range) && !m.IsDead && m.HasBuff("dianamoonlight"))
                    {
                        R.Cast(m);
                        //Chat.Print("gapr1");
                    }
                    else
                    if (r && m.IsValidTarget(R.Range) && !m.IsDead && !m.HasBuff("dianamoonlight"))
                    {
                        R.Cast(m);
                        //Chat.Print("gapr2");
                    }

                    if (r && rtarget2.IsValidTarget(R.Range))
                    {
                        R.Cast(rtarget2);
                        //Chat.Print("gaptarget");
                    }

                    if (w && rtarget2.IsValidTarget(W.Range))
                    {
                        W.Cast();
                    }

                    if (e && rtarget2.IsValidTarget(E.Range))
                    {
                        E.Cast();
                    }
                }
            }

        }
    }
}
