
using System;
using System.Threading;


namespace Opdracht_Spartacus_Run
{
    class Program
    {
        private static int KmHtoMeMin(int speed)
        {
            return speed * 1000 / 3600;
        }
        private static bool ShowResulte()
        {
            DateTime[] startingTime = new DateTime[] { DateTime.Now, DateTime.Now };
            DateTime[] currentTime = new DateTime[] { DateTime.Now, DateTime.Now };
            Console.ForegroundColor = ConsoleColor.White;
            if (currentTime[0] < currentTime[1])
            {
                Console.WriteLine("Jelle wins the race");
            }
            else
            {
                Console.WriteLine("Lotte wins the race");
            }
            Console.WriteLine($"Jelle : starting time is {startingTime[0]}\n\t finshing time is {currentTime[0]}");
            Console.WriteLine($"Lotte : starting time is {startingTime[1]}\n\t finshing time is {currentTime[1]}");
            return ShowResulte();
        }
        static void Main(string[] args)
        {
            string[] players = new string[] { "Lotte", "Jelle" };
            string[] obstacle = new string[] { "The Wall", "Fallen Mikado", "Muddylicious", "Waterfest", "Terrilifying", "Tobogaaaaan!", "Tyre mania", "Foooorza!", "Itsy", "bitsy", "spider", "De put", "Fear of the Yeti!" };
            int[] obstacleDistace = new int[] { 100, 1100, 1500, 1900, 2100, 2400, 2700, 3600, 4000, 4200, 6800 };
            int[] obstacleIndex = new int[] { -1, -1 };
            int[] currentSpeed = new int[] { 0, 0 };
            int[] currentDistance = new int[] { 0, 0 };
            int[] travuledDistance = new int[] { 0, 0 };
            int counter = 0;
            const int totalDistance = 7000;
            Random PlSpeed = new Random();
            DateTime[] startingTime = new DateTime[] { DateTime.Now, DateTime.Now };
            DateTime[] currentTime = new DateTime[] { DateTime.Now, DateTime.Now };
            bool runing = true;
            bool[] finished = new bool[] { false, false };
            Console.WriteLine("press enter to start the race");
            Console.ReadLine();
            while (runing)
            {
                if (counter % 120 == 0)
                {
                    currentSpeed[0] = PlSpeed.Next(9, 14);
                    currentSpeed[1] = PlSpeed.Next(7, 12);
                }
                obstacleIndex[0] = -1;
                obstacleIndex[1] = -1;
                for (int i = 0; i < obstacleDistace.Length; i++)
                {
                    if (travuledDistance[0] <= obstacleDistace[i] && (travuledDistance[0] + KmHtoMeMin(currentSpeed[0])) > obstacleDistace[i])
                    {
                        obstacleIndex[0] = i;
                        currentDistance[0] = obstacleDistace[i];
                    }
                    if (travuledDistance[1] <= obstacleDistace[i] && (travuledDistance[1] + KmHtoMeMin(currentSpeed[1]) > obstacleDistace[i]))
                    {
                        obstacleIndex[1] = i;
                        currentDistance[1] = obstacleDistace[i];
                    }
                }
                if (obstacleIndex[0] == -1 && !finished[0])
                {
                    travuledDistance[0] += KmHtoMeMin(currentSpeed[0]);
                }
                else if (PlSpeed.Next(1000) >= 994)
                {
                    travuledDistance[0] += 1;
                }
                if (obstacleIndex[1] == -1 && !finished[1])
                {
                    travuledDistance[1] += KmHtoMeMin(currentSpeed[1]);
                }
                else if (PlSpeed.Next(100) >= 99)
                {
                    travuledDistance[1] += 1;
                }
                if (travuledDistance[0] > totalDistance)
                {
                    finished[0] = true;
                }
                if (travuledDistance[1] > totalDistance)
                {
                    finished[1] = true;
                }
                counter++;
                Thread.Sleep(150);
                Console.Clear();
                if (finished[1] && finished[0])
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($">>>>>>>{counter / 60} min and {counter % 60} second on the run<<<<<<<");
                }
                if (!finished[0])
                {
                    currentTime[0] = currentTime[0].AddSeconds(1);
                    if (travuledDistance[1] > travuledDistance[0])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (obstacleIndex[0] == -1)
                    {
                        Console.WriteLine($"Jelle : speed is {currentSpeed[0]} M/Sec\n\ttravuled distance is {travuledDistance[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"Jelle is stuk on the {obstacle[obstacleIndex[0]]}\n\twithe current distance of {travuledDistance[0]}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Jelle has finshed the race");
                }
                if (!finished[1])
                {
                    currentTime[1] = currentTime[1].AddSeconds(1);
                    if (travuledDistance[1] > travuledDistance[0])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (obstacleIndex[1] == -1)
                    {
                        Console.WriteLine($"Lotte : speed is {currentSpeed[1]}\n\ttravyled distance of {travuledDistance[1]}");
                    }
                    else
                    {
                        Console.WriteLine($"Lotte is suke on {obstacle[obstacleIndex[1]]}\n\twith current distance of {travuledDistance[1]}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Lotte has finshed the race");
                }
            }
            Console.WriteLine(ShowResulte());
        }
    }
}