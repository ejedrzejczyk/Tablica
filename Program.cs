using System;

namespace Tablica
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDim;
            int secondDim;

            Console.WriteLine("Tworzenie nowej tablicy");
            Console.WriteLine("\nWprowadź pierwszy wymiar:");
            firstDim = InputDimension();
            Console.WriteLine("\nWprowadź drugi wymiar:");
            secondDim = InputDimension();
            MyArray array = new MyArray(firstDim, secondDim);
            array.ArraySizeChanged += ArrayChangedLog;

            while (true)
            {
                Console.WriteLine("\nWcisnij 'R' aby odczytac wartosc z tablicy lub 'W' aby zapisac liczbe do tablicy");
                Console.WriteLine("\nWcisnij 'P' aby wypisac cala tablice");
                Console.WriteLine("\nWcisnij 'ESC' aby wylaczyc aplikacje\n");
                ConsoleKeyInfo cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.P)
                {
                    array.PrintArray();
                }
                else if (cki.Key == ConsoleKey.R)
                {
                    try
                    {
                        int i = InputIndex();
                        int j = InputIndex();
                        int val = array[i, j];
                        Console.WriteLine("\nElement [{0},{1}] = {2}", i, j, val);
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (cki.Key == ConsoleKey.W)
                {
                    array[InputIndex(), InputIndex()] = InputValue();

                }
                else if (cki.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nUnexpected key");
                }
            }
        }

        private static void ArrayChangedLog(int firstDimension, int secondDimension)
        {
            Console.WriteLine("\nTablica rozszerzona.");
            Console.WriteLine("Aktualny rozmiar: {0}x{1}", firstDimension, secondDimension);
        }

        public static int InputDimension()
        {
            int dimension;
            while (true)
            {
               //Console.WriteLine("\nWprowadź pierwszy wymiar:");
                try
                {
                    do
                    {
                        dimension = Convert.ToInt32(Console.ReadLine());
                        if (dimension < 0) Console.WriteLine("Dozwolone tylko dodatnie wartosci!\n");
                    }
                    while (dimension < 0);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawny format liczby!\n");
                    continue;
                }
            }
            return dimension;
        }

        public static int InputIndex()
        {
            int index;
            while (true)
            {
                Console.WriteLine("\nWprowadź index tablicy:");
                try
                {
                    do
                    {
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index < 0) Console.WriteLine("Dozwolone tylko dodatnie wartosci!\n");
                    }
                    while (index < 0);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawny format liczby!\n");
                    continue;
                }
            }
            return index;
        }

        public static int InputValue()
        {
            int value;
            while (true)
            {
                Console.WriteLine("\nWprowadź wartość do tablicy:\n");
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Niepoprawny format liczby!\n");
                    continue;
                }
            }
            return value;
        }
    }
}