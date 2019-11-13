using AskMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AskMe.DataAccessLayer
{
    public class QuestionDataAccessLayer
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }
    }
}