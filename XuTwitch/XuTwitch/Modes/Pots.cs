using HesaEngine.SDK;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;
using static XuTwitch.Main;
using System.Linq;
using HesaEngine.SDK.Enums;

namespace XuTwitch.Modes
{
    public static class Pots
    {
        private static readonly Item Red = new Item(2003);
        private static readonly Item Bis = new Item(2010);
        private static readonly Item Refill = new Item(2031);
        private static readonly Item Jg = new Item(2032);
        private static readonly Item Cp = new Item(2033);
        //private static readonly SummonerSpells Heal = new Spell(50);


        private static readonly string[] buffName = { "RegenerationPotion", "ItemMiniRegenPotion", "ItemCrystalFlask", "ItemCrystalFlaskJungle", "ItemDarkCrystalFlask" };

        public static void DoPots()
        {
            var pot = potMenu.GetCheckbox("enable");
            var hp = potMenu.GetSlider("hp");

            if (pot && !ObjectManager.Player.IsDead && !ObjectManager.Player.IsRecalling() && ObjectManager.Player.HasBuffOfType(BuffType.Heal));
            {
                if (pot && !ObjectManager.Player.IsDead && !ObjectManager.Player.IsRecalling())
                {
                    if (Red.IsOwned() && Red.IsReady() && ObjectManager.Player.HealthPercent < hp)
                    {
                        Red.Cast();
                    }
                    else if (Bis.IsOwned() && Bis.IsReady() && ObjectManager.Player.HealthPercent < hp)
                    {
                        Bis.Cast();
                    }
                    else if (Refill.IsOwned() && Refill.IsReady() && ObjectManager.Player.HealthPercent < hp)
                    {
                        Refill.Cast();
                    }
                    else if (Cp.IsOwned() && Cp.IsReady() && ObjectManager.Player.HealthPercent < hp)
                    {
                        Cp.Cast();
                    }
                }

            }
        }
    }
}