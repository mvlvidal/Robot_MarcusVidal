using System;
using Robocode;
using Robocode.Util;
using System.Drawing;

namespace MarcusVidal.Robo
{
    public class Robot_MVidal : AdvancedRobot
    {

        /* 
            Robô criado por Marcus Vidal: https://github.com/mvlvidal/Robot_MarcusVidal.git
        */

        public override void Run()
        {
            //Seta as cpres do Robô: corpo, arma, radar, bala e faixa do radar
            SetColors(Color.Black, Color.Yellow, Color.Yellow, Color.OrangeRed, Color.White);
                  

            while (true)
            {                           
                //Movimentação repetitiva do robô em uma forma parecida com um oito.
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
            //Movimentação do robô caso haja colizão com a parede
            Back(150);
            TurnRight(50);
            
        }

        public override void OnHitByBullet(HitByBulletEvent evento)
        {
            Console.WriteLine($"{Name} foi alvejado por {evento.Name} com {evento.Power} de dano!!");

            //Movimentação de defesa ao receber um tiro
            Back(100);

            TurnLeft(45);

            Scan();
        }

        public override void OnBulletHit(BulletHitEvent evento)
        {
            Console.WriteLine($"{Name} baleou {evento.VictimName}!!");
        }

        public override void OnScannedRobot(ScannedRobotEvent evento)
        {
            //Colhe o angulo do inimigo scaneado apartir da posição do robô
            double anguloInimigo = Utils.NormalRelativeAngleDegrees(evento.Bearing + Heading - GunHeading);

            //Gira a rma do robô para a direção do inimigo scaneado utilização o seu angulo relativo colhido
            TurnGunRight(anguloInimigo);
            Stop();

            //Atira no inigimo de acordo com a energia do robô
            Fire(setaInsensidade(Energy));

            Ahead(5);
        }

        public override void OnHitRobot(HitRobotEvent evento)
        {

            Console.WriteLine($"{Name} colidiu com {evento.Name}!!");

            //Colhe o angulo do inimigo scaneado apartir da posição do robô que colidiu
            double anguloInimigo = Utils.NormalRelativeAngleDegrees(evento.Bearing + Heading - GunHeading);

            Back(100);

            Stop();

            //Gira a rma do robô para a direção do inimigo da colisão utilizando o seu angulo relativo colhido
            TurnGunRight(anguloInimigo);

            //Atira no inigimo de acordo com a energia do robô
            SetFireBullet(setaInsensidade(Energy));

            Scan();

        }

        public int setaInsensidade(double energia) {

            //Metodo que define a intensidade do tiro de acordo com a temperatura da arma e a energia do robô

            int resultado = 0;

            if (GunCoolingRate == 0 && energia > 70)
            {
                resultado = 3;
            }
            else if (GunCoolingRate == 0 && energia > 30 && energia < 70 )
            {
                resultado = 2;
            }
            else
            {
                resultado = 1;
            }

            return resultado;
        }

    }

}
