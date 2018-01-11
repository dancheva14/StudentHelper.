using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using StudentHelper.Models;
using StudentHelper.ViewModels;

namespace StudentHelper.Services
{
    public class PeopleService
    {
        private ApplicationDbContext dbContext;
        public UniversityService unService;

        public PeopleService()
        {
            dbContext = new ApplicationDbContext();
            unService = new UniversityService();
        }

        public List<Person> GetAllPeople()
        {
            var people = dbContext.People.Include(s => s.University).ToList();
            return people;
        }

        public Person GetPersonById(int personId)
        {
            return dbContext.People.Include(s => s.University).Where(m => m.PersonId == personId)
                                      .FirstOrDefault();
        }

        public void InsertPerson(MultipleViewModel multipleViewModel)
        {
            var person = multipleViewModel.Person;
            var university = unService.GetUniversity(multipleViewModel.Person.University.UniversityId);
            person.University = university;
            dbContext.People.Add(person);
            dbContext.SaveChanges();
        }
    }
}