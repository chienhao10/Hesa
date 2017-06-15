using System.Linq;
using HesaEngine.SDK;
using static XuDiana.MenuManager;
using static XuDiana.SpellManager;

namespace XuDiana.Modes
{
    public static class LastHit
    {
        public static void DoLastHit()
        {
            var q = lasthitMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = lasthitMenu.GetCheckbox("useW") && W.IsReady();
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget(Q.Range));

            foreach (var m in minion)
            {
                if (q && Q.GetDamage(m) >= m.Health && !m.IsValidTarget(175))
                {
                    Q.CastIfHitchanceEquals(m, HitChance.High);
                    //Chat.Print("lastq");
                }

                if (w && Q.GetDamage(m) >= m.Health && m.IsValidTarget(W.Range))
                {
                    W.Cast();
                    //Chat.Print("lastw");
                }
            }
        }
    }
}
