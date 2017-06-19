using HesaEngine.SDK;
using SharpDX;

namespace XuDiana
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, chaseMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, fleeMenu, potMenu, drawingMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu Diana");


            comboMenu = Home.AddSubMenu(prefix + "Combo");
            comboMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            comboMenu.Add(new MenuCheckbox("useW", "Use W", true));
            comboMenu.Add(new MenuCheckbox("useE", "Use E", true));
            comboMenu.Add(new MenuCheckbox("useR", "Use R", true));
            comboMenu.Add(new MenuCheckbox("useR2", "Use R2", false));
            comboMenu.Add(new MenuCheckbox("useRgap", "Use R Gap Close", true));
            comboMenu.Add(new MenuCheckbox("useRbuff", "Use R Only R Moonlight Target", false));
            comboMenu.Add(new MenuKeybind("advK", "Advanced Combo Key", SharpDX.DirectInput.Key.L));
            comboMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            //Chase Combo
            chaseMenu = Home.AddSubMenu(prefix + "Chase Combo");
            chaseMenu.Add(new MenuKeybind("chaseK", "Chase Combo Key", SharpDX.DirectInput.Key.G));
            chaseMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            chaseMenu.Add(new MenuCheckbox("useW", "Use W", true));
            chaseMenu.Add(new MenuCheckbox("useE", "Use E", true));
            chaseMenu.Add(new MenuCheckbox("useR", "Use R", true));
            chaseMenu.Add(new MenuSlider("minRe", "Minium Range To E", 10, 450, 420));
            chaseMenu.Add(new MenuSlider("minRr", "Minium Range To R", 10, 800, 825));

            harassMenu = Home.AddSubMenu(prefix + "Harass");
            harassMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            harassMenu.Add(new MenuCheckbox("useW", "Use W", true));
            harassMenu.Add(new MenuCheckbox("useE", "Use E", true));
            harassMenu.Add(new MenuCheckbox("useR", "Use R", false));
            harassMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            laneclearMenu = Home.AddSubMenu(prefix + "Lane Clear");
            laneclearMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "Use W", true));
            laneclearMenu.Add(new MenuCheckbox("useE", "Use E", false));
            laneclearMenu.Add(new MenuCheckbox("useR", "Use R", true));
            laneclearMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "LastHit");
            lasthitMenu.Add(new MenuCheckbox("useQ", "Use Q", true));
            lasthitMenu.Add(new MenuCheckbox("useW", "Use W", true));
            lasthitMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 50));

            fleeMenu = Home.AddSubMenu(prefix + "Flee");
            fleeMenu.Add(new MenuCheckbox("useQR", "Use QR", true));
            fleeMenu.Add(new MenuCheckbox("useW", "Use W", true));
            fleeMenu.Add(new MenuCheckbox("useE", "Use E", true));
            fleeMenu.Add(new MenuCheckbox("useR", "Use R", true));
            fleeMenu.Add(new MenuCheckbox("fleeE", "Flee On Enemy", true));
            fleeMenu.Add(new MenuCheckbox("fleeM", "Flee On Minions/Mobs", true));

            potMenu = Home.AddSubMenu(prefix + "Heal");
            potMenu.Add(new MenuCheckbox("enable", "Enable Potions", true));
            potMenu.Add(new MenuSlider("hp", "Use at HP% ", 1, 100, 45));
            //potMenu.Add(new MenuCheckbox("Heal", "Use Heal", true));
            //potMenu.Add(new MenuSlider("ssheal", "Heal at HP% ", 1, 100, 45));


            drawingMenu = Home.AddSubMenu(prefix + "Drawings");
            drawingMenu.Add(new MenuCheckbox("enable", "Enable", true));
            drawingMenu.Add(new MenuCheckbox("drawQ", "Draw Q", true));
            drawingMenu.Add(new MenuCheckbox("drawW", "Draw W", true));
            drawingMenu.Add(new MenuCheckbox("drawE", "Draw E", true));
            drawingMenu.Add(new MenuCheckbox("drawR", "Draw R", true));
            drawingMenu.Add(new MenuCheckbox("drawMode", "Draw Modes", true));

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
            miscMenu.Add(new MenuCheckbox("agW", "AntiGapclose W", true));
            miscMenu.Add(new MenuCheckbox("agE", "AntiGapclose E", true));
            miscMenu.Add(new MenuSlider("mana", "Mana % must be >= ", 10, 100, 30));
            /*miscMenu.Add(new MenuCheckbox("level", "Enable Spell Leveler", true));
            miscMenu.Add(new MenuSlider("levelDelay", "Level UP Delay", 10, 1000, 200));
            miscMenu.Add(new MenuCombo("levelFirst", "Level UP First", new[] { "Q", "W", "E" }));
            miscMenu.Add(new MenuCombo("levelSecond", "Level UP Second", new[] { "Q", "W", "E" }, 1));
            miscMenu.Add(new MenuCombo("levelThird", "Level UP Third", new[] { "Q", "W", "E" }, 2));*/
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
