

using c_sharp_basics_exam_Astijus_Skiecevičius.Entities;

namespace c_sharp_basics_exam_Astijus_Skiecevičius.Repositories
{
    public class StudentsRepository
    {
        private List<Students> students = new List<Students>();

        public StudentsRepository()
        {
            students.Add(new Students("Joe", "Johnson", 1));
            students.Add(new Students("Tim", "Mathews", 2));
            students.Add(new Students("Gerard", "Bradley", 3));
            students.Add(new Students("Ellinore", "Blue", 4));
            students.Add(new Students("Kacey", "Smithy", 5));
            students.Add(new Students("Timmothy", "Walton", 6));
            students.Add(new Students("Helen", "Starr", 7));
            students.Add(new Students("Jim", "Jimbo", 8));
            students.Add(new Students("Doug", "Thomas", 9));

        }

        public Students Retrieve(string lastName)
        {
            var student = students.FirstOrDefault(x => x.LastName == lastName);
            return student;
        }
        public List<Students> Retrieve()
        {
            return students;
        }
        public static List<Students> AddStudent(StudentsRepository studentsRepository)
        {
            Console.WriteLine("Enter the students first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the students last name:");
            string lastName = Console.ReadLine();
            studentsRepository.AddNewStudent(firstName, lastName);
            var students = studentsRepository.Retrieve();
            return students;
        }

        public List<Students> AddNewStudent(string firstName, string lastName)
        {
            int id = students.Count + 1;
            students.Add(new Students(firstName, lastName, id));
            return students;
        }

        public static List<Students> DeleteStudent(StudentsRepository studentsRepository)
        {
            Console.WriteLine("Enter the students last name:");
            string lastName = Console.ReadLine();
            studentsRepository.DeleteStudent(lastName);
            var students = studentsRepository.Retrieve();
            return students;
        }

        public void DeleteStudent(string lastName)
        {
            var students = Retrieve();
            var studentDelete = students.SingleOrDefault(x => x.LastName == lastName);
            students.Remove(studentDelete);
            
        }



    }

}
