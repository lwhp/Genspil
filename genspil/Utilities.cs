using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    public static class Utilities
    {
        public static int GetNumberFromInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Invalid input");
                return GetNumberFromInput();
            }

            return number;
        }

        public static float GetFloatFromInput()
        {
            if (!float.TryParse(Console.ReadLine(), out float number))
            {
                Console.WriteLine("Invalid input");
                return GetNumberFromInput();
            }

            return number;
        }
    }
}
