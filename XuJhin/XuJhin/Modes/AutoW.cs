using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using System.Linq;

namespace XuJhin.Modes
{
    public static class AutoW
    {
        public static void DoAutoW()
        {
            var w = autowMenu.GetCheckbox("useW") && W.IsReady();
            var target = TargetSelector.GetTarget(W.Range, TargetSelector.DamageType.Physical);

            if (w && !ObjectManager.Player.HasBuff("JhinRShot") && target != null)
            {
                foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                {
                    if (enemy.IsValidTarget(W.Range))
                    {
                        if (w)
                        {
                            if (enemy.HasBuff("jhinespotteddebuff"))
                            {
                                W.PredictionCast(enemy);
                                Chat.Print("auto w");
                            }
                        }
                    }
                }
            }

        }
    }
}
