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
            var e = lasthitMenu.GetCheckbox("useE") && E.IsReady();
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget(E.Range));

            foreach (var m in minion)
            {
                if (e && E.GetDamage(m) >= m.Health && m.IsValidTarget(E.Range))
                {
                    E.Cast();
                    Chat.Print("laste");
                }
                if (q && Q.GetDamage(m) >= m.Health && m.IsValidTarget(Q.Range))
                {
                    Q.Cast();
                    Chat.Print("lastq");
                }
            }
        }
    }
}
