using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;

namespace XuJhin.Modes
{
    public static class RTap
    {
        public static void DoRTap()
        {
            var r = R.IsReady();
            var target = TargetSelector.GetTarget(3500, TargetSelector.DamageType.Physical);
            var ron = rMode.GetCheckbox($"ROn{target.ChampionName}");


            if (target != null && ObjectManager.Player.HasBuff("JhinRShot") && rMode.GetKeybind("rKey"))
            {
                if (r && ron)
                {
                    R.PredictionCast(target, HitChance.High);
                    //Chat.Print("rtap");
                }
            }
        }
    }
}
