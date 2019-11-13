using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AskMe.BusinessLayer;
using AskMe.Models;

namespace AskMe.Controllers
{
    public class QuestionController : Controller
    {
        QuestionBusinessLayer QBL = new QuestionBusinessLayer();

        // GET: Question
        public ActionResult Index()
        {
            var allQuestions = QBL.GetAllQuestions();
            return View();
        }

        public ActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateQuestion(Question question)
        {

            return View();
        }
    }
}