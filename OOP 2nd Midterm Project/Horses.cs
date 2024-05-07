using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Racing_Game
{

    internal class HorseNames
    {
        private int _horsecount = 0;
        private string[] _horsenames = new string[190537];
        private Random rnd = new Random();
        private Dictionary<int, string> _names = new Dictionary<int, string>();
        public Dictionary<int,string> Horsenames()
        {
            string[] readstring = new string[190537];

            using (StreamReader sr = new StreamReader("C:\\Users\\Krizan246\\Downloads\\Racing Horse Names.csv"))
            {
                string line;
                int x = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    _names[x] = line;
                    x++;
                }
            }
            return (_names);
        }
        public int HorseCount()
        {
            return _horsecount = rnd.Next(5,16);
        }
        public int[] horsenumbers()
        {
            int[] horsenum = new int[_horsecount];
            for (int x = 0; x < _horsecount; x++)
                horsenum[x] = rnd.Next(0, 190537);
            for (int x = 0; x < horsenum.Length; x++)
                for (int y = 0; y < horsenum.Length; y++)
                {
                    if (x == y)
                        continue;
                    if (horsenum[x] == horsenum[y])
                        horsenumbers();
                }
            return horsenum;
        }
    }
}
