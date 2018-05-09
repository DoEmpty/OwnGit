using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckNumber
{
    class Program
    {
        static char[] DigitalChar = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] PointChar = new char[1] { '.' };
        static char[] EChar = new char[2] { 'e', 'E' };
        static char[] PlusChar = new char[1] { '+' };
        static CheckChar CheckCharFun;
        static List<CharType> CheckedTypes = new List<CharType>();
        static string userInput = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine("please input your number");
            var userInput = Console.ReadLine();
            try
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    var c = userInput[i];
                    CheckCharFun = null;
                    var type = GetCharType(c);
                    if (CheckCharFun.Invoke(c, i))
                    {
                        CheckedTypes.Add(type);
                    }
                    else
                    {
                        throw new Exception("not a valid number");
                    }
                }
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        static CharType GetCharType(char c)
        {
            if (Array.IndexOf(DigitalChar, c) > -1)
            {
                CheckCharFun += CheckDigital;
                return CharType.Digital;
            }
            if (Array.IndexOf(PointChar, c) > -1)
            {
                CheckCharFun += CheckPoint;
                return CharType.Point;
            }
            if (Array.IndexOf(EChar, c) > -1)
            {
                CheckCharFun += CheckE;
                return CharType.E;
            }
            if (Array.IndexOf(PlusChar, c) > -1)
            {
                CheckCharFun += CheckPlus;
                return CharType.Plus;
            }
            else
                throw new Exception("not a valid number");
        }

        static bool CheckDigital(char curChar, int index)
        {
            if (index != 0 && CheckedTypes[index - 1] == CharType.E)
            {
                return false;
            }
            return true;
        }

        static bool CheckPoint(char curChar, int index)
        {
            if (index == 0)
                return false;
            if (index == userInput.Length - 1)
                return false;
            if (CheckedTypes.Contains(CharType.Point))
            {
                return false;
            }
            if (CheckedTypes.Contains(CharType.E))
            {
                return false;
            }
            return true;
        }

        static bool CheckE(char curChar, int index)
        {
            if (index == 0)
                return false;
            if (index == userInput.Length - 1)
                return false;
            if (CheckedTypes.Contains(CharType.E))
                return false;
            if (CheckedTypes.Contains(CharType.Plus))
                return false;
            if (CheckedTypes.Last() == CharType.Point)
                return false;
            return true;
        }

        static bool CheckPlus(char curChar, int index)
        {
            if (index == 0)
                return false;
            if (index == userInput.Length - 1)
                return false;
            if (CheckedTypes.Contains(CharType.Plus))
                return false;
            if (CheckedTypes.Last() != CharType.E)
                return false;
            return true;
        }
    }

    public enum CharType
    {
        Digital,
        E,
        Point,
        Plus
    }

    public delegate bool CheckChar(char curChar, int index);
}
