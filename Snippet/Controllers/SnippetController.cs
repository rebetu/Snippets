using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Snippet.DataAccess;
using Snippet.Models;
using Snippet.ModelViews;
using System.Web.Mvc;
using Snippet.Services;

namespace Snippet.Controllers
{
    public class SnippetController : ApiController
    {
        private MainContext db = new MainContext();
        private AchievementService AchievementService { get; set; }

        public SnippetController(AchievementService achievementService)
        {
            AchievementService = achievementService;
        }

        // GET: api/SnippetText
        public IQueryable<SnippetText> GetSnippets()
        {
            return db.Snippets;
        }

        // GET: api/SnippetText/5
        [ResponseType(typeof(SnippetText))]
        public IHttpActionResult GetSnippetText(int id)
        {
            SnippetText snippetText = db.Snippets.Find(id);
            if (snippetText == null)
            {
                return NotFound();
            }

            return Ok(snippetText);
        }

        // GET: api/SnippetText/5
        //[ResponseType(typeof(SnippetText))]

        public IHttpActionResult GetSnippetsByUser(int userId)
        {
            var snippetTexts = db.Snippets.Include(x => x.User).Where(x => x.User.Id == userId).ToList();
            if (snippetTexts == null)
            {
                return NotFound();
            }

            var snippets = new List<SnippetTextModelView>();
            foreach (var snippetText in snippetTexts)
            {
                var snippet = new SnippetTextModelView(snippetText);
                snippets.Add(snippet);
            }

            return Json(new { snippets });
        }

        public IHttpActionResult GetSharedSnippets()
        {
            var shared = db.SnippetShares.Include(x => x.SharedBy).Where(x => x.IsShared == true).ToList();
            if (shared == null)
            {
                return Json("There are currently no shared snippets." );
            }

            var sharedSnippets = new List<SnippetShareModelView>();
            foreach(var share in shared)
            {
                var sharedSnippet = new SnippetShareModelView(share);
                sharedSnippets.Add(sharedSnippet);
            }

            return Json(new { sharedSnippets });
        }

        // POST: api/SnippetText
        //[ResponseType(typeof(SnippetText))]
        public IHttpActionResult CreateSnippet(string text)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //TODO: check for null or invalid string

            var user = db.AppUsers.FirstOrDefault();

            SnippetText newSnippet = new SnippetText() { Text = text, CreatedDate = DateTime.Now, User = user };

            db.Snippets.Add(newSnippet);
            db.SaveChanges();

            var snippetTexts = db.Snippets.Include(x => x.User).Where(x => x.User.Id == user.Id).ToList();

            var snippets = new List<SnippetTextModelView>();
            foreach (var snippetText in snippetTexts)
            {
                var snippet = new SnippetTextModelView(snippetText);
                snippets.Add(snippet);
            }


            return Json(new { snippets });
        }

        //[System.Web.Http.ActionName("unshare")]
        public IHttpActionResult ShareSnippet(int snippetId)
        {
            var user = db.AppUsers.FirstOrDefault();

            var snippet = db.Snippets.FirstOrDefault(x => x.Id == snippetId);
            if(snippet == null)
            {
                throw new Exception("Snippet not found.");
            }
            if(snippet.User.Id == user.Id)
            {
                //Assumption
                throw new Exception("Users cannot share their own snippets."); 
            }

            SnippetShare share = null;
            var previouslySharedSnippet = db.SnippetShares.Include(x => x.SharedBy).FirstOrDefault(x => x.SharedBy.Id == user.Id && x.Snippet.Id == snippetId);
            if(previouslySharedSnippet == null)
            {
                share = new SnippetShare() { Snippet = snippet, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, SharedBy = user };
                db.SnippetShares.Add(share);
            }
            else
            {
                previouslySharedSnippet.IsShared = true;
            }

            db.SaveChanges();

            var snippetShares = db.SnippetShares.Where(x => x.IsShared == true).ToList();
            var sharedSnippets = new List<SnippetShareModelView>();
            foreach (var snippetShare in snippetShares)
            {
                var sharedSnippet = new SnippetShareModelView(snippetShare);
                sharedSnippets.Add(sharedSnippet);
            }
            //TODO: AchievementCount

            return Json(new { sharedSnippets });
        }

        //[System.Web.Http.ActionName("share")]
        public IHttpActionResult UnshareSnippet(int snippetId)
        {
            var user = db.AppUsers.FirstOrDefault();

            var snippet = db.Snippets.FirstOrDefault(x => x.Id == snippetId);
            if (snippet == null)
            {
                throw new Exception("Snippet not found.");
            }
            if (snippet.User.Id == user.Id)
            {
                //Assumption
                throw new Exception("Users cannot share or unshare their own snippets.");
            }
            var previouslySharedSnippet = db.SnippetShares.Include(x => x.SharedBy).FirstOrDefault(x => x.SharedBy.Id == user.Id && x.Snippet.Id == snippetId);
            if (previouslySharedSnippet == null)
            {
                throw new Exception("This snippet was never shared.");
            }
            else
            {
                previouslySharedSnippet.IsShared = false;
            }
            db.SaveChanges();

            var snippetShares = db.SnippetShares.Where(x => x.IsShared == true).ToList();
            var sharedSnippets = new List<SnippetShareModelView>();
            foreach (var snippetShare in snippetShares)
            {
                var sharedSnippet = new SnippetShareModelView(snippetShare);
                sharedSnippets.Add(sharedSnippet);
            }

            return Json(new { sharedSnippets });
        }

        public IHttpActionResult LikeSnippet(int snippetId)
        {
            var user = db.AppUsers.FirstOrDefault();

            var snippet = db.Snippets.FirstOrDefault(x => x.Id == snippetId);
            if (snippet == null)
            {
                throw new Exception("Snippet not found.");
            }
            if (snippet.User.Id == user.Id)
            {
                //Assumption
                throw new Exception("Users cannot like their own snippets.");
            }

            SnippetLike like = null;
            var previouslyLikedSnippet = db.SnippetLikes.Include(x => x.LikedBy).FirstOrDefault(x => x.LikedBy.Id == user.Id && x.Snippet.Id == snippetId);
            if (previouslyLikedSnippet == null)
            {
                like = new SnippetLike() { Snippet = snippet, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, LikedBy = user };
                db.SnippetLikes.Add(like);
            }
            else
            {
                previouslyLikedSnippet.IsLiked = true;
                like = previouslyLikedSnippet;
            }

            db.SaveChanges();

            var likedSnippet = new SnippetLikeModelView(like);
            
            //TODO: AchievementCount

            return Json(new { likedSnippet });
        }


        public IHttpActionResult UnlikeSnippet(int snippetId)
        {
            var user = db.AppUsers.FirstOrDefault();

            var snippet = db.Snippets.FirstOrDefault(x => x.Id == snippetId);
            if (snippet == null)
            {
                throw new Exception("Snippet not found.");
            }
            if (snippet.User.Id == user.Id)
            {
                //Assumption
                throw new Exception("Users cannot like or unlike their own snippets.");
            }
            var previouslyLikedSnippet = db.SnippetLikes.Include(x => x.LikedBy).FirstOrDefault(x => x.LikedBy.Id == user.Id && x.Snippet.Id == snippetId);
            if (previouslyLikedSnippet == null)
            {
                throw new Exception("This snippet was never liked.");
            }
            else
            {
                previouslyLikedSnippet.IsLiked = false;
                db.SaveChanges();
            }
            var unlikedSnippet = new SnippetLikeModelView(previouslyLikedSnippet);
            return Json(new { unlikedSnippet });
        }

        // PUT: api/SnippetText/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSnippetText(int id, SnippetText snippetText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != snippetText.Id)
            {
                return BadRequest();
            }

            db.Entry(snippetText).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnippetTextExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        

        // DELETE: api/SnippetText/5
        [ResponseType(typeof(SnippetText))]
        public IHttpActionResult DeleteSnippetText(int id)
        {
            SnippetText snippetText = db.Snippets.Find(id);
            if (snippetText == null)
            {
                return NotFound();
            }

            db.Snippets.Remove(snippetText);
            db.SaveChanges();

            return Ok(snippetText);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SnippetTextExists(int id)
        {
            return db.Snippets.Count(e => e.Id == id) > 0;
        }
    }
}