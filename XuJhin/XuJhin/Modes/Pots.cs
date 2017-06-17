using HesaEngine.SDK;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;
using static XuJhin.Main;
using System.Linq;
using HesaEngine.SDK.Enums;

namespace XuJhin.Modes
{
    public static class Pots
    {
        private static readonly Item Red = new Item(2003);
        private static readonly Item Bis = new Item(2010);
        private static readonly Item Refill = new Item(2031);
        private static readonly Item Jg = new Item(2032);
        private static readonly Item Cp = new Item(2033);
        private static readonly SummonerSpells Heal = new Spell(50);


        private static readonly string[] buffName = { "RegenerationPotion", "ItemMiniRegenPotion", "ItemCrystalFlask", "ItemCrystalFlaskJungle", "ItemDarkCrystalFlask" };

        public static void DoPots()
        {
            var pot = potMenu.GetCheckbox("enable");
            var hp = potMenu.GetSlider("hp");
            var ssheal = potMenu.GetSlider("ssheal");
            var Heal = potMenu.GetCheckbox("Heal");

            if (ObjectManager.Player.GetSpellSlot("SummonerHeal") != SpellSlot.Unknown &&
                ObjectManager.Player.GetSpellSlot("SummonerHeal").IsReady())
            {
                if(Heal && ObjectManager.Player.HealthPercent < ssheal)
                {

                }
            }

                if (pot && !ObjectManager.Player.IsDead && !ObjectManager.Player.IsRecalling())
            {
                if (Red.IsOwned() && Red.IsReady())
                {
                    Red.Cast();
                }
                else if (Bis.IsOwned() && Bis.IsReady())
                {
                    Bis.Cast();
                }
                else if (Refill.IsOwned() && Refill.IsReady())
                {
                    Refill.Cast();
                }
                else if (Cp.IsOwned() && Cp.IsReady())
                {
                    Cp.Cast();
                }
            }
        }
    }
}