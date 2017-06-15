using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;

namespace XuDiana.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var qbuff = comboMenu.GetCheckbox("useRbuff");
            var target = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Magical);

            if (target != null)
            {
                if (q && target.IsValidTarget(Q.Range))
                {
                    Q.PredictionCast(target);
                    //Chat.Print("ComboQ");
                }
                if(r && target.IsValidTarget(R.Range))
                {
                    if(qbuff && target.HasBuff("dianamoonlight"))
                    {
                        R.Cast(target);
                        //Chat.Print("ComboQr");
                    }
                    else if(!qbuff)
                    {
                        R.Cast(target);
                        //Chat.Print("ComboQR2");
                    }
                }
                if (w && target.IsValidTarget(W.Range))
                {
                    W.Cast();
                    //Chat.Print("w");
                }

                if (e && target.IsValidTarget(E.Range))
                {
                    E.Cast();
                    //Chat.Print("e");
                }

            }

           /* if (target != null)
            {
                if (r && target.IsValidTarget(R.Range) && !qbuff)
                {
                    R.Cast(target);
                    Chat.Print("user");
                }
            }*/

            Killsteal.DoKS();
        }
    }
}
