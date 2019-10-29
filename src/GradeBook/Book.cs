using System;
using System.Collections.Generic;

namespace GradeBook
{

    /* Think of a class as a blueprint. It describes how you're
    going to build objects */
    public class Book 
    {
        public Book(string name)
        {
            grades = new List<double>(); 
            Name = name;
        }
        // Instance member/method associated with object type Book
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
           
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            } 
            result.Average /= grades.Count;

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                
                default:
                    result.Letter = 'F';
                    break;                
            }
            return result;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("book name cannot be empty");
                }
           
            }
        }
       /* One of the ways to add state to a class definition. This
        way is adding a "field definition" (inside the class but 
        outside of any method). This field will be carried around throughout  
        the lifetime of the object. With a field you cannot use implicit
        typing. Any methods insided this class have access to this
        field */
        private List<double> grades;
        private string name;
    }
}