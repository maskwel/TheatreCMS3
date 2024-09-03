using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;
using TheatreCMS3.Areas.Blog.ViewModels;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogAuthors
        public ActionResult Index()
        {
            return View(db.BlogAuthors.ToList());
        }

        // GET: Blog/BlogAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }

            // Sample blog posts
            var samplePosts = new List<BlogPostViewModel>
            {
                new BlogPostViewModel
                {
                    Title = "Sample Post 1",
                    Description = "This is a description for sample post 1.",
                    BlogPhoto = "/Content/images/placeholder.jpg"
                },
                new BlogPostViewModel
                {
                    Title = "Sample Post 2",
                    Description = "This is a description for sample post 2.",
                    BlogPhoto = "/Content/images/placeholder.jpg"
                }
            };

            // Populate the ViewModel
            var viewModel = new BlogAuthorViewModel
            {
                BlogAuthor = blogAuthor,
                BlogPhoto = "/Content/images/placeholder.jpg", // Placeholder image------------------------------
                BlogPosts = samplePosts,
                TwitterUrl = "https://x.com/", // Placeholder URL-----------------------------------
                FacebookUrl = "https://facebook.com" // Placeholder URL----------------------------------
            };

            return View(viewModel);
        }

        // GET: Blog/BlogAuthors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.BlogAuthors.Add(blogAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }

            // Create a ViewModel to pass to the view
            var viewModel = new BlogAuthorViewModel
            {
                BlogAuthor = blogAuthor,
            };

            return View(viewModel);
        }

        // POST: Blog/BlogAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            db.BlogAuthors.Remove(blogAuthor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
