using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using System.Linq;
using XuJhin;

namespace XuJhin.Modes
{
    public static class AutoW
    {
        public static void DoAutoW()
        {
            var w = autowMenu.GetCheckbox("autoW") && W.IsReady();

            //Boli's Code
            if (!w || ObjectManager.Player.HasBuff("JhinRShot")) return;
            
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(W.Range) && harassMenu.GetCheckbox("WOn" + x.ChampionName) && !ObjectManager.Player.HasBuff("JhinRShot") && x.HasBuff("jhinespotteddebuff")))
            {
                var location = DarkPrediction.CirclerPrediction(W, enemy, 1);
                if (enemy != null && w && location != DarkPrediction.empt && ObjectManager.Me.Position.Distance(location) <= W.Range)
                    W.Cast(location);
                break;
            }
        }
    }
}
