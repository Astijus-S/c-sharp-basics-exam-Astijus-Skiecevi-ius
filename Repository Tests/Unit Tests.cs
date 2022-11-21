using c_sharp_basics_exam_Astijus_Skiecevičius.Entities;
using c_sharp_basics_exam_Astijus_Skiecevičius.Repositories;
using System.Reflection;

namespace Repository_Tests
{
    public class UnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenStudentisAdded_StudentListIncreasesBySize()
        {
            //Arrange
            List<Students> students = new List<Students>();
            int expectedResult = students.Count + 1;

            //Act
            students.Add(new Students("Tom", "James", 1));
            //Assert
            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void WhenGradeisAdded_GradeListIncreasesBySize()
        {
            //Arrange
            List<Grades> grades = new List<Grades>();
            int expectedResult = grades.Count + 1;
            //Act
            grades.Add(new Grades(1, 1, 10));
            //Assert
            Assert.AreEqual(expectedResult, 1);
        }

        [Test]
        public void WhenGradeWIthValidIdIsEntered_GradeIsReturned()
        {
            //Arrange
            GradesRepository gradesrepository = new GradesRepository();
            //Act
            int id = 5;
            Grades grade = gradesrepository.GetGrade(id, 3);
            //Assert
            Assert.AreEqual(id, grade.Id);
        }

        [Test]
        public void WhenGradeWIthInvalidIdIsEntered_GradeIsNotReturned()
        {
            //Arrange
            GradesRepository gradesrepository = new GradesRepository();
            //Act
            int id = 9999;
            Grades grade = gradesrepository.GetGrade(id, 3);
            //Assert
            Assert.IsNull(grade);
        }

        [Test]
        public void WhenStudentWithValidLastNameIsEntered_StudentIsReturned()
        {
            //Arrange
            StudentsRepository studentsRepository = new StudentsRepository();
            //Act
            string lastname = "Johnson";
            Students student = studentsRepository.Retrieve(lastname);
            //Assert
            Assert.AreEqual(lastname, student.LastName);
        }

        [Test]
        public void WhenStudentWithInvalidLastNameIsEntered_StudentIsNotReturned()
        {
            //Arrange
            StudentsRepository studentsRepository = new StudentsRepository();
            //Act
            string lastname = "Yoda";
            Students student = studentsRepository.Retrieve(lastname);
            //Assert
            Assert.IsNull(student);
        }


    }
}