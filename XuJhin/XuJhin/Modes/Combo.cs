using HesaEngine.SDK;
using static XuJhin.SpellManager;
using static XuJhin.MenuManager;
using static XuJhin.Main;
using System.Linq;
using HesaEngine.SDK.GameObjects;
using HesaEngine.SDK.Enums;

namespace XuJhin.Modes
{
    public static class Combo
    {
        public static void DoCombo()
        {
            var r = comboMenu.GetCheckbox("useR") && R.IsReady();
            var rtarget = TargetSelector.GetTarget(GetRRange(), TargetSelector.DamageType.Physical);

            if (rtarget.IsValidTarget() && r)
            {
                if (ObjectManager.Player.HasBuff("JhinRShot"))
                {
                    Main.Orbwalker.SetMovement(false);
                    Main.Orbwalker.SetAttack(false);
                    R.Cast(rtarget);
                    Chat.Print("rtarget");
                    return;
                }
                else
                {
                    R.Cast(rtarget);
                    Chat.Print("ron");
                }
            }

            if(ObjectManager.Player.HasBuff("JhinRShot")) return;

            var q = comboMenu.GetCheckbox("useQ") && Q.IsReady();
           
            var qtarget = TargetSelector.GetTarget(Q.Range, TargetSelector.DamageType.Physical);
           

            if (qtarget.IsValidTarget() && !ObjectManager.Player.HasBuff("JhinRShot") && q)
            {
                Chat.Print("Q");
                Q.Cast(qtarget);
            }
            var e = comboMenu.GetCheckbox("useE") && E.IsReady();
            var etarget = TargetSelector.GetTarget(E.Range, TargetSelector.DamageType.Physical);
            if (e && etarget.IsValidTarget(E.Range) && !ObjectManager.Player.HasBuff("JhinRShot"))
            {
                Chat.Print("E");
                E.Cast(etarget.Position);
            }
            
            
            //var won = comboMenu.GetCheckbox($"WOn{wtarget.ChampionName}");
            var wbuff = comboMenu.GetCheckbox("useWbuff");
            var w = comboMenu.GetCheckbox("useW") && W.IsReady();
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x =>x.IsValidTarget(W.Range) && comboMenu.GetCheckbox("WOn" + x.ChampionName) && !ObjectManager.Player.HasBuff("JhinRShot")))
            {
                if (w && wbuff && enemy.HasBuff("jhinespotteddebuff") )
                {
                    W.PredictionCast(enemy);
                    Chat.Print("w buff1");
                }
                if (w && !wbuff)
                {
                    W.PredictionCast(enemy);
                    Chat.Print("w buff2");
                }
            }
        }
    }
}
