using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchool.App
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }


        public SchoolEngine()
        {

        }

        public void initialize()
        {
            School = new School("Platzi Academy", 2014, TypesSchool.Primaria, country: "Colombia", city: "Bogota");

            LoadCourses();
            LoadSubjects();
            LoadEvaluations();
        }

        public static void BackProgram()
        {
            ConsoleKeyInfo tecla;

            Console.WriteLine("Press \"ENTER\" to back or press \"ESC\" to end program");
            tecla = Console.ReadKey();

            while (tecla.Key != ConsoleKey.Enter)
            {
                if (tecla.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Printer.WriteTitle("Finished Program");
                    Environment.Exit(0);
                }

                Console.WriteLine($" is not the correct key, press the correct key");
                tecla = Console.ReadKey();
            }
        }

        public static void EndProgram()
        {
            ConsoleKeyInfo tecla;

            Console.WriteLine("Press \"ENTER\" to return to the menu or press \"ESC\" to end program");
            tecla = Console.ReadKey();

            while (tecla.Key != ConsoleKey.Enter)
            {
                if (tecla.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Printer.WriteTitle("Finished Program");
                    Environment.Exit(0);
                }

                Console.WriteLine($" is not the correct key, press the correct key");
                tecla = Console.ReadKey();
            }
        }
        public void PrinterDictionary(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dic, bool prinEvalu = false)
        {
            foreach (var objKey in dic)
            {
                Printer.WriteTitle($"{objKey.Key}");

                foreach (var val in objKey.Value)
                {
                    switch (objKey.Key)
                    {
                        case KeyDictionary.School:
                            Console.WriteLine("School: " + val);
                            break;

                        case KeyDictionary.Course:
                            var curTmp = val as Course;
                            if (curTmp != null)
                            {
                                int count = curTmp.Students.Count;
                                Console.WriteLine("Course: " + val.Name + " Number of students " + count);
                            }
                            break;

                        case KeyDictionary.Student:
                            Console.WriteLine("Student: " + val.Name);
                            break;

                        case KeyDictionary.Evaluation:
                            Console.WriteLine(val);
                            break;

                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        public Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> GetObjectDictionary()
        {
            var diccionary = new Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>>();

            diccionary.Add(KeyDictionary.School, new[] { School });
            diccionary.Add(KeyDictionary.Course, School.Courses);

            var listTmpSt = new List<Student>();
            var listTmpSb = new List<Subject>();
            var listTmpEv = new List<Evaluation>();

            School.Courses.ForEach(course =>
            {
                listTmpSt.AddRange(course.Students);
                listTmpSb.AddRange(course.Subjects);

                course.Students.ForEach(student => listTmpEv.AddRange(student.Evaluations));
            });
            diccionary.Add(KeyDictionary.Student, listTmpSt);
            diccionary.Add(KeyDictionary.Subject, listTmpSb);
            diccionary.Add(KeyDictionary.Evaluation, listTmpEv);

            return diccionary;
        }

        public IReadOnlyList<BaseSchoolObject> GetObjectSchool(bool bringCourses = true, bool bringStudents = true, bool bringSubjects = true, bool bringEvaluations = true)
        {
            return GetObjectSchool(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<BaseSchoolObject> GetObjectSchool(out int countCourses,
                                                               bool bringCourses = true, bool bringStudents = true, bool bringSubjects = true, bool bringEvaluations = true)
        {
            return GetObjectSchool(out countCourses, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<BaseSchoolObject> GetObjectSchool(out int countCourses, out int countStudents,
                                                               bool bringCourses = true, bool bringStudents = true, bool bringSubjects = true, bool bringEvaluations = true)
        {
            return GetObjectSchool(out countCourses, out countStudents, out int dummy, out dummy);
        }

        public IReadOnlyList<BaseSchoolObject> GetObjectSchool(out int countCourses, out int countStudents, out int countSubjects,
                                                               bool bringCourses = true, bool bringStudents = true, bool bringSubjects = true, bool bringEvaluations = true)
        {
            return GetObjectSchool(out countCourses, out countStudents, out countSubjects, out int dummy);
        }

        public IReadOnlyList<BaseSchoolObject> GetObjectSchool(out int countCourses, out int countStudents, out int countSubjects, out int countEvaluations,
                                                               bool bringCourses = true, bool bringStudents = true, bool bringSubjects = true, bool bringEvaluations = true)
        {
            countStudents = countSubjects = countEvaluations = 0;

            var listObj = new List<BaseSchoolObject>();

            listObj.Add(School);

            if (bringCourses) listObj.AddRange(School.Courses);

            countCourses = School.Courses.Count;
            foreach (var course in School.Courses)
            {
                countStudents += course.Students.Count;
                countSubjects += course.Subjects.Count;

                if (bringStudents) listObj.AddRange(course.Students);

                if (bringSubjects) listObj.AddRange(course.Subjects);

                if (bringEvaluations)
                {
                    foreach (var student in course.Students)
                    {
                        listObj.AddRange(student.Evaluations);
                        countEvaluations += student.Evaluations.Count;
                    }
                }
            }

            return listObj.AsReadOnly();
        }

        #region charging methods
        private void LoadCourses()
        {
            School.Courses = new List<Course>(){ new Course() { Name = "101", WorkingDay = TypesWorkingDay.Morning },
                                                 new Course() { Name = "201", WorkingDay = TypesWorkingDay.Morning },
                                                 new Course() { Name = "301", WorkingDay = TypesWorkingDay.Morning },
                                                 new Course() { Name = "401", WorkingDay = TypesWorkingDay.Afternoon },
                                                 new Course() { Name = "501", WorkingDay = TypesWorkingDay.Afternoon }
                                               };

            Random rnd = new Random();

            foreach (var course in School.Courses)
            {
                int quantityRandom = rnd.Next(5, 21);
                course.Students = GeneratingRandomStudents(quantityRandom);
            }
        }
        private void LoadSubjects()
        {
            foreach (var course in School.Courses)
            {
                var ListSubjects = new List<Subject>(){ new Subject { Name = "Maths" },
                                                         new Subject { Name = "Physical Education" },
                                                         new Subject { Name = "Spanish" },
                                                         new Subject { Name = "Natural Sciences" }
                                                       };
                course.Subjects = ListSubjects;
                foreach (var student in course.Students)
                {
                    student.Subjects = ListSubjects;
                }
            }

        }
        private void LoadEvaluations()
        {
            foreach (var course in School.Courses)
            {
                foreach (var student in course.Students)
                {
                    foreach (var subject in course.Subjects)
                    {
                        var ListEvaluations = new List<Evaluation>(){ new Evaluation { Subject = subject, Name = $"{subject.Name} Ev# 1", Note = GeneratingRandomsNote(), Student = student },
                                                                      new Evaluation { Subject = subject, Name = $"{subject.Name} Ev# 2", Note = GeneratingRandomsNote(), Student = student },
                                                                      new Evaluation { Subject = subject, Name = $"{subject.Name} Ev# 3", Note = GeneratingRandomsNote(), Student = student },
                                                                      new Evaluation { Subject = subject, Name = $"{subject.Name} Ev# 4", Note = GeneratingRandomsNote(), Student = student },
                                                                      new Evaluation { Subject = subject, Name = $"{subject.Name} Ev# 5", Note = GeneratingRandomsNote(), Student = student }
                                                                    };

                        student.Evaluations.AddRange(ListEvaluations);
                    }
                }
            }
        }

        private List<Student> GeneratingRandomStudents(int quantity)
        {
            string[] name1 = { "Yuna", "Ryujin", "Momo", "Sana", "Jisso", "Jenny", "Ikura" };
            string[] lastName1 = { "Shin", "Son", "Hirai", "Minatozaki", "Kim", "Park", "Lilas" };
            string[] name2 = { "Lia", "Rose", "Lisa", "Nayeon", "Dahyun", "Chaeyoung", "Wendy" };

            var listStudents = from n1 in name1
                               from n2 in name2
                               from a1 in lastName1
                               select new Student { Name = $"{n1} {n2} {a1}" };

            return listStudents.OrderBy((al) => al.UniqueId).Take(quantity).ToList();
        }

        private float GeneratingRandomsNote()
        {
            Random rnd = new Random();
            return (float)(5 * rnd.NextDouble());
        }

        #endregion charging methods
    }
}