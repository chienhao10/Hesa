using System.Linq;
using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;

namespace XuJhin.Modes
{
    public static class Killsteal
    {
        public static void DoKS()
        {
            var q = E.IsReady() && killstealMenu.GetCheckbox("useQ");
            var r = R.IsReady() && killstealMenu.GetCheckbox("useR");
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x=> x.IsValidTarget() && !x.IsZombie))
            {
                if (enemy != null)
                {
                    if (q && Q.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(Q.Range))
                    {
                        Q.Cast(enemy);
                        Chat.Print("kse");
                    }

                    if (r && R.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(3500))
                    {
                        R.Cast(enemy);
                        Chat.Print("ksr");
                    }
                       
                }
            }
        }
    }
}
