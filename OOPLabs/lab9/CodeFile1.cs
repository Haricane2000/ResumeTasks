using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    delegate int summa(int x, int y, int z);
    delegate void priv();
    static class StringMethods
    {
        public static void DeleteSpaces(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    str.Remove(i, 1);
            }
        }

        public static void DeleteCommas(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                    str.Remove(i, 1);
            }
        }

        public static void DeleteLetterA(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A')
                    str.Remove(i, 1);
            }
        }

        public static void AddBAfterS(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'S')
                    str.Insert(i + 1, "B");
            }
        }

        public static void AddSpacesAfterPoints(StringBuilder str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.')
                    str.Insert(i + 1, " ");
            }
        }
    }
}