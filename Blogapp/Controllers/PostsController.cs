using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private static List<Post> posts = new List<Post>();

        public ActionResult Index()
        {
            return View(posts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Id = posts.Count + 1;
                post.CreatedAt = DateTime.Now;

                posts.Add(post);

                return RedirectToAction("Index");
            }

            return View(post);
        }
    }
}
