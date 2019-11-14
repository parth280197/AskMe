using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AskMe.DataAccessLayer;
using AskMe.Models;
using AskMe.Models.ViewModel;

namespace AskMe.BusinessLayer
{
    public class QuestionBusinessLayer
    {
        QuestionDataAccessLayer QDL = new QuestionDataAccessLayer();

        public List<Question> GetAllQuestions()
        {
            return QDL.GetAllQuestions();
        }

        public List<Tag> GetAllTags()
        {
            return QDL.GetAllTags();
        }
        public List<Tag> GetSelectedAllTags(int[] selectedId)
        {
   
            return QDL.GetSelectedAllTags(selectedId);
        }

        public void CreateQuestion(QuestionCreateViewModel questionViewModel)
        {
            Post post = new Post()
            {
                Content = questionViewModel.Content,
                Title = questionViewModel.Title,
                CreatedTime = DateTime.Now,
                CreatedById = questionViewModel.UserId,
            };
            Question question = new Question()
            {

                Post = post,
                Tags = QDL.GetSelectedAllTags(questionViewModel.TagsId),
            };
            QDL.CreatePost(post);
            QDL.CreateQuestion(question);
            
        }
    }
}