using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using StudentHelper.Models;
using StudentHelper.ViewModels;

namespace StudentHelper.Services
{
    public class SpecialtyService
    {
        private ApplicationDbContext dbContext;
        public UniversityService unService;

        public SpecialtyService()
        {
            dbContext = new ApplicationDbContext();
            unService = new UniversityService();
        }

        public List<Specialty> GetAllSpecialties()
        {
            var specialties = dbContext.Specialties.Include(p => p.University).ToList();
            return specialties;
        }

        public IEnumerable<Specialty> GetUniversitySpecialties(int universityId)
        {
            return dbContext.Specialties.Include(p => p.University)
                            .Where(s => s.University.UniversityId == universityId)
                            .ToList();
        }

        public Specialty GetSpecialty(int specialtyId)
        {
            var specialty = dbContext.Specialties
                                        .Include(p => p.University)
                                        .Where(s => s.SpecialtyId == specialtyId).FirstOrDefault();


            return specialty;
        }

        public void InsertSpecialty(MultipleViewModel multipleViewModel)
        {
            var specialty = multipleViewModel.Specialty;
            var university = unService.GetUniversity(multipleViewModel.Specialty.University.UniversityId);
            specialty.University = university;
            dbContext.Specialties.Add(specialty);
            dbContext.SaveChanges();
        }
    }
}