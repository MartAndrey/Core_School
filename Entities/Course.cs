using System;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class Course : BaseSchoolObject, IPlace
    {
        public TypesWorkingDay WorkingDay { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }
        public void CleanPlace()
        {
            Printer.DrawLine();
            System.Console.WriteLine("Cleaning establishment... ");
            System.Console.WriteLine($"Course {Name} clean ");
        }
    }
}