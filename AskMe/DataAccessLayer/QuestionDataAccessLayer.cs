using AskMe.Models;
using AskMe.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


namespace AskMe.DataAccessLayer
{
    public class QuestionDataAccessLayer
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public List<Question> GetAllQuestions()
        {
            return _context.Questions.Include(q=>q.Post).ToList();
        }

        public List<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }
        public List<Tag> GetSelectedAllTags(int[] selectedId)
        {
            List<Tag> result = new List<Tag>();
            foreach(var id in selectedId)
            {
                var tag = _context.Tags.Find(id);
                result.Add(tag);
            }
            return result;
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            var id = post.PostId;
        }

        public void CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

    }
}