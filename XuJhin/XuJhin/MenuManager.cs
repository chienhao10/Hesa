using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using SharpDX;
using System.Linq;

namespace XuJhin
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, rMode, chaseMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, autowMenu, fleeMenu, drawingMenu, potMenu, ssMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static bool IsSummonersRift => Game.MapId == GameMapId.SummonersRift;
        public static bool IsTwistedTreeline => Game.MapId == GameMapId.TwistedTreeline;


        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu Jhin");


            comboMenu = Home.AddSubMenu(prefix + "Combo");
            comboMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            comboMenu.Add(new MenuCheckbox("useAAQ", "Use Q After AA", true));
            comboMenu.Add(new MenuCheckbox("useW", "Use W", true));
            comboMenu.Add(new MenuCheckbox("useWbuff", "Only W Marked", true));
            foreach (var enemy in ObjectManager.Heroes.Enemies) //you are checking enemy champs.. .Me and .Ally are not enemies and will never be.
            {
                comboMenu.Add(new MenuCheckbox($"WOn{enemy.ChampionName}", $"W On {enemy.ChampionName}", true));
            }

            comboMenu.Add(new MenuCheckbox("useE", "Use E", true));
            comboMenu.Add(new MenuCheckbox("useR", "Use R", true));
            comboMenu.Add(new MenuSlider("rRange", "Enemy Search Range R", 600, 3500, 3500));
            comboMenu.Add(new MenuSlider("ksRange", "Enemy In Range NOT R", 600, 3500, 600));
            comboMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            rMode = Home.AddSubMenu(prefix + "R Sniper");
            rMode.Add(new MenuKeybind("rKey", "R Tap Key", SharpDX.DirectInput.Key.G));
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
            {
                rMode.Add(new MenuCheckbox($"ROn{enemy.ChampionName}", $"R On {enemy.ChampionName}", true));
            }

            harassMenu = Home.AddSubMenu(prefix + "Harass");
            harassMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            harassMenu.Add(new MenuCheckbox("tryQ", "Try Q Bounce Harass", true));
            harassMenu.Add(new MenuCheckbox("useW", "Use W", true));
            harassMenu.Add(new MenuCheckbox("useWbuff", "Only W Marked", true));
            harassMenu.Add(new MenuCheckbox("useE", "Use E", true));
            harassMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
            {
                harassMenu.Add(new MenuCheckbox($"WOn{enemy.ChampionName}", $"W On {enemy.ChampionName}", true));
            }

            laneclearMenu = Home.AddSubMenu(prefix + "Lane Clear");
            laneclearMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "Use W", true));
            laneclearMenu.Add(new MenuCheckbox("useE", "Use E", true));
            laneclearMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "LastHit");
            lasthitMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            lasthitMenu.Add(new MenuCheckbox("useW", "Use W", true));
            lasthitMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            autowMenu = Home.AddSubMenu(prefix + "Auto W");
            autowMenu.Add(new MenuCheckbox("autoW", "Enable", false));
            foreach (var enemy in ObjectManager.Heroes.Enemies)
            {
                autowMenu.Add(new MenuCheckbox($"WOn{enemy.ChampionName}", $"Auto W On {enemy.ChampionName}", true));
            }

            fleeMenu = Home.AddSubMenu(prefix + "Flee");
            fleeMenu.Add(new MenuCheckbox("useW", "Use W On Marked", true));
            fleeMenu.Add(new MenuCheckbox("useE", "Use E", false));

            drawingMenu = Home.AddSubMenu(prefix + "Drawings");
            drawingMenu.Add(new MenuCheckbox("enable", "Enable", true));
            drawingMenu.Add(new MenuCheckbox("drawQ", "Draw Q", true));
            drawingMenu.Add(new MenuCheckbox("drawW", "Draw W", true));
            drawingMenu.Add(new MenuCheckbox("drawWm", "Draw W Marked Status", true));
            drawingMenu.Add(new MenuCheckbox("drawAutoW", "Draw Auto W Status", true));
            drawingMenu.Add(new MenuCheckbox("drawE", "Draw E", true));
            drawingMenu.Add(new MenuCheckbox("drawR", "Draw NO R Range", true));

            potMenu = Home.AddSubMenu(prefix + "Potion");
            potMenu.Add(new MenuCheckbox("enable", "Enable Potions", true));
            potMenu.Add(new MenuSlider("hp", "Use at HP% ", 1, 100, 45));

            ssMenu = Home.AddSubMenu(prefix + "Summoner Spells");
            ssMenu.Add(new MenuCheckbox("Heal", "Use Heal", true));
            ssMenu.Add(new MenuSlider("ssheal", "Heal at HP% ", 1, 100, 45));
            ssMenu.Add(new MenuCheckbox("Smite", "Use Smite", true));
            if (IsSummonersRift)
            {
                var small = ssMenu.AddSubMenu("Small Mobs");
                small.Add(new MenuCheckbox("SRU_Gromp", "Gromp").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Razorbeak", "Raptors").SetValue(false));
                small.Add(new MenuCheckbox("Sru_Crab", "Crab").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Krug", "Krug").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Murkwolf", "Wolves").SetValue(false));

                var big = ssMenu.AddSubMenu("Big Mobs");
                big.Add(new MenuCheckbox("SRU_Baron", "Baron Nashor").SetValue(true));
                big.Add(new MenuCheckbox("SRU_RiftHerald", "Rift Herald").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Dragon", "Dragons").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Blue", "Blue Buff").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Red", "Red Buff").SetValue(true));
            }

            killstealMenu = Home.AddSubMenu(prefix + "KillSteal");
            killstealMenu.Add(new MenuCheckbox("enable", "Enable", true));
            killstealMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            killstealMenu.Add(new MenuCheckbox("useW", "Use W", true));
            killstealMenu.Add(new MenuCheckbox("useR", "Use R", true));
            killstealMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 10));

            miscMenu = Home.AddSubMenu(prefix + "Misc");
            miscMenu.Add(new MenuCheckbox("item", "Use Items", true));
            miscMenu.Add(new MenuCheckbox("QSS", "Auto QSS", true));
            miscMenu.Add(new MenuCheckbox("orb", "Use Orbs/Trinkets In Combo", true));
            miscMenu.Add(new MenuCheckbox("blue", "Use Farsigh Orb", true));
            miscMenu.Add(new MenuCheckbox("yellow", "Use Trinket", true));
            miscMenu.Add(new MenuCheckbox("agW", "AntiGapclose W", true));
            miscMenu.Add(new MenuCheckbox("agE", "AntiGapclose E", true));
            miscMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 30));
        }

        public static bool GetCheckbox(this Menu menu, string value)
        {
            return menu.Get<MenuCheckbox>(value).Checked;
        }

        public static bool GetKeybind(this Menu menu, string value)
        {
            return menu.Get<MenuKeybind>(value).Active;
        }

        public static int GetSlider(this Menu menu, string value)
        {
            return menu.Get<MenuSlider>(value).CurrentValue;
        }

        public static int GetCombobox(this Menu menu, string value)
        {
            return menu.Get<MenuCombo>(value).CurrentValue;
        }
    }
}
