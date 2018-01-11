using StudentHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace StudentHelper.Services
{
    public class TestService
    {
        private ApplicationDbContext dbContext;
        public SpecialtyService spService;
        public TestService()
        {
            dbContext = new ApplicationDbContext();
            spService = new SpecialtyService();
        }
        public Test GetTest(int testId)
        {
            return dbContext.Tests.Include(t => t.Questions)
                            .Where(t => t.Id == testId)
                            .FirstOrDefault();
        }

        public List<Test> GetAllTests(int specialtyId)
        {
            return dbContext.Tests
                            .Where(t => t.Specialty.SpecialtyId == specialtyId)
                            .ToList();
        }
        public List<Question> GetTestQuestions(int testId)
        {
            return dbContext.Questions
                            .Where(q => q.Test.Id == testId)
                            .ToList();
        }

        public List<Answer> GetQuestionAnswers(int questionId)
        {
            return dbContext.Answers
                            .Where(a => a.Question.Id == questionId)
                            .ToList();
        }
        //public TestResult InsertResult(int test_id, int student_id, string grade)
        //{

        //}

        //public List<TestResult> GetStudentResults(int studentid, string sortColumn)
        //{

        //}

        public void SaveTestResult(TestResult testResult)
        {
            dbContext.TestResults.Add(testResult);
            dbContext.SaveChanges();
        }

    }
}