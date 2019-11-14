using System.Collections.Generic;

namespace AskMe.Models.ViewModel
{
  public class QuestionCreateViewModel
  {
    public string Content { get; set; }
    public string Title { get; set; }
    public List<Tag> Tags { get; set; }
    public int[] TagsId { get; set; }
    public string NewTags { get; set; }
  }
}