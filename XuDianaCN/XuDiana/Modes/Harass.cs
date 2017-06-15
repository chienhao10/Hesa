using HesaEngine.SDK;
using static XuDiana.MenuManager;
using static XuDiana.SpellManager;

namespace XuDiana.Modes
{
    public static class Harass
    {
        public static void DoHarass()
        {
            var q = harassMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = harassMenu.GetCheckbox("useW") && W.IsReady();
            var e = harassMenu.GetCheckbox("useE") && E.IsReady();
            var r = harassMenu.GetCheckbox("useR") && R.IsReady();
            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical);

            if (target != null)
            {
                if (q && target.IsValidTarget(Q.Range) && Q.MinHitChance > HitChance.High)
                {
                    Q.Cast(target.Position);
                    //Chat.Print("hrq");
                }
                if (w && target.IsValidTarget(W.Range))
                {
                    W.Cast();
                    //Chat.Print("hrw");
                }

                if (e && target.IsValidTarget(E.Range))
                {
                    E.Cast();
                    //Chat.Print("hre");
                }
                if (r && target.IsValidTarget(R.Range))
                {
                    R.Cast(target);
                    //Chat.Print("hrr");
                }
            }
        }
    }
}
