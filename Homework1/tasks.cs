using System.Globalization;
using System.Numerics;
using static System.Console;
using static System.Math;
namespace Homework1
{
    internal class tasks
    {
        /// <summary>
        /// Фунция, которая обнуляет разряд десятков.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static void NullDec(ref int number)
        {
            if ((Abs(number) <= 99) || (Abs(number) >= 1000))
                throw new ArgumentException("Число должно быть трехзначным!");

            var (pow10, res) = (1, 0);
            while (Abs(number) > 0)
            {
                var digit = number % 10;
                if (pow10 == 10)
                    digit = 0;
                res += digit * pow10;
                pow10 *= 10;
                number /= 10;
            }
            number = res;
        }
        /// <summary>
        /// Функция, которая определяет цвет точки по ее координатам.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static string Chess(int x, int y)
        {
            if ((x <= 0) || (x >= 9) || (y <= 0) || (y >= 9))
                throw new ArgumentException("Координаты введены неверно!");
            if ((x + y) % 2 == 0)
                return "Черного";
            return "Белого";

        }

        /// <summary>
        /// Функция, которая считает кол-во корней квадратного уравнения.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static int CountRoots(int a, int b, int c)
        {
            var D = Pow(b, 2) - 4 * a * c;
            if ((D < 0) || (a == 0))
                throw new ArgumentException("Нет корней квадратного уравнения");
            if (D == 0)
                return 1;
            return 2;
        }

        /// <summary>
        /// Функция, которая возвращает минимальное вещественное число. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static double MyMin(double x, double y)
        {
            if (x < y)
                return x;
            return y;
        }

        /// <summary>
        /// Функция, которая вычисляет произведение чисел от A до B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static double MultAB(int A, int B)
        {
            if (A > B)
                (A, B) = (B, A);
            int firstEven = A;
            double res = 1;
            if (firstEven % 2 != 0)
            {
                firstEven = A + 1;
            }
            if (A == B)
                return 0;
            for (int i = firstEven; i <= B; i += 2)
                res *= i;
            return res;
        }

        /// <summary>
        /// Функция, которая находит числа последовательности меньше K а также, делящихся на него нацело.
        /// </summary>
        /// <param name="K"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static (int, int) CountNumberLessAndDiv(int K)
        {
            var (count1, count2) = (0, 0);
            if (K == 0)
                throw new ArgumentException("K не должно быть равно 0!");
            int x = int.Parse(ReadLine());
            while (x != 0)
            {
                if (x < K)
                    count1++;
                if ((x % K) == 0)
                    count2++;
                else if (x == 0)
                    break;
                x = int.Parse(ReadLine());
            }
            return (count1, count2);
        }


        enum Seasons
        {
            Winter, Spring, Summer, Autumn
        }

        /// <summary>
        /// Метод, который по номеру месяца возвращаяет время года.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        static Seasons TimeOfYear(int n)
        {
            if ((n >= 13) || (n <= 0))
                throw new ArgumentException("Кол-во месяцев в году 1-12!");
            return n switch
            {
                12 or 1 or 2 => Seasons.Winter,
                3 or 4 or 5 => Seasons.Spring,
                6 or 7 or 8 => Seasons.Summer,
                9 or 10 or 11 => Seasons.Autumn
            };
        }

        /// <summary>
        /// Метод, выводящий на консоль N строк.
        /// </summary>
        /// <param name="n"></param>
        /// <exception cref="ArgumentException"></exception>
        static void RandSeason(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Количество строк должно быть положительным числом!");
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int month = rnd.Next(1, 13);
                Seasons season = TimeOfYear(month);
                WriteLine($"Месяц №{month}, его сезон: {season}");
            }
        }

        static void Main()
        {
            /// Задание №1
            WriteLine("Задание №1: ");
            Write("Введите трехзначное число: ");
            var number = int.Parse(ReadLine());
            try
            {
                NullDec(ref number);
                Write($"Число с обнуленным разрядом десятков: {number}");

            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine();

            /// Задание №2
            WriteLine("Задание №2: ");
            Write("Введите координату x(1-8): ");
            var x = int.Parse(ReadLine());
            Write("Введите координату y(1-8): ");
            var y = int.Parse(ReadLine());
            try
            {
                WriteLine($"Поле с координатами ({x}, {y}) {Chess(x, y)} цвета");
            }

            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine();

            /// Задание №3
            WriteLine("Задание №3: ");
            Write("Введите число a: ");
            var a = int.Parse(ReadLine());
            Write("Введите число b: ");
            var b = int.Parse(ReadLine());
            Write("Введите число c: ");
            var c = int.Parse(ReadLine());
            try
            {
                WriteLine($"Количество корней квадратного уравнения: {CountRoots(a, b, c)}");
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine();

            /// Задание №4
            WriteLine("Задание №4: ");
            Write("Введите число x1: ");
            var x1 = double.Parse(ReadLine());
            Write("Введите число y1: ");
            var y1 = double.Parse(ReadLine());
            WriteLine($"Минимальное число: {MyMin(x1, y1)}");
            WriteLine();

            /// Задание №5
            WriteLine("Задание №5: ");
            Write("Введите число A: ");
            var A = int.Parse(ReadLine());
            Write("Введите число B: ");
            var B = int.Parse(ReadLine());
            WriteLine($"Произведение чётных чисел от {A} до {B} = {MultAB(A, B)}");
            WriteLine();

            /// Задание №6
            WriteLine("Задание №6: ");
            WriteLine("Введите число K: ");
            var K = int.Parse(ReadLine());
            WriteLine("Введите последовательность чисел оканчивающуюся 0: ");
            try
            {
                WriteLine($"Количество чисел меньших K a также делящихся на него: {CountNumberLessAndDiv(K)}");
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine();

            /// Задание №7
            WriteLine("Задание №7: ");
            Write("Введите номер месяца: ");
            int n = int.Parse(ReadLine());
            try
            {
                WriteLine($"Время года: {TimeOfYear(n)}");
            }
            catch (AggregateException ex)
            {
                WriteLine(ex.Message);
            }
            WriteLine();

            /// Задание №8
            WriteLine("Задание №8: ");
            try
            {
                RandSeason(n);
            }
            catch (AggregateException ex)
            {
                WriteLine(ex.Message);
            }
        }
    }
}
