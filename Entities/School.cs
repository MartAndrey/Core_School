using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class School : BaseSchoolObject, IPlace
    {
        public int YearOfCreation { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public TypesSchool TypeSchool { get; set; }
        public List<Course> Courses { get; set; }
        public School(string name, int year) => (Name, YearOfCreation) = (name, year);

        public School(string name, int year, TypesSchool type, string country = "", string city = "")
        {
            this.Name = name;
            this.YearOfCreation = year;
            this.Country = country;
            this.City = city;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nType: {TypeSchool} {System.Environment.NewLine}Country: {Country}\nCity: {City}";
        }

        public void CleanPlace()
        {
            Printer.DrawLine();
            System.Console.WriteLine("Cleaning School... ");
            Courses.ForEach(course => course.CleanPlace());
            Printer.WriteTitle($"School {Name} clean ");
        }
    }
}