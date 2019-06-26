using System;
using Robocode;
using Robocode.Util;
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
                
                for (int i = 0; i < 5; i++)
                {
                    Ahead(100);
                    SetTurnRight(90);
                    Scan();

                }
                for (int i = 0; i < 5; i++)
                {
                    Ahead(100);
                    SetTurnLeft(90);
                    Scan();
                }


            }
            
        }

        public override void OnHitWall(HitWallEvent evento)
        {
            TurnRight(50);
            Back(150);
        }

        public override void OnBulletHit(BulletHitEvent evnt)
        {
            Back(100);
            TurnLeft(45);
            Ahead(100);
            Scan();
        }

        public override void OnScannedRobot(ScannedRobotEvent evento)
        {
            double anguloInimigo = Utils.NormalRelativeAngleDegrees(evento.Bearing + Heading - GunHeading);

            
            TurnGunRight(anguloInimigo);

            Fire(setaInsensidade(Energy));           
            
            Scan();
        }

        public override void OnHitRobot(HitRobotEvent evento)
        {
            double anguloInimigo = Utils.NormalRelativeAngleDegrees(evento.Bearing + Heading - GunHeading);

            TurnGunRight(anguloInimigo);

            Fire(3);

        }

        public int setaInsensidade(double energia) {

            //TODO fazer comparações para retornar a intensidade do tiro

            int resultado = 0;

            if (energia < 3)
            {
                resultado = 3;
            }
            else {
                resultado = 1;
            }

            return resultado;
        }

  
    }
}
