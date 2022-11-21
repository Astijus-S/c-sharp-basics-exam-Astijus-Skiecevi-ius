// Tema nr.4: Studentų dienynas
// Papildomai: studentų visų trimestrų bei metinio pažymio ataskaita.
// Visi duomenys ateina iš repozitorijų, tuo tarpu repozitorijos nuskaito ir išsaugo duomenys iš bylų (tik jei liks laiko).
// Ataskaitą galima išsaugoti į tekstinę bylą. Kodas turi būti padengtas UnitTestais


using c_sharp_basics_exam_Astijus_Skiecevičius.Repositories;


var gradeRepository = new GradesRepository();
var studentRepository = new StudentsRepository();
while (true)
{

    Console.WriteLine(" 1: display student list,\n 2: edit student list, \n 3: display grades,\n 4: edit grades,\n q: quit program");
    string userInput = Console.ReadLine().ToLower();
    switch (userInput)
    {
        case "1":
            DisplayStudentList((StudentsRepository)studentRepository);
            break;
        case "2":
            EditStudentList(studentRepository);
            break;
        case "3":
            DisplayGrades(gradeRepository);
            break;
        case "4":
            EditGrades(gradeRepository);
            break;
        case "q":
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    };

}

static void EditStudentList(StudentsRepository studentsRepository)
{
    Console.Clear();
    Console.WriteLine(" 1: add a student,\n 2: delete a student,\n m: return to main menu,\n q: quit program");
    string userInput = Console.ReadLine().ToLower();

    switch (userInput)
    {
        case "1":
            StudentsRepository.AddStudent(studentsRepository);
            break;
        case "2":
            StudentsRepository.DeleteStudent(studentsRepository);
            break;
        case "q":
            Environment.Exit(0);
            break;
        case "m":
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

static void DisplayGrades(GradesRepository gradesRepository)
{
    Console.Clear();
    Console.WriteLine(" 1: display the grades of a single student,\n 2: display the grades of every student,\n 3: display a single grade,\n m: return to main menu,\n q: quit program");
    string userInput = Console.ReadLine().ToLower();

    switch (userInput)
    {
        case "1":
            GradesRepository.GetGradesOfSingleStudent(gradesRepository);
            break;
        case "2":
            GradesRepository.GetTrimesterOfAllStudents(gradesRepository);
            break;
        case "3":
            GradesRepository.GetSingleGrade(gradesRepository);
            break;
        case "q":
            Environment.Exit(0);
            break;
        case "m":
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

static void EditGrades(GradesRepository gradesRepository)
{
    Console.Clear();
    Console.WriteLine(" 1: add a grade,\n 2: delete a grade,\n 3: edit a grade,\n m: return to main menu,\n q: quit program");
    string userInput = Console.ReadLine().ToLower();

    switch (userInput)
    {
        case "1":
            GradesRepository.AddGrade(gradesRepository);
            break;
        case "2":
            GradesRepository.DeleteGrade(gradesRepository);
            break;
        case "3":
            GradesRepository.EditGrade(gradesRepository);
            break;
        case "q":
            Environment.Exit(0);
            break;
        case "m":
            return;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}
static void DisplayStudentList(StudentsRepository studentsRepository)
{
    var everyStudent = studentsRepository.Retrieve();
    foreach (var student in everyStudent)
    {
        Console.WriteLine($"Students name is: {student.FirstName} {student.LastName}, students id is: {student.Id}");
    }
}