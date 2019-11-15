using AskMe.BusinessLayer;
using AskMe.Models.ViewModel;
using Microsoft.AspNet.Identity;
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
      return View(allQuestions);
    }

    public ActionResult CreateQuestion()
    {
      QuestionCreateViewModel viewModel = new QuestionCreateViewModel()
      {
        Tags = QBL.GetAllTags(),
        UserId = User.Identity.GetUserId(),
      };
      return View(viewModel);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult CreateQuestion(QuestionCreateViewModel questionViewModel)
    {
      QBL.CreateQuestion(questionViewModel);
      return RedirectToAction("Index");
    }

    public ActionResult QuestionDetails(int Id)
    {
      QuestionDetailViewModel questionDetailViewModel = new QuestionDetailViewModel
      {
        Question = QBL.GetQuestions(Id),
        UserId = User.Identity.GetUserId(),
        QuestionId = Id,
      };
      return View(questionDetailViewModel);
    }
    [HttpPost]
    [ValidateInput(false)]
    public ActionResult QuestionDetails(QuestionDetailViewModel questionDetailViewModel)
    {
      QBL.CreateAnswer(questionDetailViewModel);
      return View(questionDetailViewModel);
    }
  }
}