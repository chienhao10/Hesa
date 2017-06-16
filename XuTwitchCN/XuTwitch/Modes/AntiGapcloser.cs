using HesaEngine.SDK;
using static XuTwitch.SpellManager;
using static XuTwitch.MenuManager;

namespace XuTwitch.Modes
{
    public static class AntiGapcloser
    {

        public static void DoAntigapclose(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsAlly || gapcloser.Sender.IsDead || gapcloser.Sender.IsMe) return;

            var w = miscMenu.GetCheckbox("agW") && W.IsReady();

            if (w && gapcloser.Sender.IsEnemy && gapcloser.Sender.IsValidTarget(W.Range))
            {
                W.Cast();
                Chat.Print("gapw");
            }

                
        }
    }
}
