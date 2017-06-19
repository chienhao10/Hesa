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
            var saferange = comboMenu.GetSlider("ksRange");
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x=> x.IsValidTarget() && !x.IsZombie))
            {
                if (enemy != null)
                {
                    if (q && Q.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(Q.Range))
                    {
                        Q.Cast(enemy);
                        //Chat.Print("ksq");
                    }

                    if (r && R.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(R.Range) && !enemy.IsValidTarget(saferange))
                    {
                        R.Cast(enemy);
                        //Chat.Print("ksr");
                    }
                       
                }
            }
        }
    }
}
