using HesaEngine.SDK;
using SharpDX;

namespace XuTwitch
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, chaseMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, fleeMenu, drawingMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu 图奇");


            comboMenu = Home.AddSubMenu(prefix + "连招");
            comboMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            //comboMenu.Add(new MenuSlider("qCount", "Enemy Count to Use Q ", 1, 5, 2));
            comboMenu.Add(new MenuSlider("qRange", "X 范围内敌人使用 Q", 600, 1800, 900));
            comboMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            comboMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            comboMenu.Add(new MenuSlider("eStack", "自动E叠加数 ", 1, 6, 5));
            comboMenu.Add(new MenuCheckbox("useR", "使用 R", false));
            comboMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));

            harassMenu = Home.AddSubMenu(prefix + "骚扰");
            harassMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            harassMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            harassMenu.Add(new MenuSlider("heStack", "自动E叠加数", 1, 6, 4));
            harassMenu.Add(new MenuSlider("mana", "蓝量高于", 10, 100, 50));


            laneclearMenu = Home.AddSubMenu(prefix + "Lane Clear");
            laneclearMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            laneclearMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            laneclearMenu.Add(new MenuSlider("leStack", "自动E叠加数", 1, 6, 4));
            laneclearMenu.Add(new MenuCheckbox("useR", "使用 R", false));
            laneclearMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "尾兵");
            lasthitMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            lasthitMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 50));

            fleeMenu = Home.AddSubMenu(prefix + "逃跑");
            fleeMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            fleeMenu.Add(new MenuCheckbox("useW", "使用 W", false));

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
            miscMenu.Add(new MenuCheckbox("agW", "防突进 W", true));
            miscMenu.Add(new MenuSlider("mana", "蓝量高于 ", 10, 100, 30));
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
