using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IntegratieOpdracht
{
    class Program
    {
        static Random number = new Random();
        static void Main(string[] args)
        {
            //DECLARATIONS
            int speedJelle, speedLotte;
            int distanceJelle, distanceLotte;
            int timeWait;
            DateTime timePassedJelle, timePassedLotte;
            TimeSpan timePassed;
            //INPUT
            distanceLotte = 0;
            distanceJelle = 0;
            timeWait = 10;
            timePassedJelle = DateTime.Now;
            timePassedLotte = DateTime.Now;
            timePassed = new TimeSpan(0, 0, 0);
            speedJelle = number.Next(9, 14);
            speedLotte = number.Next(7, 12);
            //PROCESSING
            while (distanceJelle < 7000 && distanceLotte < 7000)
            {
                //count time
                timePassed += TimeSpan.FromSeconds(1);
                //change speed every 2 minutes
                if (timePassed.TotalSeconds % 120 == 0)
                {
                    speedJelle = number.Next(9, 14);
                    speedLotte = number.Next(7, 12);
                }
                //add time
                timePassedJelle.AddSeconds(1);
                timePassedLotte.AddSeconds(1);
                //add distance
                distanceJelle += speedJelle * 1000 / 3600;
                distanceLotte += speedLotte * 1000 / 3600;
                //OUTPUT
                ShowRace(timePassed, distanceLotte, distanceJelle, speedLotte, speedJelle);
                Thread.Sleep(timeWait);
            }
            //Keep console open
            Console.ReadLine();
        }

        private static void ShowRace(TimeSpan timePassed, int distanceLotte, int distanceJelle, int speedLotte, int speedJelle)
        {
            Console.Clear();
            Console.WriteLine(
                $"****{timePassed.Minutes} minuten, {timePassed.Seconds} seconden aan het lopen****" +
                $"\nJelle:\tsnelheid: {speedJelle}km/uur" +
                $"\n\t\tafstand: {distanceJelle}m" +
                $"\nLotte:\tsnelheid: {speedLotte}km/uur" +
                $"\n\t\tafstand: {distanceLotte}m");
        }
    }
}
