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
    public class VIDEOsController : Controller
    {
        private k22CNT3_TrinhHuuPhuc_Project2Entities db = new k22CNT3_TrinhHuuPhuc_Project2Entities();

        // GET: VIDEOs
        public ActionResult Index()
        {
            var vIDEOs = db.VIDEOs.Include(v => v.QUAN_TRI);
            return View(vIDEOs.ToList());
        }

        // GET: VIDEOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEOs.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEO);
        }

        // GET: VIDEOs/Create
        public ActionResult Create()
        {
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau");
            return View();
        }

        // POST: VIDEOs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_video,tieu_de,mo_ta,duong_dan,hinh_anh,the_loai,ngay_tao,ma_quan_tri,trang_thai")] VIDEO vIDEO)
        {
            if (ModelState.IsValid)
            {
                db.VIDEOs.Add(vIDEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", vIDEO.ma_quan_tri);
            return View(vIDEO);
        }

        // GET: VIDEOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEOs.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", vIDEO.ma_quan_tri);
            return View(vIDEO);
        }

        // POST: VIDEOs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_video,tieu_de,mo_ta,duong_dan,hinh_anh,the_loai,ngay_tao,ma_quan_tri,trang_thai")] VIDEO vIDEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIDEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_quan_tri = new SelectList(db.QUAN_TRI, "tai_khoan", "mat_khau", vIDEO.ma_quan_tri);
            return View(vIDEO);
        }

        // GET: VIDEOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIDEO vIDEO = db.VIDEOs.Find(id);
            if (vIDEO == null)
            {
                return HttpNotFound();
            }
            return View(vIDEO);
        }

        // POST: VIDEOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIDEO vIDEO = db.VIDEOs.Find(id);
            db.VIDEOs.Remove(vIDEO);
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
