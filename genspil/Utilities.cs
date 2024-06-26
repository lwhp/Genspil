﻿using genspil.Enums;

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

        public static string SelectEnumString(string enumType)
        {
            Type enumTypeObject = enumType == "condition" ? typeof(Condition) : enumType == "genre" ? typeof(Genre) : enumType == "inquiry" ? typeof(InquiryStatus) : typeof(SubGenre);

            int number = 0;
            List<string> enumNames = [];

            foreach (string name in Enum.GetNames(enumTypeObject))
            {
                number++;
                Console.WriteLine($"{number}. {name}");
                enumNames.Add(name);
            }

            int input = GetNumberFromInput();

            Console.Clear();

            if (input > 0 && input <= number)
            {
                return enumNames[input - 1];
            }

            return SelectEnumString(enumType);
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
