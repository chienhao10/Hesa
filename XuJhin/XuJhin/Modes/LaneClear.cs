using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static XuJhin.Main;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;

namespace XuJhin.Modes
{
    public static class LaneClear
    {
        public static void DoLaneClear()
        {
            int MinionAround = 0;
            var q = laneclearMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = laneclearMenu.GetCheckbox("useW") && W.IsReady();
            var e = laneclearMenu.GetCheckbox("useE") && E.IsReady();
            
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget());

            foreach (var m in minion)
            {
                if (m.IsValidTarget(Q.Range))
                    MinionAround++;

                if (w && MinionAround >= 3 && m.IsValidTarget(W.Range))
                {
                    W.PredictionCast(m, HitChance.High);
                    Chat.Print("lcw");
                }
                if (q && MinionAround >= 3 && m.IsValidTarget(Q.Range))
                {
                    Q.Cast(m);
                    Chat.Print("lcq");
                }
                if (e && MinionAround >= 3 && m.IsValidTarget(E.Range))
                {
                    E.Cast(m.Position);
                    Chat.Print("lcr");
                }

            }
        }
    }
}
