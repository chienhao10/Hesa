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
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();

            var qtarget = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);


            if (qtarget.IsValidTarget() && !ObjectManager.Player.HasBuff("JhinRShot") && q || !ObjectManager.Player.CanAttack)
            {
                Chat.Print("Q");
                Q.Cast(qtarget);
            }
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var etarget = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);
            if (e && etarget.IsValidTarget(E.Range) && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                Chat.Print("E");
                E.Cast(etarget.Position);
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

            var wbuff = comboMenu.GetCheckbox("useWbuff");
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(W.Range) && comboMenu.GetCheckbox("WOn" + x.ChampionName) && !ObjectManager.Player.HasBuff("JhinRShot")))
            {
                if (w && wbuff && enemy.HasBuff("jhinespotteddebuff"))
                {
                    W.PredictionCast(enemy);
                    Chat.Print("w buff1");
                }
                if (w && !wbuff)
                {
                    W.PredictionCast(enemy);
                    Chat.Print("w buff2");
                }
            }
        }
    }
}
