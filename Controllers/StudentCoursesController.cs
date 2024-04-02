using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mohinhcodefirst.Data;
using mohinhcodefirst.Model;

namespace mohinhcodefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentCoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourses>>> GetStudentCourse()
        {
            return await _context.StudentCourse.ToListAsync();
        }

        // GET: api/StudentCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourses>> GetStudentCourses(int id)
        {
            var studentCourses = await _context.StudentCourse.FindAsync(id);

            if (studentCourses == null)
            {
                return NotFound();
            }

            return studentCourses;
        }

        // PUT: api/StudentCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentCourses(int id, StudentCourses studentCourses)
        {
            if (id != studentCourses.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCoursesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentCourses>> PostStudentCourses(StudentCourses studentCourses)
        {
            _context.StudentCourse.Add(studentCourses);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentCoursesExists(studentCourses.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentCourses", new { id = studentCourses.StudentId }, studentCourses);
        }

        // DELETE: api/StudentCourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentCourses(int id)
        {
            var studentCourses = await _context.StudentCourse.FindAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }

            _context.StudentCourse.Remove(studentCourses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentCoursesExists(int id)
        {
            return _context.StudentCourse.Any(e => e.StudentId == id);
        }
    }
}
