using AskMe.BusinessLayer;
using AskMe.Models;
using AskMe.Models.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
            QuestionCreateViewModel viewModel = new QuestionCreateViewModel()
            {
                Tags = QBL.GetAllTags(),
                UserId= User.Identity.GetUserId(),
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateQuestion(QuestionCreateViewModel questionViewModel)
        {
            QBL.CreateQuestion(questionViewModel);
            return View();
        }
    }
}