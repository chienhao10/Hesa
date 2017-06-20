using HesaEngine.SDK;
using static SimpleActivator.MenuManager;
using static SimpleActivator.Main;
using System.Linq;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using SharpDX;

namespace SimpleActivator.Modes
{
    public static class SS
    {
        //private static readonly SummonerSpells Heal = new Spell(50);
        private static Spell HealSpell { get; set; }
        private static Spell SmiteSpell { get; set; }
        private static Obj_AI_Minion mobs;

        private static readonly string[] SmiteMobs =
        {
            "SRU_Red", "SRU_Blue", "SRU_Dragon_Water", "SRU_Dragon_Fire", "SRU_Dragon_Earth", "SRU_Dragon_Air",
            "SRU_Dragon_Elder", "SRU_Baron", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak", "SRU_RiftHerald", "SRU_Krug",
            "Sru_Crab", "TT_Spiderboss", "TT_NGolem", "TT_NWolf", "TT_NWraith"
        };
        private static readonly string[] buffName = { "RegenerationPotion", "ItemMiniRegenPotion", "ItemCrystalFlask", "ItemCrystalFlaskJungle", "ItemDarkCrystalFlask" };

        public static void DoHeal()
        {
            var heal = ssMenu.GetCheckbox("Heal");
            var hp = ssMenu.GetSlider("ssheal");
            var healSlot = ObjectManager.Player.Spellbook.Spells.FirstOrDefault(x => x.SpellData.Name.ToLower().Contains("heal"));

            if (healSlot != null)
            {
                HealSpell = new Spell(healSlot.Slot, 850);
            }
            if (heal && ObjectManager.Player.HealthPercent < hp && HealSpell.IsReady())
            {
                HealSpell.Cast();
            }

            /*var hally = ssMenu.GetCheckbox("HealA");
            var ahp = ssMenu.GetSlider("aHP");
            if (healSlot != null)
            {
                HealSpell = new Spell(healSlot.Slot, 850);
            }
            if (hally &&  ally < ahp && HealSpell.IsReady())
            {
                HealSpell.Cast();
            }*/
        }

        public static void DoSmite()
        {
            var smiteSlot = ObjectManager.Player.Spellbook.Spells.FirstOrDefault(x => x.SpellData.Name.ToLower().Contains("smite"));
            if (smiteSlot == null)
                return;

                if (smiteSlot != null)
            {
                SmiteSpell = new Spell(smiteSlot.Slot, 570f, TargetSelector.DamageType.True);
            }
            
            mobs = MinionManager.GetMinions(ObjectManager.Player.ServerPosition,570f, MinionTypes.All, MinionTeam.Neutral).FirstOrDefault(buff => buff.Name.StartsWith(buff.CharData.BaseSkinName)
                    && SmiteMobs.Contains(buff.CharData.BaseSkinName) && !buff.Name.Contains("Mini") && !buff.Name.Contains("Spawn"));

            if (mobs != null)
            {
                if (ssMenu.Get<MenuCheckbox>(mobs.CharData.BaseSkinName).Checked)
                {
                    if (SmiteSpell.IsReady())
                    {
                        if (Vector3.Distance(ObjectManager.Player.ServerPosition, mobs.ServerPosition) <= 570 && mobs.IsValidTarget(SmiteSpell.Range))
                        {
                            if (ObjectManager.Player.GetSummonerSpellDamage(mobs, Damage.SummonerSpell.Smite) >=
                                mobs.Health && SmiteSpell.CanCast(mobs))
                            {
                                ObjectManager.Player.Spellbook.CastSpell(SmiteSpell.Slot, mobs);
                                Logger.Log("Smited!");
                            }

                        }
                    }
                }
            }
            else if (ssMenu.Get<MenuCheckbox>("SRU_Dragon").Checked)
            {
                if (SmiteSpell.IsReady())
                {

                    if (ObjectManager.Dragon != null && ObjectManager.Dragon.IsInRange(ObjectManager.Player, 570))
                    {
                        if (ObjectManager.Player.GetSummonerSpellDamage(ObjectManager.Dragon,
                                Damage.SummonerSpell.Smite) >= ObjectManager.Dragon.Health &&
                            SmiteSpell.CanCast(ObjectManager.Dragon))
                        {
                            ObjectManager.Player.Spellbook.CastSpell(SmiteSpell.Slot, ObjectManager.Dragon);
                        }
                    }
                }
            }
            else
            {
                SmiteKill();
            }
        }

        private static void SmiteKill()
        {
            if (!ssMenu.Get<MenuCheckbox>("SmiteKS").Checked)
            {
                return;
            }

            var smiteableEnemy = TargetSelector.GetTarget(570, TargetSelector.DamageType.True);
            if (smiteableEnemy == null)
            {
                return;
            }
            else if (20 + 8 * ObjectManager.Me.Level >= smiteableEnemy.Health)
            {
                SmiteSpell.Cast(smiteableEnemy);
                Logger.Log("Smited!");
            }


        }
    }
}