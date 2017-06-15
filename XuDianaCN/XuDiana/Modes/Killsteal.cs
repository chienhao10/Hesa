using System.Linq;
using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;

namespace XuDiana.Modes
{
    public static class Killsteal
    {
        public static void DoKS()
        {
            var q = Q.IsReady() && killstealMenu.GetCheckbox("useQ");
            var w = W.IsReady() && killstealMenu.GetCheckbox("useW");
            var r = R.IsReady() && killstealMenu.GetCheckbox("useR");
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x=> x.IsValidTarget() && !x.IsZombie))
            {
                if (enemy != null)
                {
                    if (q && Q.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(Q.Range))
                    {
                        Q.PredictionCast(enemy);
                        //Chat.Print("ksq");
                    }


                    if (w && W.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(W.Range))
                    {
                        W.Cast();
                        //Chat.Print("ksw");
                    }

                    if (r && W.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(R.Range))
                    {
                        R.Cast(enemy);
                        //Chat.Print("ksr");
                    }
                       
                }
            }
        }
    }
}
