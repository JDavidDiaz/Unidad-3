using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Tower Torre = new Tower();
            Torre.Game();
            Console.ReadKey();
        }
    }
}
