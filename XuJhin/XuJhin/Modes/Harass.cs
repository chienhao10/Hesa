using HesaEngine.SDK;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;
using static XuJhin.Main;
using System.Linq;

namespace XuJhin.Modes
{
    public static class Harass
    {
        public static void DoHarass()
        {
            var q = harassMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = harassMenu.GetCheckbox("useW") && W.IsReady();
            var e = harassMenu.GetCheckbox("useE") && E.IsReady();
            var won = harassMenu.GetCheckbox("WOnlist");
            var wbuff = harassMenu.GetCheckbox("useWbuff");

            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);

            if (target != null && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                if (q && target.IsValidTarget(Q.Range))
                {
                    Q.Cast(target);
                    Chat.Print("hqcast");
                }
                if (e && target.IsValidTarget(E.Range))
                {
                    E.PredictionCast(target, HitChance.High);
                    Chat.Print("hecast");
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
                                Chat.Print("hw buff1");
                            }
                        }
                        if (won && !wbuff)
                        {
                            W.PredictionCast(enemy);
                            Chat.Print("hw buff2");
                        }
                    }
                }
            }
        }
    }
}
