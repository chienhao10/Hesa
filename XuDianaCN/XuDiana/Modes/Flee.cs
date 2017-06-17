using HesaEngine.SDK;
using static XuDiana.SpellManager;
using static XuDiana.MenuManager;
using System.Linq;

namespace XuDiana.Modes
{
    public static class Flee
    {
        public static void DoFlee()
        {
            var q = fleeMenu.GetCheckbox("useQR") && Q.IsReady();
            var w = fleeMenu.GetCheckbox("useW") && W.IsReady();
            var e = fleeMenu.GetCheckbox("useE") && E.IsReady();
            var r = fleeMenu.GetCheckbox("useR") && R.IsReady();
            var QR = Q.ManaCost + R.ManaCost;
            var minion = ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget(Q.Range));
            var Target = ObjectManager.Heroes.Enemies.Where(x => x.IsValidTarget(Q.Range));

            foreach (var t in Target)
            {
                if (fleeMenu.GetCheckbox("fleeE") && Target != null)
                {
                    //Chat.Print("Will FLEE on Enemy");
                    if (q && QR > ObjectManager.Player.ManaPercent && t.IsValidTarget(Q.Range) && t.IsInRange(Game.CursorPosition, 200))
                    {
                        Q.CastIfHitchanceEquals(t, HitChance.High);
                        //Chat.Print("fler1");
                        if (t.HasBuff("dianamoonlight"))
                        {
                            R.Cast(t);
                            //Chat.Print("fler2");
                        }
                    }

                    if (r && t.IsValidTarget(R.Range) && t.IsInRange(Game.CursorPosition, 200))
                    {
                        R.Cast(t);
                        //Chat.Print("fler");
                    }

                    if (w && t.IsValidTarget(W.Range) && ObjectManager.Player.ManaPercent - W.ManaCost > R.ManaCost)
                    {
                        W.Cast();
                        //Chat.Print("flew");
                    }

                    if (e && t.IsValidTarget(E.Range) && ObjectManager.Player.ManaPercent - E.ManaCost > R.ManaCost)
                    {
                        E.Cast();
                        //Chat.Print("flee");
                    }
                }
            }

            foreach (var m in minion)
            {
                if (fleeMenu.GetCheckbox("fleeM") && Target != null)
                {
                    if (q && QR > ObjectManager.Player.ManaPercent && m.IsValidTarget(Q.Range) && m.IsInRange(Game.CursorPosition, 200))
                    {
                        Q.CastIfHitchanceEquals(m, HitChance.High);
                        //Chat.Print("mfler1");
                        if (m.HasBuff("dianamoonlight"))
                        {
                            R.Cast(m);
                            //Chat.Print("mfler2");
                        }
                    }

                    if (r && m.IsValidTarget(R.Range) && m.IsInRange(Game.CursorPosition, 200))
                    {
                        R.Cast(m);
                        //Chat.Print("mfler");
                    }

                    if (w && m.IsValidTarget(W.Range) && ObjectManager.Player.ManaPercent - W.ManaCost > R.ManaCost)
                    {
                        W.Cast();
                        //Chat.Print("mflew");
                    }

                    if (e && m.IsValidTarget(E.Range) && ObjectManager.Player.ManaPercent - E.ManaCost > R.ManaCost)
                    {
                        E.Cast();
                        //Chat.Print("mflee");
                    }
                }
            }
        }
    }
}
