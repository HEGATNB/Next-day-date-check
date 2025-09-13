using System;

double year;
byte month, day;
Console.WriteLine("Введите сегодняшнюю дату (число, месяц, год)");
string data = Console.ReadLine();
string[] nums = data.Split(' ');
year = Convert.ToDouble(nums[2]);
month = Convert.ToByte(nums[1]);
day = Convert.ToByte(nums[0]);
if (month < 1 || month > 12 || day < 1 || day > 31)
{
    Console.WriteLine("Неверная дата");
    Console.ReadKey();
    return;
}
bool leap = ((year % 4 == 0) && ((year % 100 != 0) || (year % 400 == 0))) ? true : false;
day += 1;
byte[] daysInMonth = new byte[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
if (leap)
{
    daysInMonth[1] = 28;
}
if (day> daysInMonth[month-1])
{
    day = 1;
    month += 1;
    if (month > 12)
    {
        year += 1;
        month = 1;
        day = 1;
    }
    year += 1;

}

Console.WriteLine($"Завтра { day} { month} { year} ");
Console.ReadKey();