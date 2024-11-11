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
    public class DANH_MUC_VIDEOController : Controller
    {
        private k22CNT3_TrinhHuuPhuc_Project2Entities db = new k22CNT3_TrinhHuuPhuc_Project2Entities();

        // GET: DANH_MUC_VIDEO
        public ActionResult Index()
        {
            return View(db.DANH_MUC_VIDEO.ToList());
        }

        // GET: DANH_MUC_VIDEO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC_VIDEO dANH_MUC_VIDEO = db.DANH_MUC_VIDEO.Find(id);
            if (dANH_MUC_VIDEO == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC_VIDEO);
        }

        // GET: DANH_MUC_VIDEO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DANH_MUC_VIDEO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_danh_muc,ten_danh_muc,mo_ta")] DANH_MUC_VIDEO dANH_MUC_VIDEO)
        {
            if (ModelState.IsValid)
            {
                db.DANH_MUC_VIDEO.Add(dANH_MUC_VIDEO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dANH_MUC_VIDEO);
        }

        // GET: DANH_MUC_VIDEO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC_VIDEO dANH_MUC_VIDEO = db.DANH_MUC_VIDEO.Find(id);
            if (dANH_MUC_VIDEO == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC_VIDEO);
        }

        // POST: DANH_MUC_VIDEO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_danh_muc,ten_danh_muc,mo_ta")] DANH_MUC_VIDEO dANH_MUC_VIDEO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_MUC_VIDEO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dANH_MUC_VIDEO);
        }

        // GET: DANH_MUC_VIDEO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_MUC_VIDEO dANH_MUC_VIDEO = db.DANH_MUC_VIDEO.Find(id);
            if (dANH_MUC_VIDEO == null)
            {
                return HttpNotFound();
            }
            return View(dANH_MUC_VIDEO);
        }

        // POST: DANH_MUC_VIDEO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DANH_MUC_VIDEO dANH_MUC_VIDEO = db.DANH_MUC_VIDEO.Find(id);
            db.DANH_MUC_VIDEO.Remove(dANH_MUC_VIDEO);
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
