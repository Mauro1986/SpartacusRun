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
            TimeSpan raceTime, raceJelle, raceLotte;

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
            raceJelle = new TimeSpan(0, 0, 0);
            raceLotte = new TimeSpan(0, 0, 0);
            bool winnaar;

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

                    //change speed every minute
                    if (raceTime.TotalSeconds % 60 == 0)
                    {
                        Console.WriteLine("Speed Change");
                    //Console.ReadLine();
                    //Console.ReadKey();
                        Console.WriteLine("Speed Change");
                        snelheidJelle = number.Next(9, 14);
                        snelheidLotte = number.Next(7, 12);
                        Console.WriteLine("Speed Change");
                        Console.WriteLine("Speed Change");
                    }

                //OBSTAKELS JELLE                                       //WERKT GOED enkel PROBLEEM IS ZE SOMS OVER OBSTAKEL SPRINGEN Vb 101 of 98 ipv 100
                for (int i = 0; i < obstakelAfstand.Length; i++)
                {
                    if (afstandJelleToInt == obstakelAfstand[i])
                    {
                        snelheidJelle = 0;
                        slaagKansJelle = number.Next(1, 60);
                        if (slaagKansJelle == 1)
                        {
                            snelheidJelle = number.Next(9, 14);
                        }
                    }
                }
                //OBSTAKELS LOTTE
                for (int i = 0; i < obstakelAfstand.Length; i++)
                {
                    if (afstandLotteToInt == obstakelAfstand[i])
                    {
                        snelheidLotte = 0;
                        slaagKansLotte = number.Next(1, 60);
                        if (slaagKansLotte == 1)
                        {
                            snelheidLotte = number.Next(9, 14);
                        }
                    }
                }

   


                //OUTPUT
                Toonrace(slaagKansLotte,slaagKansJelle ,obstakelAfstand, obstakelNaam, raceTime, snelheidLotte, afstandLotte, snelheidJelle, afstandJelle, actueleTijd/*, obstakelAfstand[indexer] , timePassedJelle, timePassedLotte*/);

                //TUSSENDTIJD
                timePassedLotte.AddSeconds(1);
                timePassedJelle.AddSeconds(1);

                //AANKOMST                                                                          //PROBLEEM, ze blijven lopen
                if (afstandJelleToInt >= 500 && afstandLotte < 500)
                {
                    snelheidJelle = 0;
                    Console.WriteLine($"Tijd Jelle = {raceJelle.Minutes} Minuten {raceJelle.Seconds} Seconden");

                }
                else if (afstandLotteToInt >= 500 && afstandJelle < 500)
                {
                    snelheidLotte = 0;
                    Console.WriteLine($"Tijd Lotte = {raceLotte.Minutes} Minuten {raceLotte.Seconds} Seconden");

                }
                else if (afstandJelleToInt >= 500 && afstandLotte >= 500)
                {
                    Console.WriteLine("Einde race, ge moogt naar huis");
                }
                Thread.Sleep(speed);

                    //Keep console open            
            }
        }
        static void Toonrace(decimal slaagKansJelle, decimal slaagKansLotte, int[] obstakelAfstand, string[] obstakelNaam ,TimeSpan raceTime, decimal snelheidLotte, decimal afstandLotte, decimal snelheidJelle, decimal afstandJelle, DateTime actueleTijd/*,int indexer, int[] obstakelAfstand, string[] obstakelNaam, DateTime timePasssedJelle, DateTime timePasssedLotte*/)
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


            for (int i = 0; i < obstakelAfstand.Length; i++)
            {
                if (afstandLotteToInt == obstakelAfstand[i])
                {
                    Console.WriteLine($"Lotte zit vast aan: {obstakelNaam[i]}");
                }
            }
            for (int i = 0; i < obstakelAfstand.Length; i++)
            {
                if (afstandJelleToInt == obstakelAfstand[i])
                {
                    Console.WriteLine($"Jelle zit vast aan: {obstakelNaam[i]}");
                }
            }
           
            if (afstandJelleToInt >= 500 && afstandLotteToInt <500)
            {
                Console.WriteLine($"Jelle is de winnaar");
            }
            else if (afstandLotteToInt >= 500 && afstandJelleToInt < 500)
            {
                Console.WriteLine($"Lotte is de winnaar");
            }
        }
    }
}
