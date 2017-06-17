using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using XuJhin.Modes;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using static XuJhin.DrawingManager;
using static HesaEngine.SDK.Orbwalker;

namespace XuJhin
{
    public class Main : IScript
    {
        private readonly Champion champion = Champion.Twitch;

        public string Name => "Xu " + champion;

        public string Version => "0.0.6";

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
            Chat.Print(" Xu Jhin Loaded");
        }


        int rRange = 1000;

        private void Game_OnTick()
        {
            var mana = Player.ManaPercent;

            if (killstealMenu.GetCheckbox("enable"))
            {
                Killsteal.DoKS();
                Items.DoItems();
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

            if (rMode.GetKeybind("rKey"))
            {
                RTap.DoRTap();
            }
            AutoW.DoAutoW();
            Pots.DoPots();
            
            if (rRange == GetRRange()) return;
            rRange = GetRRange();
            R.Range = rRange;
        }

        public static int GetRRange()
        {
            return comboMenu.GetSlider("rRange");
        }

        public static int GetEStackCount(Obj_AI_Base target)
        {
            return target.HasBuff("TwitchDeadlyVenom") ? target.GetBuffCount("TwitchDeadlyVenom") : 0;
        }
    }
}
