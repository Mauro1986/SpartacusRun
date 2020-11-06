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
            decimal slaagKansJelle, slaagKansLotte;
            string[] obstakelNaam = { "The Wall", "Fallen Mikado", "Muddylicious", "Waterfest", "Terrilifying", "Tobogaaaaan!", "Tyre mania", "Foooorza!", "Itsy bitsy spider", "De put", "Fear of the Yeti!" };
            int[] obstakelAfstand = { 100, 1100, 1500, 1900, 2100, 2400, 2700, 3600, 4000, 4200, 6800 };
            int speed;
            int indexer = 0;
            DateTime timePassedJelle, timePassedLotte, actueleTijd;
            TimeSpan raceTime;

            // INPUT
            speed = 50;
            snelheidJelle = number.Next(9, 14);
            snelheidLotte = number.Next(7, 12);
            slaagKansJelle = number.Next(1, 60);
            slaagKansLotte = number.Next(1, 100);
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

                int afstandLotteToInt = (int)afstandLotte;      //casten decimal naar int
                int afstandJelleToInt = (int)afstandJelle;      //casten decimal naar int

                //OBSTAKELS
                for (int i = 0; i < obstakelAfstand.Length; i++)
                {
                    if (afstandJelleToInt == obstakelAfstand[i])
                    {
                        Console.WriteLine($"Jelle zit vast aan: {obstakelNaam[i]}");//1/100 per second
                        snelheidJelle = 0;
                        while (slaagKansJelle == 1)
                        {
                            snelheidJelle = number.Next(9, 14);
                        }
                    }
                }
                for (int i = 0; i < obstakelAfstand.Length; i++)
                {
                    if (afstandLotteToInt == obstakelAfstand[i])
                    {
                        Console.WriteLine($"Lotte zit vast aan: {obstakelNaam[i]}");
                        snelheidLotte = 0;
                        while (slaagKansLotte == 1)
                        {
                            snelheidLotte = number.Next(7, 12);
                        }
                    }
                }

                    //change speed every minute
                    if (raceTime.TotalSeconds % 60 == 0)
                    {
                        Console.WriteLine("Speed Change");
                        Console.WriteLine("Speed Change");
                        snelheidJelle = number.Next(9, 14);
                        snelheidLotte = number.Next(7, 12);
                        Console.WriteLine("Speed Change");
                        Console.WriteLine("Speed Change");
                    }




                    //OUTPUT
                    Toonrace(obstakelAfstand, obstakelNaam, raceTime, snelheidLotte, afstandLotte, snelheidJelle, afstandJelle, actueleTijd/*, obstakelAfstand[indexer] , timePassedJelle, timePassedLotte*/);




                    //add time
                    timePassedLotte.AddSeconds(1);
                    timePassedJelle.AddSeconds(1);

                    Thread.Sleep(speed);

                    //Keep console open

                
            }
        }
        static void Toonrace(int[] obstakelAfstand, string[] obstakelNaam ,TimeSpan raceTime, decimal snelheidLotte, decimal afstandLotte, decimal snelheidJelle, decimal afstandJelle, DateTime actueleTijd/*,int indexer, int[] obstakelAfstand, string[] obstakelNaam, DateTime timePasssedJelle, DateTime timePasssedLotte*/)
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

            //OBSTAKELS
            for (int i = 0; i < obstakelAfstand.Length; i++)
            {
                if (afstandJelleToInt == obstakelAfstand[i])
                {
                    Console.WriteLine($"Jelle zit vast aan: {obstakelNaam[i]}");//1/100 per second

                }
            }
            for (int i = 0; i < obstakelAfstand.Length; i++)
            {            
                if (afstandLotteToInt == obstakelAfstand[i])
                {
                    Console.WriteLine($"Lotte zit vast aan: {obstakelNaam[i]}");//1/100 per second
                 
                }
            }
            Console.ReadLine();
        }
    }
}

