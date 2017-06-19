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
            var e = harassMenu.GetCheckbox("useE") && E.IsReady();

            var target = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);

            if (target != null && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                if (q && target.IsValidTarget(Q.Range) || q && !ObjectManager.Player.CanAttack)
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

            var tryq = harassMenu.GetCheckbox("tryQ") && Q.IsReady();
            var tryqtarget = TargetSelector.GetTarget(Q.Range + 300, TargetSelector.DamageType.Physical);

            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.Distance(tryqtarget) >= 300 && x.IsValidTarget(Q.Range));

            foreach (var m in minion)
            {
                if (m != null && tryq)
                {
                    Q.Cast(m);
                    Chat.Print("try q");
                }
            }

            var w = harassMenu.GetCheckbox("useW") && W.IsReady();
            var wbuff = harassMenu.GetCheckbox("useWbuff");
            var won = harassMenu.GetCheckbox($"WOn{target.ChampionName}");
            var wtarget = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);

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
