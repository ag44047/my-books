using System.Collections.Generic;
using System.Linq;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _repository;

        public StudentsController(IStudentRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Student>> GetAllStudents()
        {
            var students = _repository.GetAllStudents();

            if(students != null && students.Count()  != 0)
            {
                return Ok(students);
            }
            return null;
        }

       [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = _repository.GetStudentById(id);

            if(student != null)
            {
                return Ok(student);
            }
            return NotFound("Student does not exist.");
        }

        [HttpPut("{id}")]
        public ActionResult EditCommand(int id, Student student)
        {
            var existingStudent = _repository.EditStudent(id);

            if(existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Department = student.Department;
                existingStudent.AvgGrade = student.AvgGrade;

                _repository.SaveChanges();

            }else
            {
                _repository.AddStudent(student);

                _repository.SaveChanges();
                
                return Ok("Student "+student.FirstName+" does not exist, added as new.");
            }

            return Ok("Student edited successfully.");
        }


    }   
}