using System.Globalization;
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

        


        static void Main()
        {
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

            
        }
    }
}
