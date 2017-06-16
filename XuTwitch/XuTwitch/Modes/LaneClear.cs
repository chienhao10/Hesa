using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static XuTwitch.Main;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;

namespace XuTwitch.Modes
{
    public static class LaneClear
    {
        public static void DoLaneClear()
        {
            int MinionAround = 0;
            var q = laneclearMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = laneclearMenu.GetCheckbox("useW") && W.IsReady();
            var r = laneclearMenu.GetCheckbox("useR") && R.IsReady();
            var e = laneclearMenu.GetCheckbox("useE") && E.IsReady();
            var le = laneclearMenu.GetSlider("leStack");
            
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget());

            foreach (var m in minion)
            {
                if (m.IsValidTarget(Q.Range))
                    MinionAround++;

                if (w && MinionAround >= 3 && m.IsValidTarget(W.Range))
                {
                    W.PredictionCast(m, HitChance.High);
                    //Chat.Print("lcw");
                }
                if (q && MinionAround >= 3 && m.IsValidTarget(Q.Range))
                {
                    Q.Cast();
                    //Chat.Print("lcq");
                }
                if (r && MinionAround >= 6 && m.IsValidTarget(R.Range))
                {
                    R.Cast(m);
                    //Chat.Print("lcr");
                }
                if (e && MinionAround >= 3 && m.IsValidTarget(E.Range) || m.Health < E.GetDamage(m))
                {
                    if (GetEStackCount(m) >= le)
                    {
                        E.Cast();
                    }
                    //Chat.Print("lcq");
                }
            }
        }
    }
}
