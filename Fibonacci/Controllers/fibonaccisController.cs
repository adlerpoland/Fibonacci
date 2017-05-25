using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fibonacci.Models;
using System.Threading.Tasks;

namespace Fibonacci.Controllers
{
    public class fibonaccisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private static Random random = new Random();

        public void generate()
        {
            fibonacci record = new fibonacci();
            record.name = RandomString(5);
            record.n = RandomInt();
            record.UserName = RandomString(8);
            db.fibonaccis.Add(record);
            db.SaveChanges();
        }

        public int RandomInt()
        { 
            return random.Next(1, 20);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET: fibonaccis
        public ActionResult Index(bool? gener)
        {
            if (gener == true)
                generate();
            else if (gener == false)
                Fibon();          
            return View(db.fibonaccis.ToList());
        }

        public void Fibon()
        {
            foreach (var f in db.fibonaccis)
                f.n = fibo(f.n);
        }


        public int fibo(int n)
        {
            if (n > 1)
                return fibo(n - 1) + fibo(n - 2);
            return n;
        }

        // GET: fibonaccis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibonacci fibonacci = db.fibonaccis.Find(id);
            if (fibonacci == null)
            {
                return HttpNotFound();
            }
            return View(fibonacci);
        }

        // GET: fibonaccis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: fibonaccis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,n,UserName")] fibonacci fibonacci)
        {
            if (ModelState.IsValid)
            {
                db.fibonaccis.Add(fibonacci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fibonacci);
        }

        // GET: fibonaccis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibonacci fibonacci = db.fibonaccis.Find(id);
            if (fibonacci == null)
            {
                return HttpNotFound();
            }
            return View(fibonacci);
        }

        // POST: fibonaccis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,n,UserName")] fibonacci fibonacci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fibonacci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fibonacci);
        }

        // GET: fibonaccis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fibonacci fibonacci = db.fibonaccis.Find(id);
            if (fibonacci == null)
            {
                return HttpNotFound();
            }
            return View(fibonacci);
        }

        // POST: fibonaccis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fibonacci fibonacci = db.fibonaccis.Find(id);
            db.fibonaccis.Remove(fibonacci);
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
