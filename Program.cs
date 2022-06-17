// Students and Courses
// students can enroll in multiple courses
// and a course can contain many enrolled students

Department SoftwareDeveloper = new Department("Software Developer");

Course courseOne = SoftwareDeveloper.CreateCourse("Intro to Logic");
SoftwareDeveloper.CreateCourse("Parsing for Poets");
SoftwareDeveloper.CreateCourse("How to Read Error Messages");

Student newStudent = SoftwareDeveloper.RegisterStudent("Alex Dane");
Student secondStudent = SoftwareDeveloper.RegisterStudent("Otherperson Normalguy");

Console.WriteLine(newStudent.Department.Name);

// Create a method on Department for registering a student in one of that department's courses
// its parameters will be the Course Number, and the student number

class Department
{
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Course> Courses { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public int CourseNumberCount { get; set; } = 1;
    public int StudentCount { get; set; } = 1;
    public Department(string name)
    {
        Name = name;
        Students = new HashSet<Student>();
        Courses = new HashSet<Course>();
        Enrollments = new HashSet<Enrollment>();
    }

    public Student GetStudent(int id)
    {
        Student student;

        foreach(Student s in Students)
        {
            if(s.StudentId == id)
            {
                student = s;
                return student;
            }
        }
        return null;
    }

    public Course CreateCourse(string courseTitle)
    {
        Course course = new Course(courseTitle, CourseNumberCount);
        CourseNumberCount++;

        Courses.Add(course);
        course.Department = this;
        return course;
    }

    public Student RegisterStudent(string name)
    {
        Student student = new Student(name, CourseNumberCount);
        Students.Add(student);
        StudentCount++;

        student.Department = this;
        return student;
    }
}


class Student
{
    public string FullName { get; set; }
    public int StudentId { get; set; }
    public ICollection<Enrollment> Enrollments{ get; set; }
    public Department Department { get; set; }

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
    public Department Department { get; set; }

    public Course(string title, int courseNumber)
    {
        Title = title;
        CourseNumber = courseNumber;
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