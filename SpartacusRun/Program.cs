using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartacusRun
{
    class Program
    {
        static Random number = new Random();

        static void Main(string[] args)
        {
            //DECLARATIONS
            string[] people = { "Jelle", "Lotte" };
            int[] snelheid = new int[people.Length];
            int[] afstand = new int[people.Length];
            int[] minMaxJelle = new int[2];
            int[] minMaxLotte = new int[2];
            int runTime;

            string[] naamObstakels = {"The Wall","Fallen Mikado","Muddylicious",
                "Waterfest","Terrilifying","Tobogaaaaan!","Tyre mania","Foooorza!","Itsy bitsy spider","De put","Fear of the Yeti!"};

            int[] afstandObstakels = new int[naamObstakels.Length];
            afstandObstakels[0] = 100;
            afstandObstakels[1] = 1100;
            afstandObstakels[2] = 1500;
            afstandObstakels[3] = 1900;
            afstandObstakels[4] = 2100;
            afstandObstakels[5] = 2400;
            afstandObstakels[6] = 2700;
            afstandObstakels[7] = 3600;
            afstandObstakels[8] = 4000;
            afstandObstakels[9] = 4200;
            afstandObstakels[10] = 6800;


        








        }
    }
}
