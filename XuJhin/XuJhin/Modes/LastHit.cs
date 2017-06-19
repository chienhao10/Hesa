using System.Linq;
using HesaEngine.SDK;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;

namespace XuJhin.Modes
{
    public static class LastHit
    {
        public static void DoLastHit()
        {
            var q = lasthitMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = lasthitMenu.GetCheckbox("useW") && W.IsReady();
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget());

            
            foreach (var m in minion)
            {
                if (m != null)
                {
                    if (w && W.GetDamage(m) >= m.Health && m.IsValidTarget(W.Range))
                    {
                        W.Cast(m);
                       // Chat.Print("laste");
                    }
                    if (q && Q.GetDamage(m) >= m.Health && m.IsValidTarget(Q.Range) || q && !ObjectManager.Player.CanAttack)
                    {
                        Q.Cast(m);
                       // Chat.Print("lastq");
                    }
                }

            }
        }
    }
}
