using System;
using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using XuJhin.Modes;

namespace XuJhin
{
    public static class SpellManager
    {
        public static Spell Q, W, E, R;

        public static void LoadSpells()
        {
            Q = new Spell(SpellSlot.Q, 600, damageType: TargetSelector.DamageType.Physical);
            W = new Spell(SpellSlot.W, 2500, damageType:TargetSelector.DamageType.Physical); 
            E = new Spell(SpellSlot.E, 750, damageType: TargetSelector.DamageType.Physical);
            R = new Spell(SpellSlot.R, 3500, damageType: TargetSelector.DamageType.Physical);

            
            W.SetSkillshot(delay: 0.75f, width: 40, speed: 10000, collision: false, type: SkillshotType.SkillshotLine);
            E.SetSkillshot(delay: 0.25f, width: 120, speed: 1600, collision: false, type: SkillshotType.SkillshotCircle);
            R.SetSkillshot(delay: 0.24f, width: 80, speed: 5000, collision: false, type: SkillshotType.SkillshotCone);

            Main.QPred = new PredictionInput
            {
                CollisionObjects = new[]
                {
                    CollisionableObjects.YasuoWall
                }
            };

            Main.WPred = new PredictionInput
            {
                Delay = W.Delay,
                Radius = W.Width,
                Speed = W.Speed,
                Type = W.Type,
                CollisionObjects = new[]
                {
                    CollisionableObjects.YasuoWall
                }
            };

            Main.EPred = new PredictionInput
            {
                Delay = E.Delay,
                Radius = E.Width,
                Speed = E.Speed,
                Type = E.Type,
                CollisionObjects = new[]
                {
                    CollisionableObjects.YasuoWall
                }
            };

            Main.RPred = new PredictionInput
            {
                Delay = R.Delay,
                Radius = R.Width,
                Speed = R.Speed,
                Type = R.Type,
                CollisionObjects = new[]
                {
                    CollisionableObjects.YasuoWall
                }
            };
        }
    }
}