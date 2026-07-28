namespace StudentManagementSystem;

class Instructor(int id, string name, string specialization)
{
    public int id = id;
    public string name = name;
    public string specialization = specialization;
    public string PrintDetails()
    {
        return $"{id},{name},{specialization}";
    }

}
