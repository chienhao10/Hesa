using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;

namespace XuDiana.Modes
{
    public static class AntiGapcloser
    {

        public static void DoAntigapclose(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsAlly || gapcloser.Sender.IsDead || gapcloser.Sender.IsMe) return;

            var w = miscMenu.GetCheckbox("agW") && W.IsReady();
            var e = miscMenu.GetCheckbox("agE") && E.IsReady();

            if (w && gapcloser.Sender.IsEnemy && gapcloser.Sender.IsDashing() && gapcloser.Sender.IsValidTarget(W.Range))
                W.Cast();

            if (e && gapcloser.Sender.IsEnemy && gapcloser.Sender.IsDashing() && gapcloser.Sender.IsValidTarget(E.Range))
                E.Cast();
        }
    }
}
