using HW_8___Week_8.Services;
using HW_8___Week_8;
using HW_8___Week_8.Interface;
using HW_8___Week_8.Repo;


ICourseRepository courseRepo = new CourseRepository();
IStudentRepository studentRepo = new StudentRepository();
ITeacherRepository teacherRepo = new TeacherRepository();
IOperatorRepository operatorRepo = new OperatorRepository();

Service service = new Service(courseRepo, studentRepo, teacherRepo, operatorRepo);
while (true)
{
    Console.WriteLine("\nWelcome to University Registration System");
    Console.WriteLine("1. Student Login");
    Console.WriteLine("2. Teacher Login");
    Console.WriteLine("3. Operator Login");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            StudentLogin(service);
            break;
        case "2":
            TeacherLogin(service);
            break;
        case "3":
            OperatorLogin(service);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void StudentLogin(Service service)
{
    Console.WriteLine("\n--- Student Login ---");
    Console.Write("Enter username: ");
    string username = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    var student = service.studentRepo.GetStudentByCode(username); // username is the student code
    if (student.IsActive == false)
    {
        Console.WriteLine("your account is DeActice. Call Operator");
    }
    else if (student != null && student.Password == password)
    {
        Storage.CurrentUser = student;
        Console.WriteLine("Login successful.");
        ShowStudentMenu(service);
    }
    else
    {
        Console.WriteLine("Invalid username or password.");
    }
}

void ShowStudentMenu(Service service)
{
    while (true)
    {
        Console.WriteLine("\n--- Student Menu ---");
        Console.WriteLine("1. View All Courses");
        Console.WriteLine("2. Register for a Course");
        Console.WriteLine("3. View Schedule");
        Console.WriteLine("0. Logout");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewAllCourses(service);
                break;
            case "2":
                RegisterForCourse(service);
                break;
            case "3":
                ViewSchedule(service);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void ViewAllCourses(Service service)
{
    Console.WriteLine("\n--- Available Courses ---");
    foreach (var course in service.courseRepo.GetAllCourses())
    {
        Console.WriteLine($"ID: {course.ID}, Name: {course.Name}, Units: {course.Units}, Instructor: {course.Instructor}, Capacity: {course.Capacity}, Enrolled: {course.EnrolledStudents}");
    }
}

void RegisterForCourse(Service service)
{
    Console.Write("Enter course ID to register: ");
    int courseId = int.Parse(Console.ReadLine());

    Console.Write("Enter your student code: ");
    string studentCode = Console.ReadLine();

    service.studentRepo.RegisterCourse(studentCode, courseId);
}

void ViewSchedule(Service service)
{
    Console.Write("Enter your student code to view your schedule: ");
    string studentCode = Console.ReadLine();
    var student = service.studentRepo.GetStudentByCode(studentCode);

    if (student == null)
    {
        Console.WriteLine("Student not found.");
        return;
    }

    Console.WriteLine("\n--- Your Schedule ---");
    foreach (var course in student.TakenCourses)
    {
        Console.WriteLine($"Course: {course.Name}, Start Time: {course.StartTime}, End Time: {course.EndTime}");
    }
}

void TeacherLogin(Service service)
{
    Console.WriteLine("\n--- Teacher Login ---");
    Console.Write("Enter your Teacher ID: ");
    string username = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    if (int.TryParse(username, out int teacherId))
    {
        var teacher = service.teacherRepo.GetTeacherById(teacherId);
        if (teacher != null && teacher.Password == password)
        {
            Storage.CurrentUser = teacher;
            Console.WriteLine("Login successful.");
            ShowTeacherMenu(service);
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Teacher ID format. Please enter a valid numeric ID.");
    }
}

void ShowTeacherMenu(Service service)
{
    while (true)
    {
        Console.WriteLine("\n--- Teacher Menu ---");
        Console.WriteLine("1. Add Course");
        Console.WriteLine("2. View Registered Students in Course");
        Console.WriteLine("0. Logout");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddCourse(service);
                break;
            case "2":
                ViewRegisteredStudents(service);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void AddCourse(Service service)
{
    Console.Write("Enter your teacher ID: ");
    int teacherId = int.Parse(Console.ReadLine());
    service.CreateCourse(teacherId);
}

void ViewRegisteredStudents(Service service)
{
    Console.Write("Enter course ID to view registered students: ");
    int courseId = int.Parse(Console.ReadLine());

    var students = service.teacherRepo.GetStudentsInCourse(courseId);
    Console.WriteLine("\n--- Registered Students ---");
    foreach (var student in students)
    {
        Console.WriteLine($"Student Name: {student.FirstName} {student.LastName}, Student Code: {student.StudentCode}");
    }
}

void OperatorLogin(Service service)
{
    Console.WriteLine("\n--- Operator Login ---");
    Console.Write("Enter username: ");
    string username = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    var operatorUser = service.operatorRepo.GetAllOperators().FirstOrDefault(o => o.UserName == username && o.Password == password);
    if (operatorUser != null)
    {
        Storage.CurrentUser = operatorUser;
        Console.WriteLine("Login successful.");
        ShowOperatorMenu(service);
    }
    else
    {
        Console.WriteLine("Invalid username or password.");
    }
}

void ShowOperatorMenu(Service service)
{
    while (true)
    {
        Console.WriteLine("\n--- Operator Menu ---");
        Console.WriteLine("1. Manage Users");
        Console.WriteLine("2. View Class Capacity");
        Console.WriteLine("0. Logout");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ManageUsers(service);

                studentRepo.GetAllStudents();


                Console.WriteLine("which student do you want to A or D?");
                Console.WriteLine("Please enter a Student Code: ");
                var getID = Console.ReadLine();
                Console.WriteLine("Active(1) Or DeActive(2): ");
                int AOrD = int.Parse(Console.ReadLine());
                switch (AOrD)
                {
                    case 1:
                        service.operatorRepo.ActivateStudent(getID);
                        break;
                    case 2:
                        service.operatorRepo.DeactivateStudent(getID);
                        break;
                }




                break;
            case "2":
                ViewClassCapacity(service);
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void ManageUsers(Service service)
{
    Console.WriteLine("Student List: ");
    foreach (var item in Storage.Students)
    {
        Console.WriteLine($"{item.UserName} - student code: {item.StudentCode}");
    }
    Console.WriteLine("Teacher List: ");
    foreach (var item1 in Storage.Teachers)
    {
        Console.WriteLine(item1.UserName);
    }
}

void ViewClassCapacity(Service service)
{
    Console.WriteLine("\n--- Class Capacity ---");
    foreach (var course in service.courseRepo.GetAllCourses())
    {
        Console.WriteLine($"Course: {course.Name}, Capacity: {course.Capacity}, Enrolled: {course.EnrolledStudents}");
    }
}