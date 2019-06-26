using System;
using Robocode;
using System.Drawing;

namespace MarcusVidal.Robo
{
    public class Robot_MVidal : AdvancedRobot
    {

        public override void Run()
        {
            SetColors(Color.Black, Color.Black, Color.DarkOrange);
                  

            while (true)
            {
                Ahead(100);
                TurnRight(90);
                Ahead(100);
                TurnRight(90);
                Ahead(100);
                TurnLeft(90);
                Ahead(100);
                TurnRight(90);
                Ahead(100);
                TurnLeft(90);              
                Scan();
                Execute();
            }
            
        }

        public override void OnHitWall(HitWallEvent evento)
        {
            TurnRight(50);
            Back(150);
        }

        public override void OnBulletHit(BulletHitEvent evnt)
        {
            base.OnBulletHit(evnt);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            double anguloInimigo = evnt.Bearing;

            Fire(1);
            Scan();

            if(GunHeading > anguloInimigo && (GunHeading - anguloInimigo) <= 180)
            {
                TurnGunLeft(GunHeading - anguloInimigo);
                Fire(1);
            }

            if(GunHeading < anguloInimigo && (GunHeading + anguloInimigo) <= 180)
            {
                TurnGunRight(GunHeading + anguloInimigo);
                Fire(1);
            }

            Scan();

        }

        public override void OnHitRobot(HitRobotEvent evento)
        {
            if(evento.Bearing < 180)
            {
                TurnGunRight(evento.Bearing);
            }
            else
            {
                TurnGunLeft(evento.Bearing);
            }
            
            Fire(3);

        }

        public int detectaEnergia(int energiaInimigo) {

            //TODO fazer comparações para retornar a intensidade do tiro

            int resultado = 0;

            return resultado;
        }

    }
}
