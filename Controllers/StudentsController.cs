using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.Data;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _db.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student newStudent)
        {
            _db.Students.Add(newStudent);
            await _db.SaveChangesAsync();
            return Ok("Student added: " + newStudent.Name);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            student.Name = updatedStudent.Name;
            student.Marks = updatedStudent.Marks;
            await _db.SaveChangesAsync();

            return Ok("Student updated: " + student.Name);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            _db.Students.Remove(student);
            await _db.SaveChangesAsync();

            return Ok("Student deleted: " + student.Name);
        }
        private static List<Student> students = new List<Student>()
        {
            new Student{ Id=1, Name="Nikita", Marks=90},
            new Student{Id=2, Name="Nilesh", Marks=80},
            new Student{Id=3, Name="Yogesh", Marks=80}
        };

        //[HttpGet]

        //public IActionResult GetAllStudents()    //Viewing data
        //{
        //    return Ok(students);
        //}

        //[HttpGet("{id}")]

        //public IActionResult GetStudentById(int id)
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound("Student not found");

        //    }
        //    return Ok(students);
        //}

        //[HttpPost]

        //public IActionResult AddStudents(Student newstudent)   //adding student
        //{
        //    students.Add(newstudent);
        //    return Ok("Students added!" + newstudent.Name + "Marks:" + newstudent.Marks);
        //}

        //[HttpPut("{id}")]

        //public IActionResult UpdateStudent(int id, Student updatestudent) ////update student
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound("Studetent not found");

        //    }
        //    student.Name = updatestudent.Name;
        //    student.Marks = updatestudent.Marks;
        //    return Ok("Student updated!" + updatestudent.Name + "Marks:" + updatestudent.Marks);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteStudent(int id)// delete student
        //{
        //    var student = students.FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound("Student not found");


        //    }

        //    students.Remove(student);
        //    return Ok("Student deleted" + student.Name);
        //}

    }
}