namespace StudentManagementSystem;


class StudentManager()
{
    public List<Student> students = new List<Student>() { };

    public List<Course> courses = new List<Course>() { };

    public List<Instructor> instructors = new List<Instructor>() { };
    public bool AddStudent(Student student)
    {
        if (students.Count > 0)
        {
            foreach (var item in students)
            {
                if (item.id == student.id)
                {
                    return false;
                }
            }
        }
        students.Add(student);
        return true;
    }
    public bool AddCourse(Course course)
    {

        if (courses.Count > 0)
        {
            foreach (var item in courses)
            {
                if (item.id == course.id)
                {
                    return false;
                }
            }
        }
        courses.Add(course);
        return true;
    }
    public bool AddInstructor(Instructor instructor)
    {
        if (instructors.Count > 0)
        {
            foreach (var item in instructors)
            {
                if (item.id == instructor.id)
                {
                    return false;
                }
            }

        }
        instructors.Add(instructor);
        return true;
    }


    public Student FindStudent(int id)
    {
        if (instructors.Count > 0)
        {
            foreach (var item in students)
            {
                if (item.id == id)
                {
                    return item;
                }
            }

        }
        return null;

    }
    public Course FindCourse(int id)
    {
        if (courses.Count > 0)
        {
            foreach (var item in courses)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
        }
        return null;
    }

    public Instructor FindInstructor(int id)
    {
        if (instructors.Count > 0)
        {
            foreach (var item in instructors)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
        }
        return null;

    }

    public bool EnrollStudentInCourse(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);
        Course course = FindCourse(courseId);

        if (student != null && course != null)
        {
            if (student.Enroll(course))
            {
                return true;
            }
        }
        return false;

    }
    public Course FindCourseByName(string title)
    {
        foreach (var item in courses)
        {
            if (item.title.ToLower() == title.ToLower())
                return item;
        }
        return null;
    }
    public bool CheckStudentEnrollment(int studentId, int courseId)
    {
        Student student = FindStudent(studentId);

        if (student == null)
            return false;

        return student.IsEnrolledInCourse(courseId);
    }
    public string GetInstructorNameByCourseName(string courseName)
    {
        foreach (var c in courses)
        {
            if (c.title.ToLower() == courseName.ToLower())
                return c.instructor.name;
        }
        return null;
    }
}

