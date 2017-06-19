using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using static XuJhin.Main;
using System.Linq;
using HesaEngine.SDK.GameObjects;
using HesaEngine.SDK.Enums;

namespace XuJhin.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            /*var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var rtarget = TargetSelector.GetTarget(GetRRange(), TargetSelector.DamageType.Physical);

            if (rtarget != null && r && rtarget.IsValidTarget(3500))
            {
                if (rtarget.IsValidTarget(GetRRange())) return;

                if (ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    //Orbwalker.Attack = false;
                    //Main.Orbwalker.Move = false;
                    R.Cast(rtarget);
                    Chat.Print("rtarget");
                }
                else if (!ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    R.Cast(rtarget);
                    Chat.Print("ron");
                }
            }*/

            /*if (rtarget != null && r && rtarget.IsValidTarget(3500) && !rtarget.IsValidTarget(GetRRange()))
            {
                if (ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    //Orbwalker.Attack = false;
                    //Main.Orbwalker.Move = false;
                    R.Cast(rtarget);
                    Chat.Print("rtarget");
                }
                else if (!ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    R.Cast(rtarget);
                    Chat.Print("ron");
                }
            }*/

            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var qtarget = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);

            if (qtarget != null && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                if (q && qtarget.IsValidTarget(Q.Range) || q && !ObjectManager.Player.CanAttack)
                {
                    Q.Cast(qtarget);
                    Chat.Print("qcast");
                }
                if (e && etarget.IsValidTarget(E.Range))
                {
                    E.Cast(etarget.Position);
                    Chat.Print("ecast");
                }
            }

            var wtarget = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);
            var won = comboMenu.GetCheckbox($"WOn{wtarget.ChampionName}");
            var wbuff = comboMenu.GetCheckbox("useWbuff");
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();

            if (wtarget != null)
            {
                if (w && !ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x.IsValidTarget(W.Range)))
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
