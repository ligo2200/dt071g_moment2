/*
 * Code written by Linda Götenmark, ht 2023
 * Moment 2, DT071G - Programmering i C# .NET,
 * Mid Sweden University
 * ligo2200@student.miun.se
 * 
 * This program calculates what weekday users birthday is through input in console.
 */
using System;

class Program
{
    static void Main()
    {
        //message in console
        Console.WriteLine("Ange födelsedatum i formatet ÅÅÅÅMMDD: ");
        //input from user is read and put in variable input. 
        string input = Console.ReadLine();

        //check if input-length is not 8 chars or if input can't parse input to int (if input can parse to int, then the parsed input is put in variable date).
        if (input.Length != 8 || !int.TryParse(input, out int date))
        {
            Console.WriteLine("Ogiltigt datumformat. Var god skriv datum i formatet ÅÅÅÅMMDD.");
            return;
        }

        // results of date-calculations put in different variables
        int year = date / 10000;
        int month = (date / 100) % 100;
        int day = date % 100;

        int dayOfWeek = CalculateDayOfWeek(year, month, day);

        Console.WriteLine($"Veckodagen för {input} är en {GetDayOfWeekName(dayOfWeek)}.");
    }

    //method for calculating with Zellers Congruence
    static int CalculateDayOfWeek(int year, int month, int day)
    {
        /*if month is less than 3 (0, 1 or 2) 12 is added and year is reduced by 1 
         * (in alignment to Zeller's Congruence where monthnumber starts with 3 and march which makes january the number of 13 and february makes the number 14 the year before.)
         */
        if (month < 3)
        {
            month += 12;
            year -= 1;
        }

        int k = year % 100;
        int j = year / 100;


        // Zeller's Congruence is used for calculating weekday 
        int dayOfWeek = (day + (13 * (month + 1)) / 5 + k + (k / 4) + (j / 4) - 2 * j) % 7;

        return dayOfWeek;
    }

    // method for getting the day of the week
    static string GetDayOfWeekName(int dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case 0:
                return "Lördag";
            case 1:
                return "Söndag";
            case 2:
                return "Måndag";
            case 3:
                return "Tisdag";
            case 4:
                return "Onsdag";
            case 5:
                return "Torsdag";
            case 6:
                return "Fredag";
            default:
                return "Ogiltig dag";
        }
    }
}


