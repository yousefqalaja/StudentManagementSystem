namespace StudentManagementSystem;

class Course(int id, string title, Instructor Instructor)
{
    public int id;
    public string title;
    public Instructor instructor;
    public string PrintDetails()
    {
        return $"{id},{title},{instructor}";
    }
}

