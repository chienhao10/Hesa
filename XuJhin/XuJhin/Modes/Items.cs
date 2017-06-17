using HesaEngine.SDK;
using static XuJhin.MenuManager;
using static XuJhin.SpellManager;
using static XuJhin.Main;
using System.Linq;
using HesaEngine.SDK.Enums;
using System.Collections.Generic;

namespace XuJhin.Modes
{
    public static class Items
    {
        private static readonly Item BOTRK = new Item(3153, 550);
        private static readonly Item Bilgewater = new Item(3144, 550);
        private static readonly Item Yomamas = new Item(3142, 400);
        private static readonly Item Mercurial = new Item(3139, 22000);
        private static readonly Item QSS = new Item(3140, 22000);
        private static readonly Item Dervish = new Item(3137, 0);
        private static readonly Item blue = new Item(3363, 4000);
        private static readonly Item Yellow = new Item(3340, 600);

        public static void DoItems()
        {
            var item = miscMenu.GetCheckbox("item");
            //var orb = miscMenu.GetCheckbox("orb");

            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                if(Yomamas.IsOwned() && Yomamas.IsReady() && enemy.IsValidTarget(600))
                {
                    Yomamas.Cast();
                }
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                if (BOTRK.IsOwned() && BOTRK.IsReady() && enemy.IsValidTarget(BOTRK.Range) || Bilgewater.IsOwned() && Bilgewater.IsReady() && enemy.IsValidTarget(Bilgewater.Range))
                {
                    BOTRK.Cast(enemy);
                    Bilgewater.Cast(enemy);
                }
            if (ObjectManager.Player.HasBuffOfType(BuffType.Stun) || ObjectManager.Player.HasBuffOfType(BuffType.Fear) || ObjectManager.Player.HasBuffOfType(BuffType.Charm) || ObjectManager.Player.HasBuffOfType(BuffType.Taunt) || ObjectManager.Player.HasBuffOfType(BuffType.Blind))
            {
                if (Mercurial.IsReady() && Mercurial.IsOwned())
                {
                    Mercurial.Cast();
                }
                if (QSS.IsReady() && QSS.IsOwned())
                {
                    QSS.Cast();
                }
                if (Dervish.IsReady() && Dervish.IsOwned())
                {
                    Dervish.Cast();
                }
            }
            /*
            if (orb && blue.IsOwned() && blue.IsReady() || Yellow.IsOwned() && Yellow.IsReady()))
            {

                foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                {
                    if (Game.GameTimeTickCount >= delayer)
                    {

                        epos.Add(enemy.Position);
                        delayer = Game.GameTimeTickCount + 10;
                    }

                    {
                        if ((enemy.Position - lastPos) <= GetRRange())
                        {
                            blue.Cast(lastPos);
                        }
                        if ((enemy.Position - lastPos) <= GetRRange())
                        {
                            Yellow.Cast(lastPos);
                        }
                    }
                }
            }*/
        }
    }
}