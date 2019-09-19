using System;

namespace ConsoleApplication3
{
    class Program
    {
        public static string getYearName(int year)
        {
            int startCycle = 1984;
            int deference = year - startCycle;

            string res = Convert.ToString(year) + " - год ";

            deference = convertToNormal(deference);
            int firstSubCycle = deference / 12;
            int secondSubCycle = deference % 12;

            switch (firstSubCycle)
            {
                case 0:
                    res += "зеленой ";
                    break;
                case 1:
                    res += "красной ";
                    break;
                case 2:
                    res += "желтой ";
                    break;
                case 3:
                    res += "белой ";
                    break;
                case 4:
                    res += "черной ";
                    break;
                default:
                    break;
            }

            switch (secondSubCycle)
            {
                case 0:
                    res += "крысы";
                    break;
                case 1:
                    res += "коровы";
                    break;
                case 2:
                    res += "тигра";
                    break;
                case 3:
                    res += "зайца";
                    break;
                case 4:
                    res += "дракона";
                    break;
                case 5:
                    res += "змеи";
                    break;
                case 6:
                    res += "лошади";
                    break;
                case 7:
                    res += "овцы";
                    break;
                case 8:
                    res += "обезьяны";
                    break;
                case 9:
                    res += "курицы";
                    break;
                case 10:
                    res += "собаки";
                    break;
                case 11:
                    res += "свиньи";
                    break;
                default:
                    break;
            }

            return res;
        }

        public static int convertToNormal(int notNormalYear)
        {
            notNormalYear %= 60;

            if (notNormalYear < 0)
	        {
                notNormalYear += 60;
	        }
            return notNormalYear;
            
        }

        static void Main(string[] args)
        {
            int[] inputData = new int[] {
                1921,
                1954,
                1984,
                2007,
                2045
            };

            foreach (var item in inputData)
            {
                Console.WriteLine(getYearName(item));
            }

            Console.ReadKey();
        }
    }
}
