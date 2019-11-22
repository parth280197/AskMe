﻿using AskMe.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace AskMe.API
{
  [Authorize]
  public class VotesController : ApiController
  {
    ApplicationDbContext _context = new ApplicationDbContext();

    [HttpPost]
    public IHttpActionResult UpVote(int id)
    {
      var user = _context.Users.Find(User.Identity.GetUserId());
      var post = _context.Posts.Find(id);
      var votes = post.Votes.ToList();
      if (votes.FindAll(u => u.UserId == user.Id).Count == 0)
      {
        Votes vote = new Votes
        {
          VotedDateTime = DateTime.Now,
          UserId = user.Id,
          User = user,
          Post = post,
          PostId = id,
        };
        post.Votes.Add(vote);
        _context.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }

    public IHttpActionResult DownVote(int id)
    {
      var user = _context.Users.Find(User.Identity.GetUserId());
      var post = _context.Posts.Find(id);
      var votes = post.Votes.ToList();
      if (votes.FindAll(u => u.UserId == user.Id).Count == 1)
      {
        var voteInDb = _context.Votes.Where(v => v.PostId == id && v.UserId == user.Id).FirstOrDefault();
        _context.Votes.Remove(voteInDb);
        _context.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }
  }
}
