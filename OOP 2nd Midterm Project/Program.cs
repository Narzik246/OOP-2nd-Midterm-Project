using Horse_Racing_Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2nd_Midterm_Project
{
    internal class Program
    {

        public int _playercount = 0;
        static void Main()
        {
            Game G = new Game();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lets start the game!");
            Console.ReadKey();
            Console.Clear();
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader("C:\\Users\\Krizan246\\Downloads\\Race Records.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
                using (StreamWriter sw = new StreamWriter("C:\\Users\\Krizan246\\Downloads\\Race Records.txt"))
                {
                    for (int x = 0; x < list.Count; x++)
                        sw.WriteLine(list[x]);
                    G.initializeplayers(sw);
                    G.Bets(sw);
                }
            
        }
    }

}
