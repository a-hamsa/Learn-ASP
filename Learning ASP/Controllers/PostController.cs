using Learning_ASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Learning_ASP.Controllers
{
    [Route("/")]
    public class PostController : Controller
    {
        private static List<Post> posts = new List<Post>();
        // GET: HomeController1
        [HttpGet("")]
        public ActionResult Index()
        {
            return View(posts);
        }

        // GET: HomeController1/Details/5
        [HttpGet("details/{id}")]
        public ActionResult Details(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: HomeController1/Create
        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
                // Assign a unique ID and creation time
                post.Id = posts.Count > 0 ? posts.Max(p => p.Id) + 1 : 1;
                post.CreatedAt = DateTime.UtcNow;

                posts.Add(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        [HttpGet("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: HomeController1/Edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post updatedPost)
        {
            try
            {
                var post = posts.FirstOrDefault(p => p.Id == id);
                if (post == null)
                {
                    return NotFound();
                }

                // Update fields
                post.Title = updatedPost.Title;
                post.Content = updatedPost.Content;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: HomeController1/Delete/5
        [HttpGet("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var post = posts.FirstOrDefault(p => p.Id == id);
                if (post != null)
                {
                    posts.Remove(post);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
