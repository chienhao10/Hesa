using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;

namespace XuJhin.Modes
{
    public static class RTap
    {
        public static void DoRTap()
        {
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var target = TargetSelector.GetTarget(R.Range, TargetSelector.DamageType.Physical);

            if (target != null && ObjectManager.Player.HasBuff("JhinRShot"))
            {
                if (r && target.IsInRange(ObjectManager.Player, 3500))
                {
                    R.PredictionCast(target, HitChance.High);
                    Chat.Print("rtap");
                }
            }
        }
    }
}
