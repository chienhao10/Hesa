using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;

namespace XuJhin.Modes
{
    public static class AntiGapcloser
    {

        public static void DoAntigapclose(ActiveGapcloser gapcloser)
        {
            if (gapcloser.Sender.IsAlly || gapcloser.Sender.IsDead || gapcloser.Sender.IsMe) return;

            var w = miscMenu.GetCheckbox("agW") && W.IsReady();
            var e = miscMenu.GetCheckbox("agE") && E.IsReady();

            if (w && gapcloser.Sender.IsEnemy && gapcloser.Sender.IsValidTarget(W.Range) && gapcloser.Sender.HasBuff("jhinespotteddebuff"))
            {
                W.PredictionCast(gapcloser.Sender, HitChance.High);
                Chat.Print("gapw");
            }

            if (e && gapcloser.Sender.IsEnemy && gapcloser.Sender.IsValidTarget(E.Range) && gapcloser.End.Distance(ObjectManager.Player.Position) > 300)
            {
                E.PredictionCast(gapcloser.Sender, HitChance.Medium);
                Chat.Print("gape");
            }
        }
    }
}
