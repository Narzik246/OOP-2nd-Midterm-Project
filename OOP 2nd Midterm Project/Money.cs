using Horse_Racing_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2nd_Midterm_Project
{
    public class Money
    {
        private decimal[] _bets = null;
        private decimal[] _cash;
        public decimal[] Bets(string[] bettors)
        {
            Bettors B = new Bettors();
            decimal prizepool = 0;
            _bets = new decimal[B._playercount];
            _cash = new decimal[B._playercount];
            for (int x = 0; x < B._playercount; x++)
            {
                _cash[x] = 1000m;
                Console.Clear();
                for (int y = 0; y < x + 1; y++)
                {
                    Console.ResetColor();
                    if (_cash[y] < 0)
                    {
                        Console.Write($"{bettors[y]}'s Cash: ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"${_cash[y]}");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine($"{bettors[y]}'s Cash: ${_cash[y]}");
                }
                Console.WriteLine($"Player {x + 1}, how much do you want to bet?");
                _bets[x] = decimal.Parse(Console.ReadLine());
                _cash[x] -= _bets[x];
                prizepool += _bets[x];
            }

            Console.Clear();
            for (int x = 0; x < B._playercount; x++)
            {
                Console.ResetColor();
                if (_cash[x] < 0)
                {
                    Console.Write($"{bettors[x]}'s Cash: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"${_cash[x]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"{bettors[x]}'s Cash: ${_cash[x]}");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Press any key to choose horses]");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
            return _bets;
        }
    }
}
