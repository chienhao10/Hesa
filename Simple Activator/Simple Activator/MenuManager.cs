using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using SharpDX;

namespace SimpleActivator
{
    public static class MenuManager
    {
        public static Menu Home, itemMenu, orbMenu, potMenu, ssMenu, qssMenu, drawingMenu;

        public static bool IsSummonersRift => Game.MapId == GameMapId.SummonersRift;
        public static bool IsTwistedTreeline => Game.MapId == GameMapId.TwistedTreeline;

        private static string prefix = " - ";

        public static void LoadMenu()
        {
            Home = Menu.AddMenu("Xu Simple Activator");

            itemMenu = Home.AddSubMenu(prefix + "Item Usage");
            itemMenu.Add(new MenuCheckbox("enable", "Enable", true));
            itemMenu.Add(new MenuCheckbox("yo", "Use Yomamas", true));
            itemMenu.Add(new MenuCheckbox("bok", "Use Bilgewater && Blade of the Ruined King", true));
            itemMenu.Add(new MenuCheckbox("ti", "Use Tiamat", true));
            itemMenu.Add(new MenuCheckbox("rh", "Use Ravenous Hydra", true));
            itemMenu.Add(new MenuCheckbox("th", "Use Titanic Hydra", true));
            itemMenu.Add(new MenuSeparator("Hydras, Timat Will use In LaneClear"));

            orbMenu = Home.AddSubMenu(prefix + "Trinkets");
            orbMenu.Add(new MenuCheckbox("enable", "Enable In Combo", true));
            orbMenu.Add(new MenuCheckbox("blue", "Use Blue Orb", true));
            orbMenu.Add(new MenuCheckbox("yellow", "Use Yellow Trinket", true));

            potMenu = Home.AddSubMenu(prefix + "Potions");
            potMenu.Add(new MenuCheckbox("enable", "Enable Potions", true));
            potMenu.Add(new MenuSlider("hp", "Use at HP% ", 1, 100, 45));

            ssMenu = Home.AddSubMenu(prefix + "Summoner Spells");
            ssMenu.Add(new MenuCheckbox("Heal", "Enable Heal", true));
            ssMenu.Add(new MenuSlider("ssheal", "Heal at HP% ", 1, 100, 45));
            //ssMenu.Add(new MenuCheckbox("HealA", "Use Heal On Ally", false));
            //ssMenu.Add(new MenuSlider("aHP", "Heal Ally at HP% ", 1, 100, 45));
            ssMenu.Add(new MenuCheckbox("Smite", "Use Smite", true));
            ssMenu.Add(new MenuCheckbox("SmiteKS", "Smite KS", true));
            if (IsSummonersRift)
            {
                var small = ssMenu.AddSubMenu("Small Mobs");
                small.Add(new MenuCheckbox("SRU_Gromp", "Gromp").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Razorbeak", "Raptors").SetValue(false));
                small.Add(new MenuCheckbox("Sru_Crab", "Crab").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Krug", "Krug").SetValue(false));
                small.Add(new MenuCheckbox("SRU_Murkwolf", "Wolves").SetValue(false));
                small.Add(new MenuSeparator(""));
                var big = ssMenu.AddSubMenu("Big Mobs");
                big.Add(new MenuCheckbox("SRU_Baron", "Baron Nashor").SetValue(true));
                big.Add(new MenuCheckbox("SRU_RiftHerald", "Rift Herald").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Dragon", "Dragons").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Blue", "Blue Buff").SetValue(true));
                big.Add(new MenuCheckbox("SRU_Red", "Red Buff").SetValue(true));
            }

            qssMenu = Home.AddSubMenu(prefix + "QSS");
            //miscMenu.Add(new MenuCheckbox("recallq", "Recall Q", true));
            qssMenu.Add(new MenuCheckbox("enable", "Enable QSS", true));
            qssMenu.Add(new MenuCheckbox("stun", "Stun", true));
            qssMenu.Add(new MenuCheckbox("charm", "Charm", true));
            qssMenu.Add(new MenuCheckbox("Silence", "Silence", true));
            qssMenu.Add(new MenuCheckbox("Snare", "Snare", true));
            qssMenu.Add(new MenuCheckbox("Slow", "Slow", true));
            qssMenu.Add(new MenuCheckbox("Suppression", "Suppression", true));
            qssMenu.Add(new MenuCheckbox("Poison", "Poison", true));
            qssMenu.Add(new MenuCheckbox("Polymorph", "Polymorph", true));
            qssMenu.Add(new MenuCheckbox("blind", "Blind", true));
            qssMenu.Add(new MenuCheckbox("taunt", "Taunt", true));
            qssMenu.Add(new MenuCheckbox("fear", "Fear", true));

            drawingMenu = Home.AddSubMenu(prefix + "Drawings");
            drawingMenu.Add(new MenuCheckbox("enable", "Enable", true));
            drawingMenu.Add(new MenuCheckbox("drawSmite", "Draw Smite Range", true));
            //drawingMenu.Add(new MenuCheckbox("drawMode", "Draw Q Count Down", true));
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
