using HesaEngine.SDK;
using SharpDX;

namespace XuTwitch
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, chaseMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, fleeMenu, potMenu, drawingMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu 图奇");


            comboMenu = Home.AddSubMenu(prefix + "连招");
            comboMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            //comboMenu.Add(new MenuSlider("qCount", "Enemy Count to Use Q ", 1, 5, 2));
            comboMenu.Add(new MenuSlider("qRange", "X范围有敌人使用 Q", 600, 1800, 900));
            comboMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            comboMenu.Add(new MenuCheckbox("useE", "使用 E", false));
            comboMenu.Add(new MenuSlider("eStack", "毒层数使用 E ", 1, 6, 5));
            comboMenu.Add(new MenuCheckbox("useR", "使用 R", false));
            comboMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));

            harassMenu = Home.AddSubMenu(prefix + "骚扰");
            harassMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            harassMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            harassMenu.Add(new MenuSlider("heStack", "毒层数使用 E ", 1, 6, 4));
            harassMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));


            laneclearMenu = Home.AddSubMenu(prefix + "清线");
            laneclearMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            laneclearMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            laneclearMenu.Add(new MenuSlider("eNumber", "X 小兵能被杀死使用 E ", 1, 16, 3));
            laneclearMenu.Add(new MenuSlider("leStack", "毒层数使用 E ", 1, 6, 4));
            laneclearMenu.Add(new MenuCheckbox("useR", "使用 R", false));
            laneclearMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "尾兵");
            lasthitMenu.Add(new MenuCheckbox("useE", "使用 E", false));
            lasthitMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));

            fleeMenu = Home.AddSubMenu(prefix + "逃跑");
            fleeMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            fleeMenu.Add(new MenuCheckbox("useW", "使用 W", false));

            potMenu = Home.AddSubMenu(prefix + "治疗");
            potMenu.Add(new MenuCheckbox("enable", "启用药水", true));
            potMenu.Add(new MenuSlider("hp", "HP% 低于时使用", 1, 100, 45));
            //potMenu.Add(new MenuCheckbox("Heal", "Use Heal", true));
            //potMenu.Add(new MenuSlider("ssheal", "Heal at HP% ", 1, 100, 45));

            drawingMenu = Home.AddSubMenu(prefix + "线圈");
            drawingMenu.Add(new MenuCheckbox("enable", "启用", true));
            drawingMenu.Add(new MenuCheckbox("drawQ", "显示 Q", true));
            drawingMenu.Add(new MenuCheckbox("drawW", "显示 W", true));
            drawingMenu.Add(new MenuCheckbox("drawE", "显示 E", true));
            drawingMenu.Add(new MenuCheckbox("drawR", "显示 R", true));
            //drawingMenu.Add(new MenuCheckbox("drawMode", "Draw Q Count Down", true));

            killstealMenu = Home.AddSubMenu(prefix + "抢头");
            killstealMenu.Add(new MenuCheckbox("enable", "启用", true));
            killstealMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            killstealMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            killstealMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 10));

            miscMenu = Home.AddSubMenu(prefix + "杂项");
            //miscMenu.Add(new MenuCheckbox("recallq", "Recall Q", true));
            miscMenu.Add(new MenuCheckbox("item", "使用物品", true));
            miscMenu.Add(new MenuCheckbox("QSS", "自动净化", true));
            miscMenu.Add(new MenuCheckbox("orb", "连招和逃跑时使用蓝色饰品/眼", true));
            miscMenu.Add(new MenuCheckbox("agW", "防突进 W", true));
            miscMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 30));
            //miscMenu.Add(new MenuCheckbox("save", "Always Save Mana For E", true));
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
