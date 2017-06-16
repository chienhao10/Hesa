using System.Linq;
using HesaEngine.SDK;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;

namespace XuTwitch.Modes
{
    public static class LastHit
    {
        public static void DoLastHit()
        {
            var e = lasthitMenu.GetCheckbox("useE") && E.IsReady();
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget(E.Range));

            foreach (var m in minion)
            {
                if (e && E.GetDamage(m) >= m.Health && m.IsValidTarget(E.Range))
                {
                    E.Cast();
                    //Chat.Print("laste");
                }
            }
        }
    }
}
