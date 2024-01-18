using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseAccess;

namespace SchoolManagementSystem.Controllers
{
    public class ProgramSessionTablesController : Controller
    {
        private SchoolManagementSystemEntities db = new SchoolManagementSystemEntities();

        // GET: ProgramSessionTables
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            var programSessionTables = db.ProgramSessionTables.Include(p => p.ProgramTable).Include(p => p.SessionTable).Include(p => p.UserTable);
            return View(programSessionTables.ToList());
        }

        // GET: ProgramSessionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name");
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName");
            return View();
        }

        // POST: ProgramSessionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramSessionTable programSessionTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            programSessionTable.UserID = userid;
            if (ModelState.IsValid)
            {
                var sessionname = db.SessionTables.Where(s => s.SessionID == programSessionTable.SessionID).SingleOrDefault();
                var programname = db.ProgramTables.Where(s => s.ProgramID == programSessionTable.ProgramID).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programSessionTable.Details.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programname != null ? programname.Name : "") + ")" + programSessionTable.Details;
                        programSessionTable.Details = details;
                    }
                }
                db.ProgramSessionTables.Add(programSessionTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // POST: ProgramSessionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgramSessionTable programSessionTable)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            int userid = Convert.ToInt32(Convert.ToString(Session["UserID"]));
            programSessionTable.UserID = userid;
            if (ModelState.IsValid)
            {
                var sessionname = db.SessionTables.Where(s => s.SessionID == programSessionTable.SessionID).SingleOrDefault();
                var programname = db.ProgramTables.Where(s => s.ProgramID == programSessionTable.ProgramID).SingleOrDefault();
                if (sessionname != null)
                {
                    if (!programSessionTable.Details.Contains(sessionname.Name))
                    {
                        var details = "(" + sessionname.Name + "-" + (programname != null ? programname.Name : "") + ")" + programSessionTable.Details;
                        programSessionTable.Details = details;
                    }
                }
                db.Entry(programSessionTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramID = new SelectList(db.ProgramTables, "ProgramID", "Name", programSessionTable.ProgramID);
            ViewBag.SessionID = new SelectList(db.SessionTables, "SessionID", "Name", programSessionTable.SessionID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "FullName", programSessionTable.UserID);
            return View(programSessionTable);
        }

        // GET: ProgramSessionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            if (programSessionTable == null)
            {
                return HttpNotFound();
            }
            return View(programSessionTable);
        }

        // POST: ProgramSessionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Login", "Home");
            }
            ProgramSessionTable programSessionTable = db.ProgramSessionTables.Find(id);
            db.ProgramSessionTables.Remove(programSessionTable);
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
