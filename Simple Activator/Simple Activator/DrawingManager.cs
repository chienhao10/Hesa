using System;
using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static SimpleActivator.Main;
using static SimpleActivator.MenuManager;
using static HesaEngine.SDK.Orbwalker;

namespace SimpleActivator
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

            var smiteSlot = ObjectManager.Player.Spellbook.Spells.FirstOrDefault(x => x.SpellData.Name.ToLower().Contains("smite"));
            if (smiteSlot != null)
            {
                SmiteSpell = new Spell(smiteSlot.Slot, 570f, TargetSelector.DamageType.True);
            }

            if (drawingMenu.GetCheckbox("drawSmite") && SmiteSpell != null && SmiteSpell.IsReady())
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
