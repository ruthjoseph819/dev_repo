
using System;

namespace DateApp
{
    public  class Program
    {
        // Find values of day and month from
        // offset of result year.
        static int m2, d2;

        // Return if year is leap year or not.
        static bool isLeap(int y)
        {
            if (y % 100 != 0 && y % 4 == 0 || y % 400 == 0)
                return true;

            return false;
        }

        // Given a date, returns number of days elapsed
        // from the beginning of the current year (1st
        // jan).
        static int offsetDays(int d, int m, int y)
        {
            int offset = d;

            if (m - 1 == 11)
                offset += 335;
            if (m - 1 == 10)
                offset += 304;
            if (m - 1 == 9)
                offset += 273;
            if (m - 1 == 8)
                offset += 243;
            if (m - 1 == 7)
                offset += 212;
            if (m - 1 == 6)
                offset += 181;
            if (m - 1 == 5)
                offset += 151;
            if (m - 1 == 4)
                offset += 120;
            if (m - 1 == 3)
                offset += 90;
            if (m - 1 == 2)
                offset += 59;
            if (m - 1 == 1)
                offset += 31;

            if (isLeap(y) && m > 2)
                offset += 1;

            return offset;
        }

        // Given a year and days elapsed in it, finds
        // date by storing results in d and m.
        static void revoffsetDays(int offset, int y)
        {
            int[] month = { 0, 31, 28, 31, 30, 31, 30,
                    31, 31, 30, 31, 30, 31 };

            if (isLeap(y))
                month[2] = 29;
            int i;
            for (i = 1; i <= 12; i++)
            {
                if (offset <= month[i])
                    break;
                offset = offset - month[i];
            }

            d2 = offset;
            m2 = i;
        }

        // Add x days to the given date.
        public static string addDaysToDate( string DateInput, int x)
        {
            //splitting the given date into date,month and year
            string[] DateTimeArray = DateInput.Split('/');

            //String DateTime 
            //string ResultStringDateTime = "";

            int d = int.Parse(DateTimeArray[0]), m = int.Parse(DateTimeArray[1]), y = int.Parse(DateTimeArray[2]);
            int offset1 = offsetDays(d, m, y);
            int remDays = isLeap(y) ? (366 - offset1) : (365 - offset1);

            // y2 is going to store result year and
            // offset2 is going to store offset days
            // in result year.
            int y2, offset2 = 0;
            if (x <= remDays)
            {
                y2 = y;
                offset2 = offset1 + x;
            }

            else
            {
                // x may store thousands of days.
                // We find correct year and offset
                // in the year.
                x -= remDays;
                y2 = y + 1;
                int y2days = isLeap(y2) ? 366 : 365;
                while (x >= y2days)
                {
                    x -= y2days;
                    y2++;
                    y2days = isLeap(y2) ? 366 : 365;
                }
                offset2 = x;
            }
            revoffsetDays(offset2, y2);
            //Console.WriteLine("d2 = " + d2 + ", m2 = " +
            //m2 + ", y2 = " + y2);
            string OutStr = d2 + "/" + m2 + "/" + y2;
            return OutStr;
            //Console.WriteLine("New date is:" + OutStr );
        }

        // Driven Program
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Your Date In dd/mm/yyyy Format: ");
            //you input your string dateTime Like 2/12/2013
            //string DateInput = "2/12/2013";

            string DateInput = Console.ReadLine();
                       
            Console.WriteLine("Please Enter days to be added: ");

            int days = int.Parse(Console.ReadLine());
            string OutDate = addDaysToDate(DateInput , days);
            Console.WriteLine("\nNew date is : " + OutDate);
        }
    }
}