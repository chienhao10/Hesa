using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using SimpleActivator.Modes;
using static SimpleActivator.MenuManager;
using static SimpleActivator.DrawingManager;
using static HesaEngine.SDK.Orbwalker;

namespace SimpleActivator
{
    public class Main : IScript
    {
        public string Name => "Xu Simple Activator";

        public string Version => "0.0.1";

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

            LoadMenu();
            LoadDrawings();

            Game.OnTick += Game_OnTick;
            Chat.Print(" Xu Simple Activator Loaded");
        }

        private void Game_OnTick()
        {

            if (Orbwalker.ActiveMode == (OrbwalkingMode.Combo) && itemMenu.GetCheckbox("enable"))
            {
                Items.DoItems();
                Items.Doorbs();
            }

            if (Orbwalker.ActiveMode == (OrbwalkingMode.LaneClear) && itemMenu.GetCheckbox("enable"))
            {
                Items.Dohydra();
            }

            if (Orbwalker.ActiveMode == (OrbwalkingMode.Flee) && itemMenu.GetCheckbox("enable"))
            {
                Items.DoItems();
            }
            SS.DoSmite();
            Items.DoQss();
            SS.DoHeal();
            Pots.DoPots();

        }
    }
}
