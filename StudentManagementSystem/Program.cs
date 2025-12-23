namespace StudentManagementSystem
{
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
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            bool ex = true;
            string sel;
            do
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the student by id or name");
                Console.WriteLine("9. Fine the course by id or name");
                Console.WriteLine("10. Check if the student enrolled in specific course");
                Console.WriteLine("11. Return the instructor name by course name");
                Console.WriteLine("12. Exit");
                Console.WriteLine("==============================================");
               
                sel = Console.ReadLine();
                switch (sel)
                {

                    case "1":
                        {

                            Console.WriteLine("Enter Student ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Student Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Student age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            if (studentManager.AddStudent(new Student(id, name, age)))
                            {
                                Console.WriteLine("Student Added Successfully");
                            }
                            else
                            {
                                Console.WriteLine("ID Exists :/ ");
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("Enter Instructor ID :");
                            int instructorId = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Name : ");
                            string instructorName = Console.ReadLine();

                            Console.WriteLine("Enter specialization : ");
                            string specialization = Console.ReadLine();

                            if (studentManager.AddInstructor(new Instructor(instructorId, instructorName, specialization)))
                            {
                                Console.WriteLine("Instructor Added Successfully :/");
                            }
                            else
                            {
                                Console.WriteLine("Instructor ID Exists");
                            }
                        }

                        break;
                    case "3":
                        {
                            Console.WriteLine("Enter Course ID");
                            int courrseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Title");
                            string courrseTitle = Console.ReadLine();
                            Console.WriteLine("Enter Instructor ID");
                            int instructorId = Convert.ToInt32(Console.ReadLine());
                            var instructor = studentManager.FindInstructor(instructorId);
                            if (instructor != null)
                            {
                                if (studentManager.AddCourse(new Course(courrseId, courrseTitle, instructor)))
                                {
                                    Console.WriteLine("Course Added :");
                                }
                                else
                                {
                                    Console.WriteLine("ID Exists");
                                }
                            }
                            else
                            {
                                Console.WriteLine("instructor Not Found");
                            }
                        }
                        break;
                    case "4":
                        {
                            Console.WriteLine("Enter Couse ID  ");
                            int courseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Student ID");
                            int studentId = Convert.ToInt32(Console.ReadLine());
                            if (studentManager.EnrollStudentInCourse(studentId, courseId))
                            {
                                Console.WriteLine("The Course Added to Student");
                            }
                            else
                            {
                                Console.WriteLine("Something Went Wrong");
                            }
                        }
                        break;
                    case "5":
                        {
                            foreach (var item in studentManager.students)
                            {
                                Console.WriteLine(item.PrintDetails());
                            }
                            
                        }
                        break;
                    case "6":
                        foreach (var item in studentManager.courses)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }


                        break;
                    case "7":
                        foreach (var item in studentManager.instructors)
                        {
                            Console.WriteLine(item.PrintDetails());
                        }


                        break;
                    case "8":
                        {
                            Console.WriteLine("1. Search by ID");
                            Console.WriteLine("2. Search by Name");
                            string choice = Console.ReadLine();

                            Course course = null;

                            if (choice == "1")
                            {
                                Console.Write("Enter ID: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                course = studentManager.FindCourse(id);
                            }
                            else if (choice == "2")
                            {
                                Console.Write("Enter Name: ");
                                string name = Console.ReadLine();
                                course = studentManager.FindCourseByName(name);
                            }

                            
                        }
                        break;
                    case "9":
                        {
                            Course course = null;
                            if (course != null)
                                Console.WriteLine(course.PrintDetails());
                            else
                                Console.WriteLine("Course Not Found");
                        }
                        break;
                    case "10":
                        {
                            Console.Write("Enter Student ID: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Course ID: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (studentManager.CheckStudentEnrollment(studentId, courseId))
                                Console.WriteLine("✅ Student is enrolled in this course");
                            else
                                Console.WriteLine("❌ Student is NOT enrolled in this course");
                        }
                        break;

                 
                    case "11":
                        {
                            Console.Write("Enter Course Name: ");
                            string courseName = Console.ReadLine();

                            string instructorName = studentManager.GetInstructorNameByCourseName(courseName);

                            if (instructorName != null)
                                Console.WriteLine("Instructor Name: " + instructorName);
                            else
                                Console.WriteLine("Course not found");
                        }
                        break;
                    case "12":
                        {
                            Console.WriteLine("good bye");
                            ex = false;
                        }
                        break;

                }




            } while (ex);
        }
    }
}
