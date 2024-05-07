using Horse_Racing_Game;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2nd_Midterm_Project
{
    internal class Game
    {
        HorseNames HN = new HorseNames();
        Bettors B = new Bettors();
        Money M = new Money();
        Program Program = new Program();
        private decimal[] bets = null;
        public decimal[] cash = null;
        private int horsecount;
        private int[] horsnumbers;
        private string[] bettors = null;
        private Random rnd = new Random();
        private Dictionary<int, string> stable = new Dictionary<int, string>();
        private int[] choice = null;
        private int playercount = 0;
        bool[] winner = null;
        private decimal prizepool = 0;
        public void initializeplayers(StreamWriter sw)
        {
            playercount = B.PlayerCount();
            Console.Clear();
            Console.WriteLine($"There are {playercount} players!");
            Console.ReadKey();
            Console.Clear();
            bettors = new string[playercount];
            cash = new decimal[B._playercount];
            bettors = B.Name();
            sw.WriteLine($"========================================================================================\n");
            sw.WriteLine($"Player count: {playercount}");
            for (int x = 0; x < bettors.Length; x++)
            {
                cash[x] = 1000m;
                sw.WriteLine($"Player {x + 1} name: {bettors[x]}\tOriginal cash: {cash[x]}");
                Console.WriteLine($"Player {x + 1}: {bettors[x]}");
            }
            Console.ReadKey();
            sw.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Clear();
        }
        public void Bets(StreamWriter sw)
        {
            horsecount = HN.HorseCount();
            horsnumbers = HN.horsenumbers();
            stable = HN.Horsenames();
            bets = new decimal[B._playercount];
            Console.ResetColor();
            while (true)
            {
                try
                {
                    for (int x = 0; x < B._playercount; x++)
                    {
                        Console.Clear();
                        for (int y = 0; y < x + 1; y++)
                        {
                            Console.ResetColor();
                            if (cash[y] < 0)
                            {
                                Console.Write($"{bettors[y]}'s Cash: ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"${cash[y]}");
                                Console.ResetColor();
                            }
                            else
                                Console.WriteLine($"{bettors[y]}'s Cash: ${cash[y]}");
                        }
                        Console.WriteLine($"Player {x + 1}, how much do you want to bet?");
                        bets[x] = decimal.Parse(Console.ReadLine());
                        cash[x] -= bets[x];
                        prizepool += bets[x];
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Try again.");
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine("If you already put a proper bet in then you dont need to write it again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.Clear();
            for (int x = 0; x < B._playercount; x++)
            {
                Console.ResetColor();
                if (cash[x] < 0)
                {
                    Console.Write($"{bettors[x]}'s Cash: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"${cash[x]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"{bettors[x]}'s Cash: ${cash[x]}");
            }
            Console.WriteLine($"Prizepool {prizepool}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Press any key to choose horses]");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
            sw.WriteLine();
            choice = new int[bettors.Length];

                                Console.ForegroundColor= ConsoleColor.DarkRed;


            while (true)
            {
                try
                {
                    for (int x = 0; x < bettors.Length; x++)
                    {
                        Console.WriteLine($"Player {x + 1} Which horse do you want to bet on?");
                        for (int y = 0; y < horsnumbers.Length; y++)
                        {
                            Console.ForegroundColor = Color()[y];
                            Console.WriteLine($"{y + 1}. {stable[horsnumbers[y]]}");
                        }
                        Console.ResetColor();
                        choice[x] = int.Parse(Console.ReadLine()) - 1;
                        Console.Clear();
                        sw.WriteLine($"{bettors[x]} " +
                            $"bet ${bets[x]} on horse " +
                            $"#{choice[x] + 1}, " +
                            $"{stable[horsnumbers[choice[x]]]}\tCash: " +
                            $"${cash[x]}");
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("That's is not a valid option");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Race(sw);
            for (int x = 0; x < bettors.Length; x++)
                sw.WriteLine($"{x + 1}. {bettors[x]}'s cash: ${cash[x]}");
            Console.WriteLine("Wanna go again?");
            Console.WriteLine("1. Same players\n2. Make a new game\n3.Quit");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "1":
                    Console.Clear();
                    sw.WriteLine("----------------------------------------------------------------------------------------");
                    Bets(sw);
                    break;
                case "2":
                    Console.Clear();
                    sw.WriteLine($"========================================================================================");
                    initializeplayers(sw);
                    Bets(sw);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Buh bye :<");
                    sw.WriteLine($"========================================================================================");
                    Console.ReadKey();
                    break;
            }

        }
        public void Race(StreamWriter sw)
        {
            int[] paces = new int[horsnumbers.Length];
            for (int x = 0; x < paces.Length; x++)
                paces[x] = 0;
            int count = 1;
            int step;
            while (count == 1)
            {
                Console.Clear();
                for (int x = 0; x < horsnumbers.Length; x++)
                {
                    step = rnd.Next(-1, 3);
                    if (paces[x] == 0 && step <= 0)
                        paces[x] = 0;
                    else
                        paces[x] += step;
                    Console.ForegroundColor = Color()[x];
                    Console.WriteLine($"{x + 1}. {stable[horsnumbers[x]]}: {paces[x]} Paces");
                    for (int y = 0; y < paces[x]; y++)
                        Console.Write($"-");
                    Console.Write("|");
                    Console.ResetColor();
                    for (int y = 0; y < 100 - paces[x] - 1; y++)
                        Console.Write($"-");
                    if (paces[x] < 100)
                        Console.WriteLine("|");
                    else
                        Console.WriteLine();
                    if (paces[x] >= 100)
                        count = 0;
                }
                Console.WriteLine();
                if (count == 0)
                    break;
            }
            Console.WriteLine();
            sw.WriteLine($"Out of {horsnumbers.Length} horses:");
            for (int x = 0; x < horsnumbers.Length; x++)
                if (paces[x] >= 100)
                {
                    Console.ForegroundColor = Color()[x];
                    Console.Write($"{stable[horsnumbers[x]]} ");
                    Console.ResetColor();
                    Console.WriteLine("won the race!");
                    sw.WriteLine($"{stable[horsnumbers[x]]} won the race!");
                    sw.WriteLine();
                }
            Console.ReadKey();
            Winners(paces, sw);
        }
        public void Winners(int[] paces, StreamWriter sw)
        {
            winner = new bool[paces.Length];
            for (int x = 0; x < paces.Length; x++)
            {
                if (paces[x] >= 100)
                    winner[x] = true;
                else
                    winner[x] = false;
            }
            bool[] winbet = new bool[bettors.Length];
            int winbetcount = 0;
            for (int x = 0; x < bettors.Length; x++)
                if (winner[choice[x]] == true)
                {
                    winbet[x] = true;
                    winbetcount++;
                }
            decimal divide = 0;
            for (int x = 0; x < bettors.Length; x++)
                if (winbet[x] == true)
                    divide += bets[x];
            if (winbetcount == 1)
            {
                for (int x = 0; x < bettors.Length; x++)
                    if (winbet[x] == true)
                    {
                        Console.WriteLine($"{bettors[x]} won the bet");
                        cash[x] += prizepool;
                        Console.Write("They now have ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ResetColor();
                        Console.WriteLine($"${cash[x]}");
                        Console.WriteLine();
                        sw.WriteLine($"{bettors[x]} won the bet winning {prizepool}");
                    }
            }
            else if (winbetcount >= 2)
            {
                for (int x = 0; x < bettors.Length; x++)
                    if (winbet[x] == true)
                    {
                        Console.WriteLine($"{bettors[x]} won the bet");
                        decimal winning = bets[x] / divide;
                        winning *= prizepool;
                        cash[x] += winning;
                        Console.Write("They now have ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.ResetColor();
                        Console.WriteLine($"${cash[x]}");
                        Console.WriteLine();
                        sw.WriteLine($"{bettors[x]} won the bet winning {winning}");
                    }
            }
            else if (winbetcount == 0)
            {
                Console.WriteLine("Noone won :(");
                sw.WriteLine("Noone won :(");
            }
            sw.WriteLine();
            Console.ReadKey();
        }
        public ConsoleColor[] Color()
        {
            ConsoleColor[] colors =
            {
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.Red,
                ConsoleColor.Yellow,
                ConsoleColor.Magenta,
                ConsoleColor.Cyan,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
                ConsoleColor.DarkMagenta,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkGray,
                ConsoleColor.White,
                ConsoleColor.Black
            };
            return colors;
        }
    }
}
