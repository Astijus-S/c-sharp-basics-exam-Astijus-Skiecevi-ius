

namespace c_sharp_basics_exam_Astijus_Skiecevičius.Entities
{
    public class Grades
    {
        public int Grade { get; set; }
        public int Trimester { get; set; }
        public int Id { get; set; }
        public Grades()
        {

        }
        public Grades(int id, int trimester, int grade)
        {
            Trimester = trimester;
            Grade = grade;
            Id = id;
        }
    }
}
