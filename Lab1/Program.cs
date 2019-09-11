using System;

class Lab1
{

    public class Point
    {
        public double x, y;

        public Point(double abc, double ord)
        {
            x = abc;
            y = ord;
        }

        public Point()
        {

        }

    }

    //Проверка на отношение отрезков
    private static string CheckLines(Point p1, Point p2, Point p3, Point p4)
    {


        //Разположение точек слева направо
        if (p1.x > p2.x)
        {
            Point temp = p1;
            p1 = p2;
            p2 = temp;
            Console.WriteLine("X");
        }
        if (p3.x > p4.x)
        {
            Point temp = p3;
            p3 = p4;
            p4 = temp;
            Console.WriteLine("Y");
        }

        //Если конец первого отрезка расположен левее, чем начало правого, то они не пересекаются
        if (p2.x < p3.x)
        {
            return "Отрезки не пересекаются";
        }

        //Если оба отрезки вертикальные
        if ( (p2.x - p1.x == 0) && (p4.x - p3.x == 0) )
        {
            if ( Math.Max(p1.y, p2.y) < Math.Min(p3.y, p4.y) || Math.Min(p1.y, p2.y) > Math.Max(p3.y, p4.y))
            {
                return "Отрезки на одной прямой и не пересекаются";
            }
            else
            {
                if (p1.x == p3.x &&
                    p1.y == p3.y &&
                    p2.x == p4.x &&
                    p2.y == p4.y)
                {

                    return "Отрезки на одной прямой и совпадают";
                }
                else
                {
                    return "Отрезки на одной прямой и пересекаются";
                }
            }
        }

        // A*x + b = y

        if (p2.x - p1.x == 0)
        {
            double a2 = (p4.y - p3.y) / (p4.x - p3.x);
            double b2 = p3.y - a2 * p3.x;
            double PointIntersectionX = p1.x;
            double PointIntersectionY = a2 * PointIntersectionX + b2;

            if (p3.x <= PointIntersectionX &&
                p4.x >= PointIntersectionX &&
                Math.Min(p1.y, p2.y) <= PointIntersectionY &&
                Math.Max(p1.y, p2.y) >= PointIntersectionY)
            {
                return "Отрезки пересекаются в точке (" + PointIntersectionX + ", " + PointIntersectionY + ")";
            } else
            {
                return "Отрезки не пересекаются";
            }       

        } 
        else if (p4.x - p3.x == 0)
        {
            double a1 = (p2.y - p1.y) / (p2.x - p1.x);
            double b1 = p2.y - a1 * p2.x;
            double PointIntersectionX = p3.x;
            double PointIntersectionY = a1 * PointIntersectionX + b1;

            if (p1.x <= PointIntersectionX &&
                p2.x >= PointIntersectionX &&
                Math.Min(p3.y, p4.y) <= PointIntersectionY &&
                Math.Max(p3.y, p4.y) >= PointIntersectionY)
            {
                return "Отрезки пересекаются в точке (" + PointIntersectionX + ", " + PointIntersectionY + ")";
            }
            else
            {
                return "Отрезки не пересекаются";
            }
        }

        double A1 = (p2.y - p1.y) / (p2.x - p1.x);
        double B1 = A1 * p2.x - p2.y;
        double A2 = (p4.y - p3.y) / (p4.x - p3.x);
        double B2 = A2 * p3.x - p3.y;

        if (A1 == A2)
        {
            return "Отрезки параллельны";
        }

        double pointIntersectionX = (B1 - B2) / (A1 - A2);
        double pointIntersectionY = A1 * pointIntersectionX - B1;

        if ((pointIntersectionX < Math.Max(p1.x, p3.x)) || (pointIntersectionX > Math.Min(p2.x, p4.x)))
        {
            //точка X находится вне пересечения проекций отрезков на ось X 
            return "Отрезки не пересекаются";
        }

        return "Отрезки пересекаются в точке (" + pointIntersectionX + ", " + pointIntersectionY + ")";
    }

    public static void Main(string[] args)
    {
        string res;

        //Не пересекаются
        /*Point point1 = new Point(-3, 4);
        Point point2 = new Point(-1, 2);
        Point point3 = new Point(1, 1);
        Point point4 = new Point(3, 2);*/
        //Расположены на одной прямой
        /*Point point1 = new Point(1, -2);
        Point point2 = new Point(1, 1);
        Point point3 = new Point(1, 2);
        Point point4 = new Point(1, 4);*/
        //Расположены на одной прямой и совпадают
        /*Point point1 = new Point(1, -2);
        Point point2 = new Point(1, 1);
        Point point3 = new Point(1, -2);
        Point point4 = new Point(1, 1);*/
        //Первый отрезок вертикальный
        /*Point point1 = new Point(1, 0);
        Point point2 = new Point(1, 5);
        Point point3 = new Point(-3, 4);
        Point point4 = new Point(3, 1);*/
        //Второй отрезок вертикальный
        /*Point point1 = new Point(-3, 4);
        Point point2 = new Point(3, 1);
        Point point3 = new Point(1, 0);
        Point point4 = new Point(1, 5);*/
        //Отрезки параллельны
        /*Point point1 = new Point(-3, 4);
        Point point2 = new Point(3, 1);
        Point point3 = new Point(-3, 2);
        Point point4 = new Point(3, -1);*/
        //Общий случай
        /*Point point1 = new Point(-3, 4);
        Point point2 = new Point(3, 1);
        Point point3 = new Point(-1, 0);
        Point point4 = new Point(2, 3);*/

        string[] names = new string[7]
        {
            "Не пересекаются",
            "Расположены на одной прямой",
            "Расположены на одной прямой и совпадают",
            "Первый отрезок вертикальный",
            "Второй отрезок вертикальный",
            "Отрезки параллельны",
            "Общий случай"
        };

        double[, ,] points = new double[7, 4, 2] {
            {
                {-3, 4},
                {-1, 2},
                {1, 1},
                {3, 2}
            },
            {
                {1, -2},
                {1, 1},
                {1, 2},
                {1, 4}
            },
            {
                {1, -2},
                {1, 1},
                {1, -2},
                {1, 1}
            },
            {
                {1, 0},
                {1, 5},
                {-3, 4},
                {3, 1}
            },
            {
                {-3, 4},
                {3, 1},
                {1, 0},
                {1, 5}
            },
            {
                {-3, 4},
                {3, 1},
                {-3, 2},
                {3, -1}
            },
            {
                {-3, 4},
                {3, 1},
                {-1, 0},
                {2, 3}
            }
        };

        Point Point1 = new Point();
        Point Point2 = new Point();
        Point Point3 = new Point();
        Point Point4 = new Point();

        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine("\r\n" + names[i]);

            Point1.x = points[i, 0, 0];
            Point1.y = points[i, 0, 1];

            Point2.x = points[i, 1, 0];
            Point2.y = points[i, 1, 1];

            Point3.x = points[i, 2, 0];
            Point3.y = points[i, 2, 1];

            Point4.x = points[i, 3, 0];
            Point4.y = points[i, 3, 1];

            res = CheckLines(Point1, Point2, Point3, Point4);

            Console.WriteLine(res);
        }

    }
}