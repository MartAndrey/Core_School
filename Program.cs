﻿using System;
using System.Text.RegularExpressions;
using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {

            //AppDomain.CurrentDomain.ProcessExit += EventAction;
            var engine = new SchoolEngine();
            engine.initialize();

            Printer.WriteTitle("Welcome to school");

            var reporter = new Reporter(engine.GetObjectDictionary());
            var listEva = reporter.GetListEvaluations();
            var listSub = reporter.GetListSubjects();
            var listStu = reporter.GetListStudent();
            var listEvalBySubj = reporter.GetDictEvaBySub();
            var bestAverageOne = reporter.GetAverageStudentBySubject();

            do
            {
                Printer.Menu();

                string option = Console.ReadLine();

                Regex validationMenu = new Regex("^[0-9]{1}$");
                Regex otherValidations = new Regex("^[1-4]{1}$");
                Regex topValidations = new Regex("[0-9]");

                if (validationMenu.IsMatch(option))
                {
                    int convertOption = Int32.Parse(option);

                    switch (convertOption)
                    {
                        case 1:

                            Console.Clear();
                            Printer.WriteTitle("SCHOOL DESCRIPTION");
                            Console.WriteLine("\n" + engine.School + "\n");
                            SchoolEngine.EndProgram();
                            Console.Clear();

                            break;

                        case 2:
                            Console.Clear();

                            Printer.WriteTitle("COURSES OF THE SCHOOL");
                            Console.WriteLine("");

                            engine.School.Courses.ForEach(course => System.Console.WriteLine($"Name: {course.Name}"));

                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();

                            Printer.WriteTitle("SUBJECTS OF THE SCHOOL");
                            Console.WriteLine("");

                            foreach (var subject in listSub)
                            {
                                Console.WriteLine(subject);
                            }

                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;

                        case 4:
                            Console.Clear();

                            Printer.WriteTitle("STUDENTS OF THE SCHOOL");
                            Console.WriteLine("");

                            int s = 1;

                            foreach (var student in listStu)
                            {
                                System.Console.WriteLine($"{s}. {student.Name}");
                                s++;
                            }

                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;

                        case 5:
                            Console.Clear();

                            Printer.WriteTitle("LIST OF EVALUATIONS");
                            Console.WriteLine("");

                            int e = 1;

                            foreach (var evaluation in listEva)
                            {
                                System.Console.WriteLine($"{e}. {evaluation} ");
                                e++;
                            }

                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;

                        case 6:
                            Console.Clear();
                            foreach (var subject in bestAverageOne)
                            {
                                int v = 0;

                                Console.WriteLine("");
                                Printer.WriteTitle(subject.Key);
                                Console.WriteLine("");
                                foreach (var average in subject.Value)
                                {
                                    v++;
                                    Console.WriteLine($"{v}. {average}");
                                }
                            }

                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;

                        case 7:

                            Console.Clear();

                            Console.WriteLine("Enter the number of the subject you want to see");
                            Console.WriteLine("");
                            Printer.WriteTitle("SUBJECTS");
                            Console.WriteLine("");
                            Console.WriteLine($"1. Math\n2. Physical Education\n3. Spanish\n4. Natural Sciences");

                            string selectOption = Console.ReadLine();


                            if (otherValidations.IsMatch(selectOption))
                            {
                                int numberSubject = Convert.ToInt32(selectOption);

                                switch (numberSubject)
                                {
                                    case 1:
                                        int j = 1;
                                        if (bestAverageOne.TryGetValue("Maths", out IEnumerable<object> listMaths))
                                        {
                                            Console.WriteLine("");
                                            Printer.WriteTitle("MATH");
                                            Console.WriteLine("");

                                            foreach (var item in listMaths)
                                            {
                                                Console.WriteLine($"{j} {item}");
                                                j++;
                                            }
                                        }

                                        Console.WriteLine("");
                                        SchoolEngine.EndProgram();
                                        Console.Clear();
                                        break;

                                    case 2:
                                        int z = 1;
                                        if (bestAverageOne.TryGetValue("Physical Education", out IEnumerable<object> listPhysicalEducation))
                                        {
                                            Console.WriteLine("");
                                            Printer.WriteTitle("PHYSICAL EDUCATION");
                                            Console.WriteLine("");

                                            foreach (var item in listPhysicalEducation)
                                            {
                                                Console.WriteLine($"{z} {item}");
                                                z++;
                                            }
                                        }

                                        Console.WriteLine("");
                                        SchoolEngine.EndProgram();
                                        Console.Clear();
                                        break;

                                    case 3:
                                        int w = 1;
                                        if (bestAverageOne.TryGetValue("Spanish", out IEnumerable<object> listSpanish))
                                        {
                                            Console.WriteLine("");
                                            Printer.WriteTitle("SPANISH");
                                            Console.WriteLine("");

                                            foreach (var item in listSpanish)
                                            {
                                                Console.WriteLine($"{w} {item}");
                                                w++;
                                            }
                                        }

                                        Console.WriteLine("");
                                        SchoolEngine.EndProgram();
                                        Console.Clear();
                                        break;

                                    case 4:
                                        int k = 1;
                                        if (bestAverageOne.TryGetValue("Natural Sciences", out IEnumerable<object> listNaturalSciences))
                                        {
                                            Console.WriteLine("");
                                            Printer.WriteTitle("NATURAL SCIENCES");
                                            Console.WriteLine("");

                                            foreach (var item in listNaturalSciences)
                                            {
                                                Console.WriteLine($"{k} {item}");
                                                k++;
                                            }
                                        }

                                        Console.WriteLine("");
                                        SchoolEngine.EndProgram();
                                        Console.Clear();
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Printer.WriteTitle("Please enter a correct value");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;

                        case 8:

                            Console.Clear();
                            Printer.WriteTitle("Enter the \"TOP\" number of students with the best average that you want to see");
                            Console.WriteLine("NOTE: If the amount entered is greater than students, only the total number of students will be displayed");
                            string top = Console.ReadLine();

                            if (topValidations.IsMatch(top))
                            {
                                int selectTop = Int32.Parse(top);

                                var bestAverage = reporter.GetBestAverangeByStudent(selectTop);

                                foreach (var item in bestAverage)
                                {
                                    int i = 0;
                                    Console.WriteLine("");
                                    Printer.WriteTitle(item.Key);

                                    foreach (var val in item.Value)
                                    {
                                        i++;
                                        Console.WriteLine($"{i}. {val}");
                                    }
                                }

                                Console.WriteLine("");
                                SchoolEngine.EndProgram();
                                Console.Clear();
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Printer.WriteTitle("Please enter a correct value");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                        case 9:

                            Console.Clear();

                            Console.WriteLine("Enter the number of the subject you want to see");
                            Console.WriteLine("");
                            Printer.WriteTitle("SUBJECTS");
                            Console.WriteLine("");
                            Console.WriteLine($"1. Math\n2. Physical Education\n3. Spanish\n4. Natural Sciences");

                            string subjectTop = Console.ReadLine();

                            if (otherValidations.IsMatch(subjectTop))
                            {
                                int numberSubjectTop = Int32.Parse(subjectTop);

                                Printer.WriteTitle("Enter the \"TOP\" number of students with the best average that you want to see");
                                Console.WriteLine("NOTE: If the amount entered is greater than students, only the total number of students will be displayed");

                                string topOne = Console.ReadLine();

                                if (topValidations.IsMatch(topOne))
                                {
                                    int selectTopOne = Int32.Parse(topOne);

                                    var bestAverageO = reporter.GetBestAverangeByStudent(selectTopOne);

                                    switch (numberSubjectTop)
                                    {
                                        case 1:
                                            int j = 1;

                                            if (bestAverageO.TryGetValue("Maths", out IEnumerable<AverageStudent> listMaths))
                                            {
                                                Console.Clear();

                                                Console.WriteLine("");
                                                Printer.WriteTitle("MATH");
                                                Console.WriteLine("");

                                                foreach (var item in listMaths)
                                                {
                                                    Console.WriteLine($"{j}. {item}");
                                                    j++;
                                                }
                                            }

                                            Console.WriteLine("");
                                            SchoolEngine.EndProgram();
                                            Console.Clear();
                                            break;

                                        case 2:

                                            int z = 1;

                                            if (bestAverageO.TryGetValue("Physical Education", out IEnumerable<AverageStudent> listPhysicalEducation))
                                            {
                                                Console.Clear();

                                                Console.WriteLine("");
                                                Printer.WriteTitle("PHYSICAL EDUCATION");
                                                Console.WriteLine("");

                                                foreach (var item in listPhysicalEducation)
                                                {
                                                    Console.WriteLine($"{z}. {item}");
                                                    z++;
                                                }
                                            }

                                            Console.WriteLine("");
                                            SchoolEngine.EndProgram();
                                            Console.Clear();
                                            break;

                                        case 3:
                                            int w = 1;

                                            if (bestAverageO.TryGetValue("Spanish", out IEnumerable<AverageStudent> listSpanish))
                                            {
                                                Console.Clear();

                                                Console.WriteLine("");
                                                Printer.WriteTitle("SPANISH");
                                                Console.WriteLine("");

                                                foreach (var item in listSpanish)
                                                {
                                                    Console.WriteLine($"{w}. {item}");
                                                    w++;
                                                }
                                            }

                                            Console.WriteLine("");
                                            SchoolEngine.EndProgram();
                                            Console.Clear();
                                            break;

                                        case 4:
                                            int k = 1;

                                            if (bestAverageO.TryGetValue("Natural Sciences", out IEnumerable<AverageStudent> listNaturalSciences))
                                            {
                                                Console.Clear();

                                                Console.WriteLine("");
                                                Printer.WriteTitle("NATURAL SCIENCES");
                                                Console.WriteLine("");

                                                foreach (var item in listNaturalSciences)
                                                {
                                                    Console.WriteLine($"{k}. {item}");
                                                    k++;
                                                }
                                            }

                                            Console.WriteLine("");
                                            SchoolEngine.EndProgram();
                                            Console.Clear();
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Printer.WriteTitle("Please enter a correct value");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Printer.WriteTitle("Please enter a correct value");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                        case 0:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Printer.WriteTitle("ARE YOU SURE YOU WANT TO GO OUT");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            SchoolEngine.EndProgram();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Printer.WriteTitle("Please enter a correct value");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            } while (true);
        }


        /* private static void EventAction(object? sender, EventArgs e)
        {
            Printer.WriteTitle("Coming out");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("Exit");
        } */

        private static void PrintCoursesSchool(School school)
        {
            Printer.WriteTitle("Courses of the School");

            if (school?.Courses != null)
            {
                foreach (var course in school.Courses)
                {
                    Console.WriteLine($"Name {course.Name}, Id {course.UniqueId}");
                }
            }
        }
    }
}