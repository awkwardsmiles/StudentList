using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsLinq
{
    public class Student
    {
        public string Surname { get; set; }
        public string Forenames { get; set; }
        public int Age { get; set; }       
        public string Course { get; set; }
        public int Mark { get; set; }
        public int EnrolmentYear { get; set; }

        //  queries can show a full name
        public string FullName => $"{Forenames} {Surname}";

        // Default constructor
        public Student()
        {
            Surname = "Unknown";
            Forenames = "Unknown";
            Age = 0;
            Course = "Unknown";
            Mark = 0;
            EnrolmentYear = 0;
        }

        // Constructor to initialise all properties
        public Student(string surname, string forenames, int age,
            string course, int mark, int enrolmentYear)
        {
            Surname = surname;
            Forenames = forenames;
            Age = age;
            Course = course;
            Mark = mark;
            EnrolmentYear = enrolmentYear;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"{Surname}, {Forenames} (Age: {Age}). {Course}. " +
                   $"\n   Mark: {Mark}, Enrolment Year: {EnrolmentYear}";
        }
    }
}