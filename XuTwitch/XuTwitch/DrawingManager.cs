using System;
using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static XuTwitch.Main;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;
using static HesaEngine.SDK.Orbwalker;

namespace XuTwitch
{
    public static class DrawingManager
    {
        private static Spell SmiteSpell { get; set; }

        public static void LoadDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
        }
        
        private static void Drawing_OnDraw(EventArgs args)
        {
            if (!drawingMenu.GetCheckbox("enable")) return;

            if (drawingMenu.GetCheckbox("drawQ"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, Q.Range, Color.Yellow);
            }

            if (drawingMenu.GetCheckbox("drawW"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, W.Range, Color.Green);
            }
            if (drawingMenu.GetCheckbox("drawE"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, E.Range, Color.Green);
            }
            if (drawingMenu.GetCheckbox("drawR"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, R.Range, Color.Red);
            }

            var smiteSlot = ObjectManager.Player.Spellbook.Spells.FirstOrDefault(x => x.SpellData.Name.ToLower().Contains("smite"));
            if (smiteSlot != null)
            {
                SmiteSpell = new Spell(smiteSlot.Slot, 570f, TargetSelector.DamageType.True);
            }

            if (drawingMenu.GetCheckbox("drawSmite"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, SmiteSpell.Range, Color.GhostWhite);
            }
            Vector2 ScreenPosition = Drawing.WorldToScreen(ObjectManager.Player.Position);
            Vector2 TextPosition = new Vector2(ScreenPosition.X, ScreenPosition.Y);
            string Chase = "Chase Mode";
            string Flee = "Flee Mode";

           /* if (drawingMenu.GetCheckbox("drawMode"))
            {
                if (chaseMenu.GetKeybind("chaseK"))
                {
                    Drawing.DrawText(TextPosition, Color.Purple, Chase);
                }
                if(Main.Orbwalker.ActiveMode == (OrbwalkingMode.Flee))
                {
                    Drawing.DrawText(TextPosition, Color.Pink, Flee);
                }
            }*/
        }
    }
}
