using System;
using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using static XuDiana.MenuManager;

namespace XuDiana
{
    public static class SpellManager
    {
        public static Spell Q, W, E, R;

        public static void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 900, damageType: TargetSelector.DamageType.Magical);   
            W = new Spell(SpellSlot.W, 200, damageType:TargetSelector.DamageType.Magical); 
            E = new Spell(SpellSlot.E, 450); 
            R = new Spell(SpellSlot.R, 825, damageType: TargetSelector.DamageType.Magical);

            Q.SetSkillshot(delay: 0.25f, width: 185, speed: 1620, collision: false, type: SkillshotType.SkillshotCircle);

            Main.QPred = new PredictionInput
            {
                Delay = Q.Delay,
                Radius = Q.Width,
                Speed = Q.Speed,
                Type = Q.Type,
                CollisionObjects = new[]
                {
                    CollisionableObjects.YasuoWall
                }
            };
        }
    }
}