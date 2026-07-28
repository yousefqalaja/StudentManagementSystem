namespace StudentManagementSystem;

class Student(int id, string name, int age)
{
    public int id = id;
    public string name = name;
    public int age = age;
    List<Course> courses = [];

    public bool Enroll(Course course)
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
    public bool IsEnrolledInCourse(int courseId)
    {
        foreach (var c in courses)
        {
            if (c.id == courseId)
                return true;
        }
        return false;
    }
    public string PrintDetails()
    {
        return $"{id},{name},{age}";
    }

}

