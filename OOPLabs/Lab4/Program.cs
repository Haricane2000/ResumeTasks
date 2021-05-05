using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab4
{

    class myString
    {
        private static int counter;
        private char[] str;
        private int length;
        public readonly int maxsize;
        Owner infAboutCreator;
        public readonly DateTime creationTime;
        public int Length
        {
            get { return this.length; }
            set { this.length = value; }
        }
        public char[] Str
        {
            get { return this.str; }
            set { this.str = value; }
        }
        public char this[int i]
        {
            get { return str[i]; }
            set { str[i] = value; }
        }
        class Owner
        {
            int id;
            string name;
            string organization;

            public Owner(ref int counter)
            {
                this.id = counter++;
                this.name = "Smirnov Kirill";
                this.organization = "BSTU";
            }
        }
        public myString()
        {
            myString.counter++;
            this.maxsize = 100;
            this.str = new char[100];
            this.length = 0;
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = DateTime.Now;
        }
        public myString(string input)
        {
            myString.counter++;
            this.maxsize = 100;
            this.str = new char[100];
            this.length = 0;
            this.infAboutCreator = new Owner(ref counter);
            this.creationTime = DateTime.Now;

            for (int i = 0; i < input.Length && i < this.maxsize; i++)
            {
                this.str[i] = input[i];
                this.length++;
            }
        }
        ~myString()
        {
            myString.counter--;
        }

        public int Compare(myString a)
        {
            if (this.length < a.length)
                return -1;
            else if (this.length == a.length)
                return 0;
            else
                return 1;
        }

        public static bool operator <(myString var1, myString var2)
        {
            if (var1.length < var2.length)
                return true;
            else
                return false;
        }

        public static bool operator >(myString var1, myString var2)
        {
            if (var1.length > var2.length)
                return true;
            else
                return false;
        }

        public static bool operator ==(myString var1, myString var2)
        {
            if (var1.length == var2.length)
                return true;
            else
                return false;
        }

        public static bool operator !=(myString var1, myString var2)
        {
            if (var1.length != var2.length)
                return true;
            else
                return false;
        }

        public static myString operator +(myString var, int i)
        {

            myString temp = new myString();

            for (int j = 0; j < var.length; j++)
                temp.str[j] = var.str[j];
            temp.length = var.length;

            string tempStr = i.ToString();

            for (int k = temp.length, j = 0; j < tempStr.Length; k++, j++)
            {
                temp.str[k] = tempStr[j];
                temp.length++;
            }

            return temp;
        }
        public static myString operator *(myString var, char c)
        {
            myString temp = new myString();

            for (int i = 0; i < var.length; i++)
                temp.str[i] = c;
            temp.length = var.length;

            return temp;
        }
        public myString DeleteLastEl()
        {
            myString temp = new myString();

            for (int i = 0; i < this.length - 1; i++)
                temp.str[i] = this.str[i];

            temp.length = this.length - 1;

            this.str[this.length - 1] = '\0';
            this.length--;

            return temp;
        }
    }
    static class StatisticOperation
    {
        public static bool CheckForSymbols(this myString str, string checkStr)
        {
            for (int i = 0; i < str.Length; i++)
                for (int j = 0; j < checkStr.Length; j++)
                    if (str.Str[i] == checkStr[j])
                        return true;

            return false;
        }

        public static void DeletePunctuationMarks(this myString str)
        {
            char[] temp = new char[str.Length];
            for (int i = 0, j = 0; i < str.Length; i++)
                if (str.Str[i] != ',' && str.Str[i] != '.' && str.Str[i] != '!' && str.Str[i] != '?' && str.Str[i] != ';' && str.Str[i] != ':' && str.Str[i] != '-')
                    temp[j++] = str.Str[i];
                else
                    str.Length--;

            str.Str = temp;
        }

        public static myString Concat(this myString str1, myString str2)
        {
            myString temp = new myString();
            int i = 0;
            for (; i < str1.Length; i++)
                temp.Str[i] = str1.Str[i];

            for (int j = 0; j < str2.Length; j++)
                temp.Str[i++] = str2.Str[j];

            temp.Length = i + 1;

            return temp;
        }

        public static int DiffBetweenStrs(this myString str1, myString str2)
        {
            return Math.Abs(str1.Length - str2.Length);
        }

        public static int Elcounter(this myString str)
        {
            return str.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            myString a = new myString("Hello");
            myString b = new myString();

            for (int j = 0; j < a.Length; j++)
                Console.WriteLine(a[j]);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


           b = a.DeleteLastEl();
            for (int j = 0; j < b.Length; j++)
                Console.WriteLine(b[j]);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            b = a + 421;
            for (int j = 0; j < b.Length; j++)
                Console.WriteLine(b[j]);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            if (a.Compare(b) == -1 && a < b)
                Console.WriteLine('<');
            else if (a.Compare(b) == 0 && a == b)
                Console.WriteLine('=');
            else
                Console.WriteLine('>');
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            b = a * '!';
            for (int j = 0; j < b.Length; j++)
                Console.WriteLine(b[j]);
            b[0] = a[0];
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            if (a.CheckForSymbols("abc!"))
                Console.WriteLine(true);
            else
                Console.WriteLine(false);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            a = a + 123456;
            a[3] = ',';
            for (int j = 0; j < a.Length; j++)
                Console.WriteLine(a[j]);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            a.DeletePunctuationMarks();
            for (int j = 0; j < a.Length; j++)
                Console.WriteLine(a[j]);
            Console.Write("----------------------------------------------------------------------------------------------------------\n");


            a.Concat(b);
            for (int j = 0; j < a.Length; j++)
                Console.WriteLine(a[j]);
        }
    }
}
