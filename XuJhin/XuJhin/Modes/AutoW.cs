using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using System.Linq;

namespace XuJhin.Modes
{
    public static class AutoW
    {
        public static void DoAutoW()
        {
            var w = autowMenu.GetCheckbox("autoW") && W.IsReady();

            //Boli's Code
            if (!w || ObjectManager.Player.HasBuff("JhinRShot")) return;
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(W.Range) && autowMenu.GetCheckbox("Won" + x.ChampionName) && x.HasBuff("jhinespotteddebuff")))
            {
                if (w)
                    W.PredictionCast(enemy);
            }





            /*

            //Xu's Code
            var target = ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x.IsValidTarget(W.Range));
            var wtarget = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);
            var won = autowMenu.GetCheckbox($"Won{wtarget.ChampionName}");
            

            if (target != null)
            {
                if (w && won && !ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    foreach (var enemy in target)
                    {
                        if (enemy.IsValidTarget(W.Range))
                        {
                            if (w)
                            {
                                if (enemy.HasBuff("jhinespotteddebuff"))
                                {
                                    W.PredictionCast(enemy);
                                    Chat.Print("auto w");
                                }
                            }
                        }
                    }
                }
            }*/
        }
    }
}
