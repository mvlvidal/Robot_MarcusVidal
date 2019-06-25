using System;
using Robocode;
using System.Drawing;

namespace MarcusVidal.Robo
{
    public class Robot_MVidal : Robot
    {

        public override void Run()
        {
            SetColors(Color.Black, Color.Black, Color.DarkOrange);
                  

            while (true)
            {
                Scan();
                TurnRight(90);
                Ahead(150);
                TurnRight(90);
                Ahead(150);

            }
            
        }

        public override void OnHitWall(HitWallEvent evento)
        {
            Back(150);
        }

        public override void OnBulletHit(BulletHitEvent evento)
        {
            Fire(1);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            double anguloInimigo = evnt.Bearing;

                if (anguloInimigo < 180)
                {
                    Stop();
                    TurnGunLeft(GunHeading + anguloInimigo);
                }
                else
                {
                    Stop();
                    TurnGunRight(GunHeading + anguloInimigo); 
                }

                if (GunHeat < 1)
                {
                    Fire(2);
                }


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
    }
}
