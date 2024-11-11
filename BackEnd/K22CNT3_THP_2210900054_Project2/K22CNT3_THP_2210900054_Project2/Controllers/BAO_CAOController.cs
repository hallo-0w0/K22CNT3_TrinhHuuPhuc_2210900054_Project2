using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT3_THP_2210900054_Project2.Models;

namespace K22CNT3_THP_2210900054_Project2.Controllers
{
    public class BAO_CAOController : Controller
    {
        private k22CNT3_TrinhHuuPhuc_Project2Entities db = new k22CNT3_TrinhHuuPhuc_Project2Entities();

        // GET: BAO_CAO
        public ActionResult Index()
        {
            var bAO_CAO = db.BAO_CAO.Include(b => b.QUAN_TRI).Include(b => b.VIDEO);
            return View(bAO_CAO.ToList());
        }

        // GET: BAO_CAO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_CAO bAO_CAO = db.BAO_CAO.Find(id);
            if (bAO_CAO == null)
            {
                return HttpNotFound();
            }
            return View(bAO_CAO);
        }

        // GET: BAO_CAO/Create
        public ActionResult Create()
        {
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau");
            ViewBag.ma_video = new SelectList(db.VIDEOs, "ma_video", "tieu_de");
            return View();
        }

        // POST: BAO_CAO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_bao_cao,noi_dung,ma_video,ngay_bao_cao,ma_quan_tri")] BAO_CAO bAO_CAO)
        {
            if (ModelState.IsValid)
            {
                db.BAO_CAO.Add(bAO_CAO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", bAO_CAO.ma_quan_tri);
            ViewBag.ma_video = new SelectList(db.VIDEOs, "ma_video", "tieu_de", bAO_CAO.ma_video);
            return View(bAO_CAO);
        }

        // GET: BAO_CAO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_CAO bAO_CAO = db.BAO_CAO.Find(id);
            if (bAO_CAO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", bAO_CAO.ma_quan_tri);
            ViewBag.ma_video = new SelectList(db.VIDEOs, "ma_video", "tieu_de", bAO_CAO.ma_video);
            return View(bAO_CAO);
        }

        // POST: BAO_CAO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_bao_cao,noi_dung,ma_video,ngay_bao_cao,ma_quan_tri")] BAO_CAO bAO_CAO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAO_CAO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", bAO_CAO.ma_quan_tri);
            ViewBag.ma_video = new SelectList(db.VIDEOs, "ma_video", "tieu_de", bAO_CAO.ma_video);
            return View(bAO_CAO);
        }

        // GET: BAO_CAO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAO_CAO bAO_CAO = db.BAO_CAO.Find(id);
            if (bAO_CAO == null)
            {
                return HttpNotFound();
            }
            return View(bAO_CAO);
        }

        // POST: BAO_CAO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAO_CAO bAO_CAO = db.BAO_CAO.Find(id);
            db.BAO_CAO.Remove(bAO_CAO);
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
