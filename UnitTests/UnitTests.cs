using c_sharp_basics_exam_Astijus_Skiecevi?ius.Entities;

{

namespace UnitTests
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestStudentsRepository_AddStudent_StudentCountIncreasesBy1()
        {
            //Arrange
            StudentsRepository studentsRepository = new StudentsRepository();
            int desiredResult = studentsRepository.GetPassings().Count + 1;
            //Act
            StudentsRepository.AddStudent;
            //Assert
            Assert.AreEqual(desiredResult, passingRepository.GetPassings().Count);
        }
    }
}