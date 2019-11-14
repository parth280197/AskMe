using AskMe.BusinessLayer;
using AskMe.Models;
using AskMe.Models.ViewModel;
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
        Tags = new List<Tag>()
        {
          new Tag() {Id=1,Name="Tag1"}
        }
      };
      return View(viewModel);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult CreateQuestion(QuestionCreateViewModel question)
    {

      return View();
    }
  }
}