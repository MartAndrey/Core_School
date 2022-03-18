using CoreSchool.Entities;

namespace CoreSchool.App
{
    public class Reporter
    {
        Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> _dictionary;

        public Reporter(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dicObjSchool)
        {
            if (dicObjSchool == null) throw new ArgumentNullException(nameof(dicObjSchool));

            _dictionary = dicObjSchool;
        }
        
        public IEnumerable<Student> GetListStudent()
        {
            if (_dictionary.TryGetValue(KeyDictionary.Student, out IEnumerable<BaseSchoolObject> list))
            {
                return list.Cast<Student>();
            }
            else
            {
                return new List<Student>();
            }
        }
        public IEnumerable<Evaluation> GetListEvaluations()
        {
            if (_dictionary.TryGetValue(KeyDictionary.Evaluation, out IEnumerable<BaseSchoolObject> list))
            {
                return list.Cast<Evaluation>();
            }
            else
            {
                return new List<Evaluation>();
            }
        }

        public IEnumerable<string> GetListSubjects()
        {
            return GetListSubjects(out var dummy);
        }
        public IEnumerable<string> GetListSubjects(out IEnumerable<Evaluation> listEvaluations)
        {
            listEvaluations = GetListEvaluations();

            return (from Evaluation ev in listEvaluations
                    select ev.Subject.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluation>> GetDictEvaBySub()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluation>>();
            var listSub = GetListSubjects(out var listEval);

            foreach (var subj in listSub)
            {
                var evalBySub = from eval in listEval
                                where eval.Subject.Name == subj
                                select eval;

                dicRta.Add(subj, evalBySub);
            }

            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> GetAverageStudentBySubject()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalBySubj = GetDictEvaBySub();

            foreach (var subjWithEval in dicEvalBySubj)
            {
                var averangeStudent = from eval in subjWithEval.Value
                                      group eval by new { eval.Student.UniqueId, eval.Student.Name }
                                      into groupEvalByStudent
                                      select new AverageStudent()
                                      {
                                        studentId = groupEvalByStudent.Key.UniqueId,
                                        studentName = groupEvalByStudent.Key.Name,
                                        average = groupEvalByStudent.Average(evalu => evalu.Note)
                                      };

                rta.Add(subjWithEval.Key, averangeStudent);
            }

            return rta;
        }

        public Dictionary<string, IEnumerable<AverageStudent>> GetBestAverangeByStudent(int topAverage = 10)
        {
            var rta = new Dictionary<string, IEnumerable<AverageStudent>>();
            var dicAverageStudBySubj = GetAverageStudentBySubject(); 

            foreach (var average in dicAverageStudBySubj)
            {
                var BestStudent = (from AverageStudent eval in  average.Value
                                  orderby eval.average descending
                                  select eval).Take(topAverage);
                
                rta.Add(average.Key, BestStudent);
            }
            return rta;
        }
    }
}