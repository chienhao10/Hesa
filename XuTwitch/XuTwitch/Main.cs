using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using XuTwitch.Modes;
using static XuTwitch.SpellManager;
using static XuTwitch.MenuManager;
using static XuTwitch.DrawingManager;
using static HesaEngine.SDK.Orbwalker;

namespace XuTwitch
{
    public class Main : IScript
    {
        private readonly Champion champion = Champion.Twitch;

        public string Name => "Xu " + champion;

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
            if (Player.ChampionName != "Twitch")
                return;

            LoadMenu();

            LoadSpells();

            HesaEngine.SDK.AntiGapcloser.OnEnemyGapcloser += Modes.AntiGapcloser.DoAntigapclose;

            LoadDrawings();

            Game.OnTick += Game_OnTick;
            Chat.Print(" Xu Twitch Loaded");
        }


        int qRange = 600;

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
                Items.DoItems();
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
                Items.DoItems();
            }
            Pots.DoPots();
            
            if (qRange == GetQRange()) return;
            qRange = GetQRange();
            Q.Range = qRange;
        }

        public static int GetQRange()
        {
            return comboMenu.GetSlider("qRange");
        }

        public static int GetEStackCount(Obj_AI_Base target)
        {
            return target.HasBuff("TwitchDeadlyVenom") ? target.GetBuffCount("TwitchDeadlyVenom") : 0;
        }
    }
}
