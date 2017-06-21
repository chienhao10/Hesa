using HesaEngine.SDK;
using static SimpleActivator.MenuManager;
using static SimpleActivator.Main;
using System.Linq;
using HesaEngine.SDK.Enums;
using System.Collections.Generic;

namespace SimpleActivator.Modes
{
    public static class Items
        {
        private static readonly Item BOTRK = new Item(3153, 550);
        private static readonly Item Bilgewater = new Item(3144, 550);
        private static readonly Item Yomamas = new Item(3142, 400);
        private static readonly Item Mercurial = new Item(3139, 22000);
        private static readonly Item QSS = new Item(3140, 22000);
        private static readonly Item Dervish = new Item(3137, 0);
        private static readonly Item rhydra = new Item(3074, 350);
        private static readonly Item thydra = new Item(3748, 0);
        private static readonly Item timat = new Item(3077, 400);

        private static readonly Item blue = new Item(3363, 4000);
        private static readonly Item Yellow = new Item(3340, 600);

        public static void DoItems()
        {
            var yo = itemMenu.GetCheckbox("yo");
            var rh = itemMenu.GetCheckbox("rh");
            var ti = itemMenu.GetCheckbox("ti");
            var th = itemMenu.GetCheckbox("th");
            var bok = itemMenu.GetCheckbox("bok");

            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x != null))
                if (yo && Yomamas.IsOwned() && Yomamas.IsReady() && enemy.IsValidTarget(600))
                {
                    Yomamas.Cast();
                }
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x != null))
                if (rh && rhydra.IsOwned() && rhydra.IsReady() && enemy.IsValidTarget(350))
                {
                    rhydra.Cast();
                }
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x != null))
                if (ti && timat.IsOwned() && timat.IsReady() && enemy.IsValidTarget(400))
                {
                    timat.Cast();
                }
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x != null))
                if (th && thydra.IsOwned() && thydra.IsReady() && enemy.IsValidTarget(ObjectManager.Player.AttackRange))
                {
                    thydra.Cast();
                }
            foreach (var enemy in ObjectManager.Heroes.Enemies.Where(x => !x.IsAlly && !x.IsMe && x != null))
                if (bok && BOTRK.IsOwned() && BOTRK.IsReady() && enemy.IsValidTarget(BOTRK.Range) || bok && Bilgewater.IsOwned() && Bilgewater.IsReady() && enemy.IsValidTarget(Bilgewater.Range))
                {
                    BOTRK.Cast(enemy);
                    Bilgewater.Cast(enemy);
                }
        }

        public static void DoQss()
        {
            var qss = qssMenu.GetCheckbox("enable");
            var stun = qssMenu.GetCheckbox("stun");
            var fear = qssMenu.GetCheckbox("fear");
            var charm = qssMenu.GetCheckbox("charm");
            var taunt = qssMenu.GetCheckbox("taunt");
            var blind = qssMenu.GetCheckbox("blind");
            var Poison = qssMenu.GetCheckbox("Poison");
            var Polymorph = qssMenu.GetCheckbox("Polymorph");
            var Silence = qssMenu.GetCheckbox("Silence");
            var Snare = qssMenu.GetCheckbox("Snare");
            var Suppression = qssMenu.GetCheckbox("Suppression");
            var Slow = qssMenu.GetCheckbox("Slow");

            if (qss && Slow && ObjectManager.Player.HasBuffOfType(BuffType.Slow))
            {
                Chat.Print("slowed");
                if (Mercurial.IsReady() && Mercurial.IsOwned())
                {
                    Mercurial.Cast();
                    //Chat.Print("no1");

                }
                if (QSS.IsReady() && QSS.IsOwned())
                {
                    QSS.Cast();
                    //Chat.Print("no2");

                }
                if (Dervish.IsReady() && Dervish.IsOwned())
                {
                    Dervish.Cast();
                }
            }
            if (qss && Suppression && ObjectManager.Player.HasBuffOfType(BuffType.Suppression))
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
            if (qss && Snare && ObjectManager.Player.HasBuffOfType(BuffType.Snare))
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
            if (qss && Silence && ObjectManager.Player.HasBuffOfType(BuffType.Silence))
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
            if (qss && Polymorph && ObjectManager.Player.HasBuffOfType(BuffType.Polymorph))
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
            if (qss && stun && ObjectManager.Player.HasBuffOfType(BuffType.Stun))                    
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
            if (qss && Poison && ObjectManager.Player.HasBuffOfType(BuffType.Poison))
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
            if (qss && blind && ObjectManager.Player.HasBuffOfType(BuffType.Blind))
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
            if (qss && taunt && ObjectManager.Player.HasBuffOfType(BuffType.Taunt))
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
            if (qss && charm && ObjectManager.Player.HasBuffOfType(BuffType.Charm))
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
            if (qss && fear && ObjectManager.Player.HasBuffOfType(BuffType.Fear))
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
        }

        public static void Dohydra()
        {
            var rh = itemMenu.GetCheckbox("rh");
            var ti = itemMenu.GetCheckbox("ti");
            var th = itemMenu.GetCheckbox("th");

            foreach (var enemy in ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget()))
                if (rh && rhydra.IsOwned() && rhydra.IsReady() && enemy.IsValidTarget(350))
                {
                    rhydra.Cast();
                }
            foreach (var enemy in ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget()))
                if (ti && timat.IsOwned() && timat.IsReady() && enemy.IsValidTarget(400))
                {
                    timat.Cast();
                }
            foreach (var enemy in ObjectManager.MinionsAndMonsters.Enemy.Where(x => x.IsValidTarget()))
                if (th && thydra.IsOwned() && thydra.IsReady() && enemy.IsValidTarget(ObjectManager.Player.AttackRange))
                {
                    thydra.Cast();
                }
        }

        public static void Doorbs()
        {
            var Enemys = ObjectManager.Heroes.Enemies;
            var orb = orbMenu.GetCheckbox("enable");
            var blueon = orbMenu.GetCheckbox("blue");
            var yellow = orbMenu.GetCheckbox("yellow");

            if (blue.IsOwned() && blue.IsReady() || Yellow.IsOwned() && Yellow.IsReady())
                foreach (var target in Enemys)
                {
                    var lastPos = target.Position;
                    if (!target.IsVisible && !target.IsZombie)
                    {
                        //Chat.Print("cant see");
                        if (blueon && !target.IsVisible && orb && (ObjectManager.Player.Position - lastPos).Length() <= 4000)
                        {
                            blue.Cast(lastPos);
                            //Chat.Print("blue");
                        }
                        if (yellow && orb && (ObjectManager.Player.Position - lastPos).Length() <= 500)
                        {
                            //Chat.Print("yellow");
                            Yellow.Cast(lastPos);
                        }
                    }
                }
        }
    }
}