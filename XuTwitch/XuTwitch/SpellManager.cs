using System;
using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;
using static XuTwitch.MenuManager;

namespace XuTwitch
{
    public static class SpellManager
    {
        public static Spell Q, W, E, R;

        public static void LoadSpells()
        {
            var qr = comboMenu.GetSlider("qRange");
            Q = new Spell(SpellSlot.Q, qr);   
            W = new Spell(SpellSlot.W, 950, damageType:TargetSelector.DamageType.Physical); 
            E = new Spell(SpellSlot.E, 1200); 
            R = new Spell(SpellSlot.R, 975, damageType: TargetSelector.DamageType.Physical);

            W.SetSkillshot(delay: 0.25f, width: 100, speed: 1410, collision: false, type: SkillshotType.SkillshotCircle);

            Main.RPred = new PredictionInput
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
        }
    }
}