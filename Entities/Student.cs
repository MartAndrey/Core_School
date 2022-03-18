using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Student : BaseSchoolObject
    {
        public List<Subject> Subjects { get; set; }
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}