using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Context;
using DomainModel.Entities;

namespace WebApp.Controllers
{
    public class ProfilesController : Controller
    {
        private SocialNetworkContext db = new SocialNetworkContext();

        // GET: Profiles
        public ActionResult Index()
        {

            return View(db.Profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null && Session["UserEmail"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Profile profile;
            if (id != null)
                 profile = db.Profiles.Find(id);
            else
                 profile = db.Profiles.ToList()
                    .Where(p => p.Email == Session["UserEmail"].ToString())
                    .First();

            ViewBag.Posts = db.Posts.ToList()
                .Where(post => post.Author.Id == profile.Id);


            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Name,Age,Photo")] Profile profile, HttpPostedFileBase profilePhoto)
        {
            if (ModelState.IsValid)
            {
                profile.Id = Guid.NewGuid();
                profile.Email = Session["UserEmail"].ToString();
                //---- Upload da Foto ----
                profile.Photo = StorageService.BlobService.GetInstance()
                    .UploadFile("simplesocialnetwork", Guid.NewGuid().ToString(), profilePhoto.InputStream, profilePhoto.ContentType);
                //------------------------
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Name,Age,Photo")] Profile profile, HttpPostedFileBase profilePhoto)
        {
            if (ModelState.IsValid)
            {
                if (profilePhoto != null)
                    //---- Upload da Foto ----
                    profile.Photo = StorageService.BlobService.GetInstance()
                        .UploadFile("simplesocialnetwork", Guid.NewGuid().ToString(), profilePhoto.InputStream, profilePhoto.ContentType);
                    //------------------------
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
