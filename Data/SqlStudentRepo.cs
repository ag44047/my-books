using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlStudentRepo : IStudentRepo
    {
        private readonly CommanderContext _context;

        public SqlStudentRepo(CommanderContext context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public Student EditStudent(int id)
        {
            return _context.Students.Where(student => student.Id == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Where(student => student.Id == id).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}