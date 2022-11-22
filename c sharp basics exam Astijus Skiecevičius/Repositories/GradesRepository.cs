
using c_sharp_basics_exam_Astijus_Skiecevičius.Entities;

namespace c_sharp_basics_exam_Astijus_Skiecevičius.Repositories
{
    public class GradesRepository
    {
        private List<Grades> grades = new List<Grades>();
        public GradesRepository()
        {
            grades.Add(new Grades(1, 1, 5));
            grades.Add(new Grades(1, 2, 6));
            grades.Add(new Grades(1, 3, 8));
            grades.Add(new Grades(1, 4, 6));
            grades.Add(new Grades(2, 1, 1));
            grades.Add(new Grades(2, 2, 6));
            grades.Add(new Grades(2, 3, 7));
            grades.Add(new Grades(2, 4, 4));
            grades.Add(new Grades(3, 1, 5));
            grades.Add(new Grades(3, 2, 6));
            grades.Add(new Grades(3, 3, 10));
            grades.Add(new Grades(3, 4, 7));
            grades.Add(new Grades(4, 1, 10));
            grades.Add(new Grades(4, 2, 10));
            grades.Add(new Grades(4, 3, 10));
            grades.Add(new Grades(4, 4, 10));
            grades.Add(new Grades(5, 1, 9));
            grades.Add(new Grades(5, 2, 10));
            grades.Add(new Grades(5, 3, 7));
            grades.Add(new Grades(5, 4, 9));
            grades.Add(new Grades(6, 1, 4));
            grades.Add(new Grades(6, 2, 6));
            grades.Add(new Grades(6, 3, 8));
            grades.Add(new Grades(6, 4, 6));
            grades.Add(new Grades(7, 1, 8));
            grades.Add(new Grades(7, 2, 8));
            grades.Add(new Grades(7, 3, 10));
            grades.Add(new Grades(7, 4, 9));
            grades.Add(new Grades(8, 1, 7));
            grades.Add(new Grades(8, 2, 7));
            grades.Add(new Grades(8, 3, 6));
            grades.Add(new Grades(8, 4, 7));
            grades.Add(new Grades(9, 1, 10));
            grades.Add(new Grades(9, 2, 8));
            grades.Add(new Grades(9, 3, 7));
            grades.Add(new Grades(9, 4, 8));
        }

        public List<Grades> Retrieve()
        {
            return grades;
        }
        public Grades GetGrade(int id, int trimester)
        {
            var grade = grades.FirstOrDefault(x => x.Id == id && x.Trimester == trimester);
            return grade;
        }

        public List<Grades> GetAllGradesForYear(int trimester)
        {
            var trimesterGrades = Retrieve();
            trimesterGrades = trimesterGrades.Where(grade => grade.Trimester.Equals(trimester)).ToList();
            return trimesterGrades;
        }

        public List<Grades> GetAllGradesForStudent(int id)
        {
            var studentGrades = Retrieve();
            studentGrades = studentGrades.Where(grade => grade.Id.Equals(id)).ToList();
            return studentGrades;
        }

        public List<Grades> AddGrade(int id, int trimester, int grade)
        {
            grades.Add(new Grades(id, trimester, grade));
            return grades;
        }

        public Grades EditGrade(int id, int trimester, int grade)
        {
            var grades = Retrieve();
            var editGrade = grades.SingleOrDefault(x => x.Id == id && x.Trimester == trimester);
            if (editGrade == null)
            {
                Console.WriteLine($"The grade of the student id {editGrade.Id} doesn't exist");
                return null;
            }

            editGrade.Grade = grade;
            return editGrade;
        }

        public void RemoveGrade(int id, int trimester)
        {
            var grades = Retrieve();
            var deleteGrade = grades.SingleOrDefault(x => x.Id == id && x.Trimester == trimester);
            if (deleteGrade != null)
            {
                grades.Remove(deleteGrade);
            }
            else
            {
                Console.WriteLine($"The grade of the student id {deleteGrade.Id} doesn't exist");
            }
        }

        public static List<Grades> EditGrade(GradesRepository gradesRepository)
        {
            Console.WriteLine("Enter student ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the trimester or press 4 for the year grade:");
            int trimester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a new grade");
            int grade = Convert.ToInt32(Console.ReadLine());
            gradesRepository.EditGrade(id, trimester, grade);
            var grades = gradesRepository.Retrieve();
            return grades;
        }

        public static List<Grades> AddGrade(GradesRepository gradesRepository)
        {
            Console.WriteLine("Enter student ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the trimester or press 4 for the year grade:");
            int trimester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a grade you want to add");
            int grade = Convert.ToInt32(Console.ReadLine());
            gradesRepository.AddGrade(id, trimester, grade);
            var grades = gradesRepository.Retrieve();
            return grades;
        }

        public static List<Grades> DeleteGrade(GradesRepository gradesRepository)
        {
            Console.WriteLine("Enter student ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the trimester or press 4 for the year grade:");
            int trimester = Convert.ToInt32(Console.ReadLine());
            gradesRepository.RemoveGrade(id, trimester);
            var grades = gradesRepository.Retrieve();
            return grades;
        }

        public static void GetTrimesterOfAllStudents(GradesRepository gradesRepository)
        {
            Console.WriteLine("Select a trimester:");
            Console.WriteLine("1: First trimester 2: Second trimester 3: Third trimester 4: Year grades");
            int trimester = Convert.ToInt32(Console.ReadLine());
            var trimesterGrades = gradesRepository.GetAllGradesForYear(trimester);

            foreach (var grade in trimesterGrades)
            {
                Console.WriteLine($"Student Id: {grade.Id}; trimester grade - {grade.Grade}");
            }
        }

        public static void GetGradesOfSingleStudent(GradesRepository gradesRepository)
        {
            Console.WriteLine("Enter student id:");
            int id = Convert.ToInt32(Console.ReadLine());
            var singleStudentGrades = gradesRepository.GetAllGradesForStudent(id);

            foreach (var grade in singleStudentGrades)
            {
                if (grade.Trimester != 4)
                {
                    Console.WriteLine($"The grade for trimester {grade.Trimester} is: {grade.Grade}");
                }
                else
                {
                    Console.WriteLine($"Year grade is: {grade.Grade}");
                }
            }
        }

        public static void GetSingleGrade(GradesRepository gradesRepository)
        {
            Console.WriteLine("Enter student id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the trimester or press 4 for the year grade:");
            int trimester = Convert.ToInt32(Console.ReadLine());
            var grade = gradesRepository.GetGrade(id, trimester);
            if (grade.Trimester != 4)
            {
                Console.WriteLine($"{grade.Trimester} trimester grade is: {grade.Grade}");
            }
            else
            {
                Console.WriteLine($"Year grade is: {grade.Grade}");
            }
        }

    }

}
