using System.Linq;
using HesaEngine.SDK;
using static XuTwitch.SpellManager;
using static XuTwitch.MenuManager;

namespace XuTwitch.Modes
{
    public static class Killsteal
    {
        public static void DoKS()
        {
            var e = E.IsReady() && killstealMenu.GetCheckbox("useE");
            var r = R.IsReady() && killstealMenu.GetCheckbox("useR");
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x=> x.IsValidTarget() && !x.IsZombie))
            {
                if (enemy != null)
                {
                    if (e && E.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(E.Range) && enemy.HasBuff("TwitchDeadlyVenom"))
                    {
                        E.Cast();
                        //Chat.Print("kse");
                    }

                    if (r && R.GetDamage(enemy) >= enemy.Health && enemy.IsValidTarget(R.Range))
                    {
                        R.Cast();
                        //Chat.Print("ksr");
                    }
                       
                }
            }
        }
    }
}
