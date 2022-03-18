namespace CoreSchool.Entities
{
    public class Evaluation : BaseSchoolObject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Note { get; set; }

        public override string ToString()
        {
            return $"{Note:N1}, {Student.Name}, {Subject.Name}";
        }
    }
}