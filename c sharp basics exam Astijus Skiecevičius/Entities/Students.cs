

namespace c_sharp_basics_exam_Astijus_Skiecevičius.Entities
{
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public Students()
        {

        }

        public Students(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }
    }
}
