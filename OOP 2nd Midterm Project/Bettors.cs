using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Horse_Racing_Game
{
    internal class Bettors
    {
        public  int _playercount = 0;
        private string[] _names = {};
        public string[] Name()
        {
            _names = new string[_playercount]; 
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int x = 0; x < _names.Length; x++)
            {
                Console.Write($"Player {x + 1}:");
                Console.ResetColor();
                _names[x] = Console.ReadLine();
                Console.WriteLine($"Welcome {_names[x]}!");
                Console.ReadKey();
                Console.Clear();
            }
            return _names;
        }
        public int PlayerCount()
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("How many players are playing?");
                    Console.ResetColor();
                    Console.WriteLine("*Player count can go from 2 up to 20 players per game*");
                    _playercount = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e) 
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("That's is not a number");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (_playercount < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("How do you make bets with only 1 person.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("██████████▀▀▀▀▀▀▀▀▀▀▀▀▀██████████\r\n█████▀▀░░░░░░░░░░░░░░░░░░░▀▀█████\r\n███▀░░░░░░░░░░░░░░░░░░░░░░░░░▀███\r\n██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██\r\n█░░░░░░▄▄▄▄▄▄░░░░░░░░▄▄▄▄▄▄░░░░░█\r\n█░░░▄██▀░░░▀██░░░░░░██▀░░░▀██▄░░█\r\n█░░░██▄░░▀░░▄█░░░░░░█▄░░▀░░▄██░░█\r\n██░░░▀▀█▄▄▄██░░░██░░░██▄▄▄█▀▀░░██\r\n███░░░░░░▄▄▀░░░████░░░▀▄▄░░░░░███\r\n██░░░░░█▄░░░░░░▀▀▀▀░░░░░░░█▄░░░██\r\n██░░░▀▀█░█▀▄▄▄▄▄▄▄▄▄▄▄▄▄▀██▀▀░░██\r\n███░░░░░▀█▄░░█░░█░░░█░░█▄▀░░░░███\r\n████▄░░░░░░▀▀█▄▄█▄▄▄█▄▀▀░░░░▄████\r\n███████▄▄▄▄░░░░░░░░░░░░▄▄▄███████");
                Console.ReadKey();
                Console.Clear();
                PlayerCount();

            }
            return _playercount;
        }
    }
}



