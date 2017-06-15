using HesaEngine.SDK;
using SharpDX;

namespace XuDiana
{
    public static class MenuManager
    {
        public static Menu Home, comboMenu, chaseMenu, harassMenu, autoharassMenu, laneclearMenu, lasthitMenu, fleeMenu, drawingMenu, miscMenu, killstealMenu;
        
        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu 皎月");


            comboMenu = Home.AddSubMenu(prefix + "连招");
            comboMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            comboMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            comboMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            comboMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            comboMenu.Add(new MenuCheckbox("useR2", "使用 R2", false));
            comboMenu.Add(new MenuCheckbox("useRgap", "使用R突进", false));
            comboMenu.Add(new MenuCheckbox("useRbuff", "只对Q Buff敌人使用R", false));
            comboMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 50));

            //Chase Combo
            chaseMenu = Home.AddSubMenu(prefix + "追杀模式");
            chaseMenu.Add(new MenuKeybind("chaseK", "追杀按键", SharpDX.DirectInput.Key.G));
            chaseMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            chaseMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            chaseMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            chaseMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            chaseMenu.Add(new MenuSlider("minRe", "最低距离使用 E", 10, 450, 420));
            chaseMenu.Add(new MenuSlider("minRr", "最低距离使用 To R", 10, 800, 825));

            harassMenu = Home.AddSubMenu(prefix + "骚扰");
            harassMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            harassMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            harassMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            harassMenu.Add(new MenuCheckbox("useR", "使用 R", false));
            harassMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 50));


            laneclearMenu = Home.AddSubMenu(prefix + "清线");
            laneclearMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            laneclearMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            laneclearMenu.Add(new MenuCheckbox("useE", "使用 E", false));
            laneclearMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            laneclearMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 50));


            lasthitMenu = Home.AddSubMenu(prefix + "尾兵");
            lasthitMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            lasthitMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            lasthitMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 50));

            fleeMenu = Home.AddSubMenu(prefix + "逃跑");
            fleeMenu.Add(new MenuCheckbox("useQR", "使用 QR", true));
            fleeMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            fleeMenu.Add(new MenuCheckbox("useE", "使用 E", true));
            fleeMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            fleeMenu.Add(new MenuCheckbox("fleeE", "利用敌人逃跑", true));
            fleeMenu.Add(new MenuCheckbox("fleeM", "利用小兵/野怪逃跑", true));

            drawingMenu = Home.AddSubMenu(prefix + "线圈");
            drawingMenu.Add(new MenuCheckbox("enable", "启用", true));
            drawingMenu.Add(new MenuCheckbox("drawQ", "显示 Q", true));
            drawingMenu.Add(new MenuCheckbox("drawW", "显示 W", true));
            drawingMenu.Add(new MenuCheckbox("drawE", "显示 E", true));
            drawingMenu.Add(new MenuCheckbox("drawR", "显示 R", true));
            drawingMenu.Add(new MenuCheckbox("drawMode", "显示当前模式", true));

            killstealMenu = Home.AddSubMenu(prefix + "抢头");
            killstealMenu.Add(new MenuCheckbox("enable", "启用", true));
            killstealMenu.Add(new MenuCheckbox("useQ", "使用 Q", true));
            killstealMenu.Add(new MenuCheckbox("useW", "使用 W", true));
            killstealMenu.Add(new MenuCheckbox("useR", "使用 R", true));
            killstealMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 10));

            miscMenu = Home.AddSubMenu(prefix + "杂项");
            miscMenu.Add(new MenuCheckbox("agW", "防突进 W", true));
            miscMenu.Add(new MenuCheckbox("agE", "防突进 E", true));
            miscMenu.Add(new MenuSlider("mana", "蓝量必须 >= ", 10, 100, 30));
            miscMenu.Add(new MenuCheckbox("level", "启用自动加点", true));
            miscMenu.Add(new MenuSlider("levelDelay", "加点延迟", 10, 1000, 200));
            miscMenu.Add(new MenuCombo("levelFirst", "第一加点", new[] { "Q", "W", "E" }));
            miscMenu.Add(new MenuCombo("levelSecond", "第二加点", new[] { "Q", "W", "E" }, 1));
            miscMenu.Add(new MenuCombo("levelThird", "第三加点", new[] { "Q", "W", "E" }, 2));
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
