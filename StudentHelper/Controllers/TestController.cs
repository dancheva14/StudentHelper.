using StudentHelper.Models;
using StudentHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentHelper.Controllers
{
    public class TestController : Controller
    {
        private const string TESTKEY = "TESTKEY";
        private const string COURSEKEY = "COURSEKEY";
        List<Test> testModel = new List<Test>();
        private const int TESTQUESTIONSCOUNT = 10;
        public Test CurrentTest
        {
            get
            {
                return Session[TESTKEY] as Test ?? new Test();
            }
            set
            {
                Session[TESTKEY] = value;
            }
        }

        public Person User
        {
            get
            {
                return Session["USER"] as Person;
            }

            set
            {
                Session["USER"] = value;
            }
        }


        private TestService testService = new TestService();
        private SpecialtyService courseService = new SpecialtyService();

        public ActionResult Index(int id = 1)
        {
            if (id != 0)
            {
                var testModel = testService.GetTest(id);
                List<Test> tests = testService.GetAllTests(id);
                if (tests.Count() > 0)
                {
                    return AllTests(tests);
                }
                else
                {
                    if (testModel != null)
                    {
                        testModel.Questions = testService.GetTestQuestions(testModel.Id);
                        foreach (var question in testModel.Questions)
                        {
                            question.Answers = testService.GetQuestionAnswers(question.Id);
                        }

                        CurrentTest = testModel;

                        return View(testModel);
                    }
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AllTests(List<Test> tests)
        {
            return View("AllTests", tests);
        }


        [HttpPost]
        public ActionResult SubmitTest(Test test)
        {
            int correctAnswers = GradeTest(test);
            var testResult = new TestResult();


            DateTime date = DateTime.Now;
            string dateWithFormat = date.ToLongDateString();
            testResult.Date = DateTime.Now;
            testResult.CorrectAnswers = correctAnswers;
            testResult.EmptyAnswers = EmptyAnswers(test);
            testResult.WrongAnswers = TESTQUESTIONSCOUNT - (testResult.EmptyAnswers + correctAnswers);
            testResult.Procent = correctAnswers * 10;
            if (correctAnswers <= 2)
            {
                testResult.Status = "Bad";
                testResult.Grade = "Слаб(2)";
            }
            else if (correctAnswers <= 4)
            {
                testResult.Status = "Bad";
                testResult.Grade = "Среден(3)";
            }
            else if (correctAnswers <= 6)
            {
                testResult.Status = "Good";
                testResult.Grade = "Добър(4)";
            }
            else if (correctAnswers <= 8)
            {
                testResult.Status = "Excellent";
                testResult.Grade = "Много добър(5)";
            }
            else
            {
                testResult.Status = "Excellent";
                testResult.Grade = "Отличен(6)";
            }
            testResult.Test = test;
            testService.SaveTestResult(testResult);
            return View("TestResult", testResult);
        }

        private int GradeTest(Test test)
        {
            int countRightAnswers = 0;
            int countWrongAnswers = 0;
            if (test.Questions == null)
                return 0;
            for (int i = 0; i < test.Questions.Count(); i++)
            {
                if (test.Questions[i].Answer == 0)
                {
                }
                else if ((test.Questions[i].Answer - 1) == CurrentTest.Questions[i].RightAnswerIndex)
                {
                    countRightAnswers++;
                }
                else
                {
                    countWrongAnswers++;
                }
            }
            return countRightAnswers;
        }

        private int EmptyAnswers(Test test)
        {
            int countEmptyAnswers = 0;
            if (test.Questions == null)
                return 0;
            for (int i = 0; i < test.Questions.Count(); i++)
            {
                if (test.Questions[i].Answer == 0)
                {
                    countEmptyAnswers++;
                }
            }
            return countEmptyAnswers;
        }
    }
}