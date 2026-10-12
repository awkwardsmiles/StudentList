using StudentsLinq;

Console.WriteLine("Student List LINQ\n");

static void DisplayStudentList(List<Student> studentList)
{
    foreach (var student in studentList)
    {
        Console.WriteLine(student);
    }
}
#region populate students
var students = new List<Student>
{
    new Student("Smith",  "Alice",  19, "Computer Science",     78, 2021),
    new Student("Jones",  "Ben",    22, "Computer Science",     85, 2019),
    new Student("Patel",  "Priya",  20, "Computer Science",     92, 2022),
    new Student("Brown",  "Callum", 23, "Computer Science",     64, 2018),
    new Student("Taylor", "Dana",   19, "Computer Science",     71, 2023),
    new Student("Wilson", "Ethan",  21, "Software Engineering", 58, 2020),
    new Student("Evans",  "Fiona",  24, "Software Engineering", 83, 2021),
    new Student("Khan",   "Hassan", 20, "Software Engineering", 76, 2022),
    new Student("Murray", "Isla",   22, "Data Science",         88, 2021),
    new Student("Clark",  "Jack",   25, "Data Science",         69, 2019),
    new Student("Reid",   "Katie",  19, "Data Science",         95, 2023),
    new Student("Wright", "Liam",   23, "Cyber Security",       74, 2020),
    new Student("Hughes", "Maya",   21, "Cyber Security",       81, 2022),
    new Student("Ali",    "Noah",   26, "Cyber Security",       55, 2018),
    new Student("Scott",  "Olivia", 20, "Cyber Security",       80, 2024)
};
#endregion

Console.WriteLine("All Students");
DisplayStudentList(students);

//==================================================================================================================
// 1. Filter by Course and sort by Mark (descending)
Console.WriteLine("\n1. Computer Science students sorted by mark (highest first)");

ListCsStudents(students);

//==================================================================================================================
// 2. Enrolled after 2020, sorted by enrolment year
Console.WriteLine("\n2. Students enrolled after 2020, sorted by enrolment year");

Sortenrollment(students);

//==================================================================================================================
// 3. Average mark by course
Console.WriteLine("\n3. Average mark by course");

AVGMark(students);

//==================================================================================================================
// 4. Youngest student in each course
Console.WriteLine("\n4. Youngest student in each course");

YngestStudent(students);

//==================================================================================================================
// 5. Count students by enrolment year
Console.WriteLine("\n5. Number of students enrolled in each year");

yearenrolled(students);

//==================================================================================================================
// 6. Marks between 70 and 85 (inclusive), ascending
Console.WriteLine("\n6. Students with marks between 70 and 85 (inclusive), lowest first");

var marksInRange = students
    .Where(s => s.Mark >= 70 && s.Mark <= 85)
    .OrderBy(s => s.Mark)
    .ToList();

DisplayStudentList(marksInRange);

//==================================================================================================================
// 7. Older than 21, sorted by mark (descending)
Console.WriteLine("\n7. Students older than 21, sorted by mark (highest first)");

var olderStudents = students
    .Where(s => s.Age > 21)
    .OrderByDescending(s => s.Mark)
    .ToList();

DisplayStudentList(olderStudents);

//==================================================================================================================
// 8. Top 3 students by mark
Console.WriteLine("\n8. Top 3 students by mark");

var top3 = students
    .OrderByDescending(s => s.Mark)
    .Take(3)
    .ToList();

DisplayStudentList(top3);

//==================================================================================================================
// 9. Select and transform into an anonymous type
Console.WriteLine("\n9. Name, course and whether mark is above 80");

var transformed = students
    .Select(s => new
    {
        Name = s.FullName,
        s.Course,
        AboveEighty = s.Mark > 80
    })
    .ToList();

foreach (var item in transformed)
{
    Console.WriteLine($"{item.Name} | {item.Course} | Above 80: {item.AboveEighty}");
}

//==================================================================================================================
// 10. Aggregate data
Console.WriteLine("\n10. Aggregate data");

var totalStudents = students.Count();
var averageAge = students.Average(s => s.Age);
var highestMark = students.Max(s => s.Mark);

Console.WriteLine($"Total students: {totalStudents}");
Console.WriteLine($"Average age: {averageAge:F1}");
Console.WriteLine($"Highest mark: {highestMark}");

#region Methods
static void ListCsStudents(List<Student> students)
{
    var csStudents = students
        .Where(s => s.Course == "Computer Science")
        .OrderByDescending(s => s.Mark)
        .ToList();

    DisplayStudentList(csStudents);
}

static void Sortenrollment(List<Student> students)
{
    var enrolledAfter2020 = students
        .Where(s => s.EnrolmentYear > 2020)
        .OrderBy(s => s.EnrolmentYear)
        .ToList();

    DisplayStudentList(enrolledAfter2020);
}

static void AVGMark(List<Student> students)
{
    var avgMarkByCourse = students
        .GroupBy(s => s.Course)
        .Select(g => new { Course = g.Key, AverageMark = g.Average(s => s.Mark) })
        .OrderBy(x => x.Course)
        .ToList();

    foreach (var item in avgMarkByCourse)
    {
        Console.WriteLine($"{item.Course}: {item.AverageMark:F1}");
    }
}

static void YngestStudent(List<Student> students)
{
    var youngestByCourse = students
        .GroupBy(s => s.Course)
        .OrderBy(g => g.Key)
        .Select(g => g.OrderBy(s => s.Age).First())
        .ToList();

    DisplayStudentList(youngestByCourse);
}

static void yearenrolled(List<Student> students)
{
    var countByYear = students
        .GroupBy(s => s.EnrolmentYear)
        .OrderBy(g => g.Key)
        .Select(g => new { Year = g.Key, Count = g.Count() })
        .ToList();

    foreach (var item in countByYear)
    {
        Console.WriteLine($"{item.Year}: {item.Count}");
    }
}
#endregion