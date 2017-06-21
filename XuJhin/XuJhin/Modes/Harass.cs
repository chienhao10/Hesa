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
            var minionQ = MinionManager.GetMinions(Q.Range, MinionTypes.All, MinionTeam.NotAlly).FirstOrDefault(x =>Q.IsInRange(x) 
            && x.Distance(ObjectManager.Heroes.Enemies.OrderBy(y => y.Distance(ObjectManager.Player)).FirstOrDefault()) < ObjectManager.Player.Distance(ObjectManager.Heroes.Enemies.OrderBy(z => z.Distance(ObjectManager.Player)).FirstOrDefault()));
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(Q.Range + 300, true) && !x.IsDead && !x.IsZombie))
            {

                if (tryq && minionQ != null && enemy != null && minionQ.Distance(enemy) < Q.Range)
                {
                    Q.CastOnUnit(minionQ);
                    //Chat.Print("try q");

                    return;
                }
            }

            /*var tryq = harassMenu.GetCheckbox("tryQ") && Q.IsReady();
            var tryqtarget = TargetSelector.GetTarget(Q.Range + 300, TargetSelector.DamageType.Physical);

            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.Distance(tryqtarget) >= 300 && x.IsValidTarget(Q.Range));

            foreach (var m in minion)
            {
                if (m != null && tryq)
                {
                    Q.Cast(m);
                    Chat.Print("try q");
                }
            }*/

            var wbuff = harassMenu.GetCheckbox("useWbuff");
            var w = harassMenu.GetCheckbox("useW") && W.IsReady();
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(W.Range) && harassMenu.GetCheckbox("WOn" + x.ChampionName) && !ObjectManager.Player.HasBuff("JhinRShot")))
            {
                if (w && wbuff && enemy.HasBuff("jhinespotteddebuff"))
                {
                    var location = DarkPrediction.CirclerPrediction(W, enemy, 1);
                    if (location != DarkPrediction.empt && ObjectManager.Me.Position.Distance(location) <= W.Range)
                    {
                        W.Cast(location);
                        //Chat.Print(W.Delay);
                        break;
                    }
                }
                if (w && !wbuff)
                {
                    var location = DarkPrediction.CirclerPrediction(W, enemy, 1);
                    if (location != DarkPrediction.empt && ObjectManager.Me.Position.Distance(location) <= W.Range)
                    {
                        W.Cast(location);
                        //Chat.Print("w buff2");
                        break;
                    }

                }
            }
        }
    }
}
