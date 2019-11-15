using System.ComponentModel.DataAnnotations;

namespace AskMe.Models.ViewModel
{
  public class QuestionDetailViewModel
  {
    public Question Question { get; set; }
    [Display(Name = "Add your answer.")]
    public string AnswerContent { get; set; }
    public string UserId { get; set; }
    public int QuestionId { get; set; }
  }
}