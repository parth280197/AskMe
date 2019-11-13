using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AskMe.DataAccessLayer;
using AskMe.Models;

namespace AskMe.BusinessLayer
{
    public class QuestionBusinessLayer
    {
        QuestionDataAccessLayer QDL = new QuestionDataAccessLayer();

        public List<Question> GetAllQuestions()
        {
            return QDL.GetAllQuestions();
        }
    }
}