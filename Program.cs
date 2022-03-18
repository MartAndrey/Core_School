using System;
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

                int option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(engine.School + "\n");
                        SchoolEngine.EndProgram();
                        Console.Clear();

                        break;

                    case 2:
                        Console.Clear();

                        engine.School.Courses.ForEach(course => System.Console.WriteLine($"Name: {course.Name}"));

                        Console.WriteLine("");
                        SchoolEngine.EndProgram();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();

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
                        int v = 0;
                        foreach (var subject in bestAverageOne)
                        {
                            Printer.WriteTitle(subject.Key);
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
                        Console.WriteLine($"1. Math\n2. Physical Education\n3. Spanish\n4. Natural Sciences");
                        int numberSubject = Int32.Parse(Console.ReadLine().ToLower());
                        switch (numberSubject)
                        {
                            case 1:
                                int j = 1;
                                if (bestAverageOne.TryGetValue("Maths", out IEnumerable<object> listMaths))
                                {
                                    foreach (var item in listMaths)
                                    {
                                        Console.WriteLine($"{j} {item}");
                                        j++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 2:
                                int z = 1;
                                if (bestAverageOne.TryGetValue("Physical Education", out IEnumerable<object> listPhysicalEducation))
                                {
                                    foreach (var item in listPhysicalEducation)
                                    {
                                        Console.WriteLine($"{z} {item}");
                                        z++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 3:
                                int w = 1;
                                if (bestAverageOne.TryGetValue("Spanish", out IEnumerable<object> listSpanish))
                                {
                                    foreach (var item in listSpanish)
                                    {
                                        Console.WriteLine($"{w} {item}");
                                        w++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 4:
                                int k = 1;
                                if (bestAverageOne.TryGetValue("Natural Sciences", out IEnumerable<object> listNaturalSciences))
                                {
                                    foreach (var item in listNaturalSciences)
                                    {
                                        Console.WriteLine($"{k} {item}");
                                        k++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;
                        }
                        break;

                    case 8:
                        Console.Clear();
                        Printer.WriteTitle("Enter the \"TOP\" number of students with the best average that you want to see");
                        int top = Int32.Parse(Console.ReadLine());

                        var bestAverage = reporter.GetBestAverangeByStudent(top);

                        foreach (var item in bestAverage)
                        {
                            int i = 0;
                            Printer.WriteTitle(item.Key);

                            foreach (var val in item.Value)
                            {
                                i++;
                                Console.WriteLine($"{i}. {val}");
                            }
                        }

                        SchoolEngine.EndProgram();
                        Console.Clear();
                        break;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("Enter the number of the subject you want to see");
                        Console.WriteLine($"1. Math\n2. Physical Education\n3. Spanish\n4. Natural Sciences");
                        int numberSubjectTop = Int32.Parse(Console.ReadLine().ToLower());

                        Printer.WriteTitle("Enter the \"TOP\" number of students with the best average that you want to see");
                        int topOne = Int32.Parse(Console.ReadLine());

                        var bestAverageO = reporter.GetBestAverangeByStudent(topOne);

                        switch (numberSubjectTop)
                        {
                            case 1:
                                int j = 1;
                                if (bestAverageO.TryGetValue("Maths", out IEnumerable<AverageStudent> listMaths))
                                {
                                    foreach (var item in listMaths)
                                    {
                                        Console.WriteLine($"{j} {item}");
                                        j++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 2:
                                int z = 1;
                                if (bestAverageO.TryGetValue("Physical Education", out IEnumerable<AverageStudent> listPhysicalEducation))
                                {
                                    foreach (var item in listPhysicalEducation)
                                    {
                                        Console.WriteLine($"{z} {item}");
                                        z++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 3:
                                int w = 1;
                                if (bestAverageO.TryGetValue("Spanish", out IEnumerable<AverageStudent> listSpanish))
                                {
                                    foreach (var item in listSpanish)
                                    {
                                        Console.WriteLine($"{w} {item}");
                                        w++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;

                            case 4:
                                int k = 1;
                                if (bestAverageO.TryGetValue("Natural Sciences", out IEnumerable<AverageStudent> listNaturalSciences))
                                {
                                    foreach (var item in listNaturalSciences)
                                    {
                                        Console.WriteLine($"{k} {item}");
                                        k++;
                                    }
                                }
                                SchoolEngine.EndProgram();
                                Console.Clear();
                                break;
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

                    default:

                        break;
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