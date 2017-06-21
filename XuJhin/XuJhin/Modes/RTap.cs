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
            
            if (target != null && rMode.GetKeybind("rKey") && r && ron)
            {
                //Chat.Print("rtap1");
                Main.Orbwalker.SetMovement(false);
                Main.Orbwalker.SetAttack(false);
                //Chat.Print("rtap2");
                R.PredictionCast(target, HitChance.High);
               // Chat.Print("rtap3");
            }
        }
    }
}
