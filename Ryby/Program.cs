using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryby
{
    class Program
    {
        public void net10x10(int[,] ground)
        {
            int FishCount = 0;
            int indexY = 0;


            for (int indexX = 0; indexX < 100; indexX++)
            {
                if (indexX == 10)
                {
                    indexX = 0;
                    indexY++;
                }
                else if (indexX == 9 && indexY == 9)
                {
                    break;
                }
                FishCount += ground[indexX, indexY];
                Console.WriteLine(FishCount);

            }

        }

        public void net30x30(int[,] ground)
        {
            int indexY = 0;
            int CurrentFish = 0;
            int BestFish = 0;
            int BestNetPositionX = 0;
            int BestNetPositionY = 0;

            int netPositionY = 0;

            for (int netPositionX = 0; netPositionX < 970; netPositionX++)
            {
                if (netPositionX == 970)
                {
                    netPositionX = 0;
                    netPositionY++;
                }
                else if (netPositionX == 970 && netPositionY == 970)
                {
                    break;
                }
                for (int indexX = 0; indexX < 900; indexX++)
                {
                    if (indexX == 30)
                    {
                        indexX = 0;
                        indexY++;
                    }
                    else if (indexX == 29 && indexY == 29)
                    {
                        break;
                    }
                    CurrentFish += ground[indexX + netPositionX,indexY + netPositionY];
                   
                }
                if (CurrentFish > BestFish)
                {
                    BestFish = CurrentFish;
                    BestNetPositionX = netPositionX;
                    BestNetPositionY = netPositionY;
                }
            }

            Console.WriteLine("Nejlepší hod je na pozici X = " + BestNetPositionX + " Y = " + BestNetPositionY + " s " + BestFish + " rybami");
        }
         static void Main(string[] args)
        {
            Program p = new Program();
            Random r = new Random();
            int[,] huntingGround = new int[1000, 1000];
            int y = 0;
            int fishNum = 0;
            int fishNumMax = 100000;


            for (int x = 0; x < huntingGround.Length; x++)
            {
                if (fishNumMax >= fishNum)
                {


                    if (x == 1000)
                    {
                        y++;
                        x = 0;
                    }
                    else if (y == 999 && x == 999)
                    {
                        break;
                    }
                    huntingGround[x, y] = r.Next(0, 2);
                    fishNum += huntingGround[x, y];
                    //Console.WriteLine(x + " je X " + y  + " je Y ");
                    //Console.WriteLine(huntingGround[x, y]);
                }
                else
                {
                    if (x == 1000)
                    {
                        y++;
                        x = 0;
                    }
                    else if (y == 999 && x == 999)
                    {
                        break;
                    }
                    huntingGround[x, y] = 0;
                }

            }
            //p.net10x10(huntingGround);
            p.net30x30(huntingGround);
            Console.ReadLine();


        }
    }
}
