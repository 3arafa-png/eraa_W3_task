
using System;
using System.Collections.Generic;

namespace eraa_W3_task
{
    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses = new List<Course>();

        public Student(int id, string name, int age)
        {
            StudentId = id;
            Name = name;
            Age = age;
        }

        public bool Enroll(Course course)
        {
            if (course == null)
                return false;

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                    return false;
            }

            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            string result = "ID: " + StudentId +
                            "\nName: " + Name +
                            "\nAge: " + Age;

            for (int i = 0; i < Courses.Count; i++)
            {
                result += "\nCourse: " + Courses[i].Title;
            }

            return result;
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int id, string name, string specialization)
        {
            InstructorId = id;
            Name = name;
            Specialization = specialization;
        }

        public string PrintDetails()
        {
            return "ID: " + InstructorId +
                   "\nName: " + Name +
                   "\nSpecialization: " + Specialization;
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int id, string title, Instructor instructor)
        {
            CourseId = id;
            Title = title;
            Instructor = instructor;
        }

        public string PrintDetails()
        {
            return "ID: " + CourseId +
                   "\nTitle: " + Title +
                   "\nInstructor: " + Instructor.Name;
        }
    }

    class StudentManager
    {
        public List<Student> Students = new List<Student>();
        public List<Course> Courses = new List<Course>();
        public List<Instructor> Instructors = new List<Instructor>();

        public bool AddStudent(Student student)
        {
            if (FindStudent(student.StudentId) != null)
                return false;

            Students.Add(student);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (FindInstructor(instructor.InstructorId) != null)
                return false;

            Instructors.Add(instructor);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (FindCourse(course.CourseId) != null)
                return false;

            Courses.Add(course);
            return true;
        }

        public Student FindStudent(int id)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == id)
                    return Students[i];
            }

            return null;
        }

        public Course FindCourse(int id)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == id)
                    return Courses[i];
            }

            return null;
        }

        public Instructor FindInstructor(int id)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == id)
                    return Instructors[i];
            }

            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
                return false;

            return student.Enroll(course);
        }

        public bool UpdateStudent(int id, string name, int age)
        {
            Student student = FindStudent(id);

            if (student == null)
                return false;

            student.Name = name;
            student.Age = age;

            return true;
        }

        public bool DeleteStudent(int id)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == id)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void ShowStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(Students[i].PrintDetails());
            }
        }

        public void ShowCourses()
        {
            if (Courses.Count == 0)
            {
                Console.WriteLine("No Courses Found");
                return;
            }

            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(Courses[i].PrintDetails());
            }
        }

        public void ShowInstructors()
        {
            if (Instructors.Count == 0)
            {
                Console.WriteLine("No Instructors Found");
                return;
            }

            for (int i = 0; i < Instructors.Count; i++)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(Instructors[i].PrintDetails());
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager school = new StudentManager();
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("===== STUDENT MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Search Student");
                Console.WriteLine("9. Search Course");
                Console.WriteLine("10. Update Student");
                Console.WriteLine("11. Delete Student");
                Console.WriteLine("12. Check Enrollment");
                Console.WriteLine("13. Find Instructor by Course");
                Console.WriteLine("0. Exit");
                Console.Write("Enter Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                if (choice < 0)
                {
                    Console.WriteLine("Invalid Number");
                    choice = -1;
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (id <0)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Student Name: ");
                            string name = Console.ReadLine() ?? "";

                            Console.Write("Student Age: ");

                            int age = Convert.ToInt32(Console.ReadLine());

                            if (age < 1)
                            {
                                Console.WriteLine("Invalid Age");
                                break;
                            }
                            

                            Student student = new Student(id, name, age);

                            if (school.AddStudent(student))
                                Console.WriteLine("Student Added");
                            else
                                Console.WriteLine("Student ID Already Exists");

                            break;
                        }

                    case 2:
                        {
                            Console.Write("Instructor ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (id < 1)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Instructor Name: ");
                            string name = Console.ReadLine() ?? "";

                            Console.Write("Specialization: ");
                            string specialization = Console.ReadLine() ?? "";

                            Instructor instructor =
                                new Instructor(id, name, specialization);

                            if (school.AddInstructor(instructor))
                                Console.WriteLine("Instructor Added");
                            else
                                Console.WriteLine("Instructor ID Already Exists");

                            break;
                        }

                    case 3:
                        {
                            if (school.Instructors.Count == 0)
                            {
                                Console.WriteLine("Add an instructor first.");
                                break;
                            }

                            Console.Write("Course ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (id < 1)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Course Title: ");
                            string title = Console.ReadLine() ?? "";

                            school.ShowInstructors();

                            Console.Write("Instructor ID: ");
                            int instructorId = Convert.ToInt32(Console.ReadLine());

                            if (instructorId < 1)
                            {
                                Console.WriteLine("Invalid Instructor ID");
                                break;
                            }

                            Instructor instructor =
                                school.FindInstructor(instructorId);

                            if (instructor == null)
                            {
                                Console.WriteLine("Instructor Not Found");
                                break;
                            }

                            Course course = new Course(id, title, instructor);

                            if (school.AddCourse(course))
                                Console.WriteLine("Course Added");
                            else
                                Console.WriteLine("Course ID Already Exists");

                            break;
                        }

                    case 4:
                        {
                            Console.Write("Student ID: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            if (studentId < 1)
                            {
                                Console.WriteLine("Invalid Student ID");
                                break;
                            }

                            Console.Write("Course ID: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (courseId < 1)
                            {
                                Console.WriteLine("Invalid Course ID");
                                break;
                            }

                            if (school.EnrollStudentInCourse(studentId, courseId))
                                Console.WriteLine("Enrollment Successful");
                            else
                                Console.WriteLine("Enrollment Failed: Check IDs or existing enrollment");

                            break;
                        }

                    case 5:
                        school.ShowStudents();
                        break;

                    case 6:
                        school.ShowCourses();
                        break;

                    case 7:
                        school.ShowInstructors();
                        break;

                    case 8:
                        {
                            Console.WriteLine("1. Search by ID");
                            Console.WriteLine("2. Search by Name");
                            Console.Write("Choose Search Method: ");

                            int option = Convert.ToInt32(Console.ReadLine());

                            if (option < 1 || option > 3)
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                            Student student = null;

                            if (option == 1)
                            {
                                Console.Write("Student ID: ");

                                int id = Convert.ToInt32(Console.ReadLine());

                                if (id < 1)
                                {
                                    Console.WriteLine("Invalid ID");
                                    break;
                                }

                                student = school.FindStudent(id);
                            }
                            else if (option == 2)
                            {
                                Console.Write("Student Name: ");
                                string name = Console.ReadLine() ?? "";

                                for (int i = 0; i < school.Students.Count; i++)
                                {
                                    if (string.Equals(
                                        school.Students[i].Name,
                                        name,
                                        StringComparison.OrdinalIgnoreCase))
                                    {
                                        student = school.Students[i];
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                            if (student != null)
                                Console.WriteLine(student.PrintDetails());
                            else
                                Console.WriteLine("Student Not Found");

                            break;
                        }

                    case 9:
                        {
                            Console.WriteLine("1. Search by ID");
                            Console.WriteLine("2. Search by Name");
                            Console.Write("Choose Search Method: ");

                            int option = Convert.ToInt32(Console.ReadLine());

                            if (option < 1 || option > 2)
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                            Course course = null;

                            if (option == 1)
                            {
                                Console.Write("Course ID: ");

                                int id = Convert.ToInt32(Console.ReadLine());

                                if (id < 1)
                                {
                                    Console.WriteLine("Invalid ID");
                                    break;
                                }

                                course = school.FindCourse(id);
                            }
                            else if (option == 2)
                            {
                                Console.Write("Course Name: ");
                                string name = Console.ReadLine() ?? "";

                                for (int i = 0; i < school.Courses.Count; i++)
                                {
                                    if (string.Equals(
                                        school.Courses[i].Title,
                                        name,
                                        StringComparison.OrdinalIgnoreCase))
                                    {
                                        course = school.Courses[i];
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }

                            if (course != null)
                                Console.WriteLine(course.PrintDetails());
                            else
                                Console.WriteLine("Course Not Found");

                            break;
                        }

                    case 10:
                        {
                            Console.Write("Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (id < 1)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("New Name: ");
                            string name = Console.ReadLine() ?? "";

                            Console.Write("New Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            if (age < 1)
                            {
                                Console.WriteLine("Invalid Age");
                                break;
                            }

                            if (school.UpdateStudent(id, name, age))
                                Console.WriteLine("Student Updated");
                            else
                                Console.WriteLine("Student Not Found");

                            break;
                        }

                    case 11:
                        {
                            Console.Write("Student ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            if (id < 1)
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            if (school.DeleteStudent(id))
                                Console.WriteLine("Student Deleted");
                            else
                                Console.WriteLine("Student Not Found");

                            break;
                        }

                    case 12:
                        {
                            Console.Write("Student ID: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());

                            if (studentId < 1)
                            {
                                Console.WriteLine("Invalid Student ID");
                                break;
                            }

                            Console.Write("Course ID: ");
                            int courseId = Convert.ToInt32(Console.ReadLine());

                            if (courseId < 1)
                            {
                                Console.WriteLine("Invalid Course ID");
                                break;
                            }

                            Student student = school.FindStudent(studentId);
                            bool enrolled = false;

                            if (student != null)
                            {
                                for (int i = 0; i < student.Courses.Count; i++)
                                {
                                    if (student.Courses[i].CourseId == courseId)
                                    {
                                        enrolled = true;
                                        break;
                                    }
                                }
                            }

                            if (enrolled)
                                Console.WriteLine("Student Is Enrolled");
                            else
                                Console.WriteLine("Student Is Not Enrolled");

                            break;
                        }

                    case 13:
                        {
                            Console.Write("Course Name: ");
                            string name = Console.ReadLine() ?? "";
                            bool found = false;

                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                if (string.Equals(
                                    school.Courses[i].Title,
                                    name,
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine(
                                        "Instructor: " +
                                        school.Courses[i].Instructor.Name);

                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                                Console.WriteLine("Course Not Found");

                            break;
                        }

                    case 0:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
