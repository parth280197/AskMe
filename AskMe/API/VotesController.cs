using AskMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AskMe.API
{
    public class VotesController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IHttpActionResult UpVote(int postId)
        {
            var user = User.Identity.GetUserId();
            var post = _context.Posts.Find(postId);
            var votes = post.Votes.ToList();
            if (votes.FindAll(u => u.UserId == userId).Count == 0)
            {
                Votes vote = new Votes
                {
                    VotedDateTime = DateTime.Now,
                    UserId = userId,
                    User = user,
                    Post = post,
                    PostId = postId,
                };
                post.Votes.Add(vote);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
