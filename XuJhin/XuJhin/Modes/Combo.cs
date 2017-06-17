using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using static XuJhin.Main;
using System.Linq;
using HesaEngine.SDK.GameObjects;

namespace XuJhin.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            var won = comboMenu.GetCheckbox("WOnlist");
            var wbuff = comboMenu.GetCheckbox("useWbuff");
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            
            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(GetRRange(), TargetSelector.DamageType.Physical);
            
            if (target != null && r && !rtarget.IsValidTarget(GetRRange()))
            {
                R.PredictionCast(rtarget);
                Chat.Print("rcast");
            }

            if (target != null && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                if (q && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                    Chat.Print("qcast");
                }
                if (e && target.IsValidTarget(E.Range))
                {
                    E.PredictionCast(target, HitChance.High);
                    Chat.Print("ecast");
                }
            }

            if (w && !ObjectManager.Player.HasBuff("JhinRShot") && target != null)
            {
                foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                {
                    if (enemy.IsValidTarget(W.Range))
                    {
                        if (won && wbuff)
                        {
                            if (enemy.HasBuff("jhinespotteddebuff"))
                            {
                                W.PredictionCast(enemy);
                                Chat.Print("w buff1");
                            }
                        }
                        if (won && !wbuff)
                        {
                            W.PredictionCast(enemy);
                            Chat.Print("w buff2");
                        }
                    }
                }
            }
        }
    }
}
