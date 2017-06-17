using System;
using System.Linq;
using HesaEngine.SDK;
using SharpDX;
using static XuJhin.Main;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;
using static HesaEngine.SDK.Orbwalker;

namespace XuJhin
{
    public static class DrawingManager
    {
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
                Drawing.DrawCircle(ObjectManager.Me.Position, W.Range, Color.Yellow, 1);
            }
            if (drawingMenu.GetCheckbox("drawE"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, E.Range, Color.White);
            }
            if (drawingMenu.GetCheckbox("drawR"))
            {
                Drawing.DrawCircle(ObjectManager.Me.Position, R.Range, Color.Red, 3);
            }

            Vector2 ScreenPosition = Drawing.WorldToScreen(ObjectManager.Player.Position);
            Vector2 TextPosition = new Vector2(ScreenPosition.X, ScreenPosition.Y);
            string Wbuff = "W Marked";
            string Autow = "Auto W On";

           if (drawingMenu.GetCheckbox("autoW"))
            {
                Drawing.DrawText(TextPosition, Color.Pink, Autow);
            }
            if (drawingMenu.GetCheckbox("useWbuff"))
            {
                Drawing.DrawText(TextPosition - 30, Color.Pink, Wbuff);
            }
        }
    }
}
