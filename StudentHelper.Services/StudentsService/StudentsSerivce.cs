using System.Collections.Generic;
using StudentHelper.Models;

namespace StudentHelper.Services.StudentsService
{
    public class StudentsSerivce
    {
        private ApplicationDbContext dbContext;
        public StudentsSerivce()
        {
            dbContext = new ApplicationDbContext();
        }
        
        public List<Student> GetAllStudents()
        {
            return dbContext.Students.ToList();
        }
    }
}
