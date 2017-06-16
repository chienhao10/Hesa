using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using XuDiana.Modes;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;
using static XuDiana.DrawingManager;
using static HesaEngine.SDK.Orbwalker;

namespace XuDiana
{
    public class Main : IScript
    {
        private readonly Champion champion = Champion.Diana;

        public string Name => "Xu Diana" + champion;

        public string Version => "0.0.3";

        public string Author => "Xu211";

        public AIHeroClient Player => ObjectManager.Player;
        public static PredictionInput QPred, WPred, EPred, RPred;

        public static OrbwalkerInstance Orbwalker => Core.Orbwalker;

        public void OnInitialize()
        {
            Game.OnGameLoaded += Game_OnGameLoaded;
        }

        private void Game_OnGameLoaded()
        {
            if (Player.ChampionName != "Diana")
                return;

            LoadMenu();

            LoadSpells();

            HesaEngine.SDK.AntiGapcloser.OnEnemyGapcloser += Modes.AntiGapcloser.DoAntigapclose;

            LoadDrawings();

            Game.OnTick += Game_OnTick;
            Chat.Print(" Xu Diana Loaded");
        }



        private void Game_OnTick()
        {
            var mana = Player.ManaPercent;

            if (killstealMenu.GetCheckbox("enable"))
            {
                Killsteal.DoKS();
            }
                

            if (Orbwalker.ActiveMode == (OrbwalkingMode.Combo) && mana >= comboMenu.GetSlider("mana"))
            {
                Combo.DoCombo();
            }

            if (Orbwalker.ActiveMode == (OrbwalkingMode.Harass) && mana >= harassMenu.GetSlider("mana"))
            {
                Harass.DoHarass();
            }

            if (Orbwalker.ActiveMode == (OrbwalkingMode.LaneClear) && mana >= laneclearMenu.GetSlider("mana"))
                LaneClear.DoLaneClear();

            if (Orbwalker.ActiveMode == (OrbwalkingMode.LastHit) && mana >= lasthitMenu.GetSlider("mana"))
                LastHit.DoLastHit();

            if (Orbwalker.ActiveMode == (OrbwalkingMode.Flee))
            {
                Flee.DoFlee();
            }
            if(chaseMenu.GetKeybind("chaseK"))
            {
                ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPosition);
                ChaseCombo.DoChaseCombo();
            }

            if (comboMenu.GetKeybind("advK"))
            {
                ObjectManager.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPosition);
                GapCombo.DoGapCombo();
            }
        }
    }
}
