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
        private readonly Champion champion = Champion.Jhin;

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
            if (Player.ChampionName != "Jhin")
                return;

            LoadMenu();

            LoadSpells();

            HesaEngine.SDK.AntiGapcloser.OnEnemyGapcloser += Modes.AntiGapcloser.DoAntigapclose;
            HesaEngine.SDK.Orbwalker.AfterAttack += Orbwalker_AfterAttack;
            LoadDrawings();

            Game.OnTick += Game_OnTick;
            Chat.Print(" Xu Jhin Loaded");
        }

        private void Orbwalker_AfterAttack(AttackableUnit unit, AttackableUnit target)
        {
            var q = comboMenu.GetCheckbox("useAAQ") && Q.IsReady();
            var qtarget = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);

            if (qtarget.IsValidTarget() && !ObjectManager.Player.HasBuff("JhinRShot") && q)
            {
                Chat.Print("Q");
                Q.Cast(qtarget);
            }
        }

        int rRange = 3500;

        private void Game_OnTick()
        {
            if (Player.IsRecalling() || Player.IsDead)
                return;

            var mana = Player.ManaPercent;

            if (killstealMenu.GetCheckbox("enable"))
            {
                Killsteal.DoKS();
            }


            if (Orbwalker.ActiveMode == (OrbwalkingMode.Combo) && mana >= comboMenu.GetSlider("mana"))
            {
                Combo.DoCombo();
                Items.DoItems();
                Items.Doorbs();
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

            /*if (rMode.GetKeybind("rKey"))
            {
                RTap.DoRTap();
            }*/
            if (autowMenu.GetCheckbox("autoW"))
            {
                AutoW.DoAutoW();
            }
            Pots.DoPots();
            SS.DoSmite();
            SS.DoHeal();

            if (rRange == GetRRange()) return;
            rRange = GetRRange();
            R.Range = rRange;
        }

        public static int GetRRange()
        {
            return comboMenu.GetSlider("rRange");
        }
    }
}
