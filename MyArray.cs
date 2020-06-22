using System;

namespace Tablica
{
    class MyArray
    {
        private int[,] array;

        public delegate void ChangedEventHandler(int firstDimension, int secondDimenson);
        public event ChangedEventHandler ArraySizeChanged;

        protected virtual void OnArraySizeChanged(int firstDimension, int secondDimenson)
        {
            if(ArraySizeChanged != null)
            {
                ArraySizeChanged(firstDimension, secondDimenson);
            }
        }

        public int[] Size
        {
            get
            {
                int[] s = new int[2];
                s[0] = array.GetLength(0);
                s[1] = array.GetLength(1);
                return s;
            }
        }

        public MyArray(int firstDimension, int secondDimension)
        {
            array = new int[firstDimension, secondDimension];
        }

        public int this[int firstIndex,int secondIndex]
        {
            get
            {
                return ReadValue(firstIndex, secondIndex);
            }
            set
            {
                WriteValue(value, firstIndex, secondIndex);
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public int ReadValue(int firstIndex, int secondIndex)
        {
            try
            {
                return (int)array.GetValue(firstIndex, secondIndex);

            }
            catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Przekroczenie rozmiaru tablicy\nRozmiar tablicy: " + Size[0] + "x" + Size[1]);
            }
        }

        public void WriteValue(int value, int firstIndex, int secondIndex)
        {
            int newFirstSize = array.GetLength(0);
            int newSecondSize = array.GetLength(1);

            try
            {
                array.SetValue(value, firstIndex, secondIndex);
            }
            catch(IndexOutOfRangeException)
            {
                if (firstIndex + 1> array.GetLength(0))
                {
                    newFirstSize = firstIndex + 1;
                }
                if (secondIndex + 1> array.GetLength(1))
                {
                    newSecondSize = secondIndex + 1;
                }

                int[,] newArray = new int[newFirstSize, newSecondSize];

                for(int i = 0; i<array.GetLength(0); i++)
                {
                    for(int j = 0; j<array.GetLength(1); j++)
                    {
                        newArray[i, j] = array[i, j];
                    }
                }

                newArray.SetValue(value, firstIndex, secondIndex);
                array = newArray;
                OnArraySizeChanged(Size[0], Size[1]);
            }
        }
    }
}
