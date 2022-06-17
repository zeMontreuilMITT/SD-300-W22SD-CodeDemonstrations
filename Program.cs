// Students and Courses
// students can enroll in multiple courses
// and a course can contain many enrolled students

Student Othello = new Student("Othello", 1);
Student Ophelia = new Student("Ophelia", 2);
Student Henry = new Student("Henry", 3);

Course Shakespeare = new Course();
Shakespeare.Title = "Intro to Shakespeare";

Enrollment OpheliaInShakespeare = new Enrollment(Ophelia, Shakespeare);
Shakespeare.Enrollments.Add(OpheliaInShakespeare);
Ophelia.Enrollments.Add(OpheliaInShakespeare);

Enrollment HenryInShakespeare = new Enrollment(Henry, Shakespeare);
Shakespeare.Enrollments.Add(HenryInShakespeare);
Henry.Enrollments.Add(HenryInShakespeare);

foreach(Enrollment e in Shakespeare.Enrollments)
{
    Console.WriteLine($"{e.Student.FullName} is enrolled in {Shakespeare.Title}");
}

// iterate over the enrollments in Shakespeare to see all the students


class Student
{
    public string FullName { get; set; }
    public int StudentId { get; set; }
    public ICollection<Enrollment> Enrollments{ get; set; }

    public Student()
    {
        Enrollments = new HashSet<Enrollment>();
    }

    public Student(string name, int id)
    {
        FullName = name;
        StudentId = id;

        Console.WriteLine($"Welcome to the school, {FullName}");
        Enrollments = new HashSet<Enrollment>();
    }
}

class Course
{
    public string Title { get; set; }
    public int CourseNumber { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }

    public Course()
    {
        Enrollments = new HashSet<Enrollment>(); 
    }
}

class Enrollment
{
    public Student Student { get; set; }
    public Course Course { get; set; }

    public Enrollment(Student student, Course course)
    {
        Student = student;
        Course = course;
    }
}