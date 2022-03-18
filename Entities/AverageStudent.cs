namespace CoreSchool.Entities
{
    public class AverageStudent
    {
        public float average;
        public string studentId;
        public string studentName;

        public override string ToString()
        {
            return $"Student: {studentName}, Average: {average:N1}";
        }
    }
}