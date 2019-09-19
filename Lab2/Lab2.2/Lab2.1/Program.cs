using System;

namespace lab2
{
    class Program42
    {
        public static bool swapMaxValue(int[,] someMatrix)
        {
            int maxSum = -999, minSum = 999, sum, lineNumberMax = 0, lineNumberMin = 0, j = 0;

            PrintArray(someMatrix);

            for (int i = 0; i < someMatrix.GetLength(0); i++)
            {
                sum = 0;

                for (j = 0; j < someMatrix.GetLength(1); j++)
                {
                    sum += someMatrix[i, j];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        lineNumberMax = i;
                    }
                    else if (sum < minSum)
                    {
                        minSum = sum;
                        lineNumberMin = i;
                    }
                    
                }

               Console.WriteLine("Сумма строки с номером " + (i + 1) + " равна - " + sum);
            }

            int[] tempArray = new int[j];
            for (int i = 0; i < j; i++)
            {
                tempArray[i] = someMatrix[lineNumberMax, i];
               // Console.WriteLine(tempArray[i]);
            }

            for (int i = 0; i < j; i++)
            {
                 someMatrix[lineNumberMax, i] = someMatrix[lineNumberMin, i];
            }

            for (int i = 0; i < j; i++)
            {
                someMatrix[lineNumberMin, i] = tempArray[i];
            }

            // Console.WriteLine(maxSum);
            //Console.WriteLine(lineNumberMin+1);
            Console.WriteLine();
            PrintArray(someMatrix);
            return true;
        }

        public static bool PrintArray(int[,] arrayForPrint)
        {
            string str;
            for (int i = 0; i < arrayForPrint.GetLength(0); i++)
            {
                str = "";
                for (int d = 0; d < arrayForPrint.GetLength(1); d++)
                {
                    if (arrayForPrint[i, d] < 10)
                    {
                        str += " " + Convert.ToString(arrayForPrint[i, d]) + ", ";
                    }
                    else
                    {
                        str += Convert.ToString(arrayForPrint[i, d]) + ", ";
                    }
                }
                Console.WriteLine(str);
            }
            return true;
        }

        static void Main(string[] args)
        {

            int[,] matrix = new int[5, 4]
            {
                {5, 6, 7, 8 },
                {17, 18, 19, 20 },
                {13, 14, 15, 16 },
                {9, 10, 11, 12 },
                {1, 2, 3, 4 }
            };

            swapMaxValue(matrix);
        }
    }
}
