using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book;
            book.title = "Mindset";
            book.author = "Dr. Carol Dweck";
            book.price = 24.99;
            Console.WriteLine("{0} by {1} was the last book I read. \nIt cost me {2}", book.title, book.author, book.price);

            Point point = new Point(10, 15);
            Console.WriteLine("x = " + point.x);
            Console.WriteLine("y = " + point.y);

            int x = (int)Days.Thursday;
            Console.WriteLine("Thursday is the {0} day of the week.", x);

     //Work with files below

            //Create a file in the project and save a string of text to it

            string stringy = "Here is my string that I'm going to write to a .txt file in this solution.\nYou can find it in the bin > debug folder.";
            File.WriteAllText("TestingSystemIO.txt", stringy);

            //Create a string that is the text file create above and WriteLine it

            string readBackStringy = File.ReadAllText("TestingSystemIO.txt");
            Console.WriteLine(readBackStringy);

            //Delete the file called "test.txt"

            File.Delete("text.txt");
            Console.WriteLine();



            //Instantiating the TimeStruct

            Console.WriteLine("Demonstrating the difference of Struct and Class:");

            TimeStruct time = new TimeStruct();
            time.Seconds = 10;

            TimeClass classTime = new TimeClass();
            classTime.Seconds = 10;

            UpdateTime(time);

            UpdateTime(classTime);

            Console.WriteLine("With a Struct we still have the value of {0}, because a copy was made.",time.Seconds); //Update the "time" variable, but it's value is still 10sec, not 11. A copy of time was modified. 


            Console.WriteLine("With a Class the value of the variable is updated to {0}.", classTime.Seconds); //Update the classTime variable and it's value is now 11

            Console.WriteLine();


            Wrapper wrapper = new Wrapper();
            wrapper.numbers = new int[3] { 10, 20, 30 };

            Console.WriteLine("The numbers currently in the array:");

            foreach (int num in wrapper.numbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();

            UpdateArray(wrapper);

            Console.WriteLine("The numbers after the UpdateArray method is called and changes the number at the index of 1:");

            foreach (int num in wrapper.numbers)
            {
                Console.WriteLine(num);
            }

        }

        public static void UpdateTime(TimeStruct time)
        {
            time.Seconds++;
        }

        public static void UpdateTime(TimeClass time)
        {
            time.Seconds++;
        }

        public static void UpdateArray(Wrapper wrapper)          
        {
            wrapper.numbers[1] = 200;
        }
    }
//Below is a struct(value type) and class(reference type), otherwise identical**********************************************
    struct TimeStruct
    {
        private int seconds;

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public int CalculateMinutes()
        {
            return seconds / 60;
        }

    }

    class TimeClass
    {
        private int seconds;

        public int Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }

        public int CalculateMinutes()
        {
            return seconds / 60;
        }
    }

    //***********************************************************************************************


    struct Wrapper
    {
        public int[] numbers;
    }

    struct Book
    {
        public string title;
        public double price;
        public string author;
    }

    struct Point
    {
        //Variables(fields)
        public int x;
        public int y;

        //Constructor - must have parameters in a struct, unlike classes
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
    }
    enum Days
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
