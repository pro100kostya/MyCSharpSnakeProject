using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal static class ConsoleWriter
    {
        public static void WriteCurrentUnitPosition(Unit unit)
        {
            Console.WriteLine($"X = {unit.CurrentPosition.X} , Y = {unit.CurrentPosition.Y}");
        }
    }
}
