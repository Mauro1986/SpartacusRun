using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.IO.Ports;

namespace SpartacusRun
{
    class Program
    {
        static Random number = new Random();

        static void Main(string[] args)
        {
            //DECLARATIONS
            decimal snelheidJelle, snelheidLotte;       //moet decimal zijn om juistere afstand te berekenen
            decimal afstandJelle, afstandLotte;         //moet decimal zijn om juistere afstand te berekenen
            int speed;
            DateTime timePassedJelle, timePassedLotte, actueleTijd;
            TimeSpan raceTime;

            // INPUT
            speed = 50;
            snelheidJelle = number.Next(9, 14);
            snelheidLotte = number.Next(7, 12);
            slaagkansJelle = number.Next( )
            afstandJelle = 0;
            afstandLotte = 0;
            timePassedJelle = DateTime.Now;
            timePassedLotte = DateTime.Now;
            actueleTijd = DateTime.Now;
            raceTime = new TimeSpan(0, 0, 0);

            //PROCESSING
            while ((afstandLotte < 5000) || (afstandJelle < 5000))
            {
                //Clock       
                raceTime += TimeSpan.FromSeconds(1);

                //add distance
                afstandLotte += snelheidLotte * 1000 / 3600;
                afstandJelle += snelheidJelle * 1000 / 3600;

                if (afstandJelle == 100)
                {
                    Console.WriteLine($"Jelle zit vast aan: The Wall");//1/100 per second
                    do
                    {
                       //stop afstand toe te voegen 
                    } while ();
                }

                //change speed every minute
                if (raceTime.TotalSeconds % 60 == 0)
                {
                    Console.WriteLine("Speed Change");
                    snelheidJelle = number.Next(9, 14);
                    snelheidLotte = number.Next(7, 12);
                }
        
                //OUTPUT
                Toonrace(raceTime, snelheidLotte, afstandLotte, snelheidJelle, afstandJelle, actueleTijd/*, timePassedJelle, timePassedLotte*/);
       
                //add time
                timePassedLotte.AddSeconds(1);
                timePassedJelle.AddSeconds(1);

                Thread.Sleep(speed);
            }
            //Keep console open
           
        }

        static void Toonrace(TimeSpan raceTime, decimal snelheidLotte, decimal afstandLotte, decimal snelheidJelle, decimal afstandJelle, DateTime actueleTijd/*, DateTime timePasssedJelle, DateTime timePasssedLotte*/)
        {
            int afstandLotteToInt = (int)afstandLotte;      //casten decimal naar int
            int afstandJelleToInt = (int)afstandJelle;      //casten decimal naar int
                                                            
            Console.Clear();       
            //SHOW TIME
            Console.WriteLine($"********** Starting time: {actueleTijd} **********\n");
            Console.WriteLine($"********** Race time: {raceTime.Minutes} minutes {raceTime.Seconds} seconds **********\n\n");
            //SET COLOR WINNER/LOSER GREEN/RED
            if (afstandJelle < afstandLotte)
            {
                Console.ForegroundColor
                    = ConsoleColor.Green;
                Console.WriteLine($"\t\tLotte: Snelheid: {snelheidLotte} km/uur\n" +
                $"\t\t\tAfstand: {afstandLotteToInt} meter\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\tJelle: Snelheid: {snelheidJelle} km/uur\n" +
                           $"\t\t\tAfstand: {afstandJelleToInt} meter\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor
                    = ConsoleColor.Red;
                Console.WriteLine($"\t\tLotte: Snelheid: {snelheidLotte} km/uur\n" +
                $"\t\t\tAfstand: {afstandLotteToInt} meter\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\t\tJelle: Snelheid: {snelheidJelle} km/uur\n" +
                           $"\t\t\tAfstand: {afstandJelleToInt} meter\n");
                Console.ResetColor();
            }
         
        }
    }
}


//switch (afstandJelle)
//{
//    case 100:
//        Console.WriteLine("The Wall");

//        break;
//}
//Console.ReadKey();

//int runTime;

//string[] naamObstakels = {"The Wall","Fallen Mikado","Muddylicious",
//    "Waterfest","Terrilifying","Tobogaaaaan!","Tyre mania","Foooorza!","Itsy bitsy spider","De put","Fear of the Yeti!"};

//int[] afstandObstakels = new int[naamObstakels.Length];
//afstandObstakels[0] = 100;
//afstandObstakels[1] = 1100;
//afstandObstakels[2] = 1500;
//afstandObstakels[3] = 1900;
//afstandObstakels[4] = 2100;
//afstandObstakels[5] = 2400;
//afstandObstakels[6] = 2700;
//afstandObstakels[7] = 3600;
//afstandObstakels[8] = 4000;
//afstandObstakels[9] = 4200;
//afstandObstakels[10] = 6800;