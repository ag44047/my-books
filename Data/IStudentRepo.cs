using System.Collections.Generic;
using Commander.Models;


namespace Commander.Data
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student EditStudent(int id);
        void AddStudent(Student student);
        bool SaveChanges();
    }
}