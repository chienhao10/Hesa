using HesaEngine.SDK;
using static XuTwitch.MenuManager;
using static XuTwitch.SpellManager;
using static XuTwitch.Main;
using System.Linq;
using HesaEngine.SDK.Enums;
using System.Collections.Generic;

namespace XuTwitch.Modes
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

                foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                    if (Yomamas.IsOwned() && Yomamas.IsReady() && enemy.IsValidTarget(600))
                    {
                        Yomamas.Cast();
                    }
                foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe))
                    if (BOTRK.IsOwned() && BOTRK.IsReady() && enemy.IsValidTarget(BOTRK.Range) || Bilgewater.IsOwned() && Bilgewater.IsReady() && enemy.IsValidTarget(Bilgewater.Range))
                    {
                        BOTRK.Cast(enemy);
                        Bilgewater.Cast(enemy);
                    }

            var qss = miscMenu.GetCheckbox("QSS");

            if (qss && ObjectManager.Player.HasBuffOfType(BuffType.Stun) || ObjectManager.Player.HasBuffOfType(BuffType.Fear) || ObjectManager.Player.HasBuffOfType(BuffType.Charm) || ObjectManager.Player.HasBuffOfType(BuffType.Taunt) || ObjectManager.Player.HasBuffOfType(BuffType.Blind))
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

                var Enemys = ObjectManager.Heroes.Enemies;
                var orb = miscMenu.GetCheckbox("orb");

                if (blue.IsOwned() && blue.IsReady() || Yellow.IsOwned() && Yellow.IsReady())
                    foreach (var target in Enemys)
                    {
                        var lastPos = target.Position;
                        if (!target.IsVisible && orb && (ObjectManager.Player.Position - lastPos).Length() <= 300)
                        {
                        Chat.Print("cant see");
                            if (orb)
                            {
                            Chat.Print("can see");
                            blue.Cast(lastPos);
                                Yellow.Cast(lastPos);
                            }
                        }
                    }
            }
        }
    }