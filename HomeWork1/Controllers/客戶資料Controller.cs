using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HomeWork1.Models;

namespace HomeWork1.Controllers
{
   public class 客戶資料Controller: Controller
   {
      private 客戶資料Entities db = new 客戶資料Entities();

      public ActionResult 客戶關聯資料表() {
         return View(db.vw客戶關聯資料統計表.ToList());
      }

      // GET: 客戶資料
      public ActionResult Index(string keyword) {
         var data = db.客戶資料.Where(d => false == d.IsDelete).AsQueryable();

         if (!string.IsNullOrEmpty(keyword)) {
            data = data.Where(d => d.客戶名稱.Contains(keyword));
         }

         return View(data.ToList());
      }

      // GET: 客戶資料/Details/5
      public ActionResult Details(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         客戶資料 客戶資料 = db.客戶資料.Find(id);
         if (客戶資料 == null) {
            return HttpNotFound();
         }
         return View(客戶資料);
      }

      // GET: 客戶資料/Create
      public ActionResult Create() {
         return View();
      }

      // POST: 客戶資料/Create
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料) {
         if (ModelState.IsValid) {
            db.客戶資料.Add(客戶資料);
            db.SaveChanges();
            return RedirectToAction("Index");
         }

         return View(客戶資料);
      }

      // GET: 客戶資料/Edit/5
      public ActionResult Edit(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         客戶資料 客戶資料 = db.客戶資料.Find(id);
         if (客戶資料 == null) {
            return HttpNotFound();
         }
         return View(客戶資料);
      }

      // POST: 客戶資料/Edit/5
      // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
      // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料) {
         if (ModelState.IsValid) {
            db.Entry(客戶資料).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         return View(客戶資料);
      }

      // GET: 客戶資料/Delete/5
      public ActionResult Delete(int? id) {
         if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         客戶資料 客戶資料 = db.客戶資料.Find(id);
         if (客戶資料 == null) {
            return HttpNotFound();
         }
         return View(客戶資料);
      }

      // POST: 客戶資料/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public ActionResult DeleteConfirmed(int id) {
         客戶資料 客戶資料 = db.客戶資料.Find(id);
         客戶資料.IsDelete = true;
         db.SaveChanges();
         return RedirectToAction("Index");
      }

      protected override void Dispose(bool disposing) {
         if (disposing) {
            db.Dispose();
         }
         base.Dispose(disposing);
      }


   }
}
