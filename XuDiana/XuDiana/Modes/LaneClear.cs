using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static XuDiana.MenuManager;
using static XuDiana.SpellManager;

namespace XuDiana.Modes
{
    public static class LaneClear
    {
        public static void DoLaneClear()
        {
            int MinionAround = 0;
            var q = laneclearMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = laneclearMenu.GetCheckbox("useW") && W.IsReady();
            var r = laneclearMenu.GetCheckbox("useR") && R.IsReady();
            var e = laneclearMenu.GetCheckbox("useR") && E.IsReady();

            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget());

            foreach (var m in minion)
            {
                if (m.IsValidTarget(Q.Range))
                    MinionAround++;

                if (w && MinionAround >= 3 && m.IsValidTarget(W.Range))
                {
                    W.Cast();
                    //Chat.Print("lcw");
                }
                if (q && MinionAround >= 3 && m.IsValidTarget(Q.Range))
                {
                    Q.PredictionCast(m, HitChance.Low);
                    //Chat.Print("lcq");
                }
                if (r && m.IsValidTarget(R.Range))
                {
                    R.Cast(m);
                    //Chat.Print("lcr");
                }
                if (e && MinionAround >= 3 && m.IsValidTarget(E.Range))
                {
                    E.Cast();
                    //Chat.Print("lcq");
                }
            }
        }
    }
}
