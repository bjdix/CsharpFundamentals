using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    { 
        /* Static members are not associated with an
        object's instance. Only available through type
        name of class in which it's defined  */
        static void Main(string[] args)
        {
            // Class instantiation
            var book = new Book("Ben's Grade Book");

            var done = false;

            while(!done)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    done = true;
                    continue;
                }

                try 
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"lowest grade: {stats.Low}");
            Console.WriteLine($"highest grade: {stats.High}");
            Console.WriteLine($"average grade: {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
