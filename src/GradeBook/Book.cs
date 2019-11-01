using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    /* Delegate definition, usually in C# it is
    one type per .cs file. Here it is added to save time, */
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                 writer.WriteLine(grade);
                 if(GradeAdded != null)
                 {
                     GradeAdded(this, new EventArgs());
                 }
            } 
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
    /* Think of a class as a blueprint. It describes how you're
    going to build objects */
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>(); 
            Name = name;
        }
        // Instance member/method associated with object type Book
        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
           
        }

        // An Event with type Delegate
        public override event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach(var grade in grades)
            {
                result.Add(grade);
            } 
            return result;
        }

       /* One of the ways to add state to a class definition. This
        way is adding a "field definition" (inside the class but 
        outside of any method). This field will be carried around throughout  
        the lifetime of the object. With a field you cannot use implicit
        typing. Any methods insided this class have access to this
        field */
        private List<double> grades;
        public const string CATEGORY = "Science";
        //private string name;
    }
}