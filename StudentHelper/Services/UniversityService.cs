using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentHelper.Models;

namespace StudentHelper.Services
{
    public class UniversityService
    {
        private ApplicationDbContext dbContext;

        public UniversityService()
        {
            dbContext = new ApplicationDbContext();
        }

        public IEnumerable<University> GetAllUniversities()
        {
            return dbContext.Universities.ToList();
        }

        public University GetUniversity(int universityId)
        {
            return dbContext.Universities.Where(u => u.UniversityId == universityId)
                                          .FirstOrDefault();

        }

        public void InsertUniversity(University university)
        {
            dbContext.Universities.Add(university);
            dbContext.SaveChanges();
        }

    }
}