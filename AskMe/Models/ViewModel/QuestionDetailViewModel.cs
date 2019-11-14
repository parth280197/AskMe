using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.Models.ViewModel
{
    public class QuestionDetailViewModel
    {
        public Question Question { get; set; }
        public string AnswerContent { get; set; }
    }
}