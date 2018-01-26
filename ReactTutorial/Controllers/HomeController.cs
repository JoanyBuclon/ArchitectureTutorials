using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyberMudWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberMudWeb.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Henry",
                    Text = "First!"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Test",
                    Text = "This is a *test*"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Me",
                    Text = "Yet another message"
                },
                new CommentModel
                {
                    Id = 4,
                    Author = "Test",
                    Text = "I'm back"
                },
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success");
        }
    }
}
