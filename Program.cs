using System;

class Program
{
    static void Main()
    {
        double year;
        byte month, day;

        Console.WriteLine("Введите сегодняшнюю дату (число, месяц, год)");
        string data = Console.ReadLine();

        if (data.Length==0)
        {
            Console.WriteLine("Пустой ввод");
            Console.ReadKey();
            return;
        }
        for (int i = 0; i < data.Length; i++)
        {
            if (Char.IsLetter(data[i]))
            {
                Console.WriteLine("Неверный формат ввода");
                Console.ReadKey();
                return;
            }
        }

        string[] nums = data.Split(' ');
        if (nums.Length != 3)
        {
            Console.WriteLine("Неверный формат ввода. Введите три числа через пробел");
            Console.ReadKey();
            return;
        }

        try
        {
            if (!byte.TryParse(nums[0], out day) || !byte.TryParse(nums[1], out month))
            {
                Console.WriteLine("Неверный формат числа или число слишком большое");
                Console.ReadKey();
                return;
            }
            if (!double.TryParse(nums[2], out year) || year < 1 || year > 9999)
            {
                Console.WriteLine("Год должен быть в диапазоне от 1 до 9999");
                Console.ReadKey();
                return;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Введено слишком большое число");
            Console.ReadKey();
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Неверный формат числа");
            Console.ReadKey();
            return;
        }
        if (month < 1 || month > 12 || day < 1 || day > 31)
        {
            Console.WriteLine("Неверная дата");
            Console.ReadKey();
            return;
        }

        bool leap = ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0)));
        byte[] daysInMonth = new byte[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (leap)
        {
            daysInMonth[1] = 29;
        }

        if (day > daysInMonth[month - 1])
        {
            Console.WriteLine("Такого дня не существует в данном месяце");
            Console.ReadKey();
            return;
        }

        day += 1;

        if (day > daysInMonth[month - 1])
        {
            day = 1;
            month += 1;
            if (month > 12)
            {
                year += 1;
                month = 1;
            }
        }

        Console.WriteLine($"Завтра {day} {month} {year}");
        Console.ReadKey();
    }
}