using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200CentricTeam4.DAL;
using MIS4200CentricTeam4.Models;

namespace MIS4200CentricTeam4.Controllers
{
    public class EmployeeFeedbacksController : Controller
    {
        private Context db = new Context();

        // GET: EmployeeFeedbacks
        public ActionResult Index()
        {
            var employeeFeedbacks = db.EmployeeFeedbacks.Include(e => e.Employee).Include(e => e.Feedback);
            return View(employeeFeedbacks.ToList());
        }

        // GET: EmployeeFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFeedback employeeFeedback = db.EmployeeFeedbacks.Find(id);
            if (employeeFeedback == null)
            {
                return HttpNotFound();
            }
            return View(employeeFeedback);
        }

        // GET: EmployeeFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "firstName");
            ViewBag.feedbackID = new SelectList(db.Feedbacks, "feedbackID", "employeeName");
            return View();
        }

        // POST: EmployeeFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeFeedbackID,feedbackDescription,time,feedbackProvider,employeeID,feedbackID")] EmployeeFeedback employeeFeedback)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeFeedbacks.Add(employeeFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "firstName", employeeFeedback.employeeID);
            ViewBag.feedbackID = new SelectList(db.Feedbacks, "feedbackID", "employeeName", employeeFeedback.feedbackID);
            return View(employeeFeedback);
        }

        // GET: EmployeeFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFeedback employeeFeedback = db.EmployeeFeedbacks.Find(id);
            if (employeeFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "firstName", employeeFeedback.employeeID);
            ViewBag.feedbackID = new SelectList(db.Feedbacks, "feedbackID", "employeeName", employeeFeedback.feedbackID);
            return View(employeeFeedback);
        }

        // POST: EmployeeFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeFeedbackID,feedbackDescription,time,feedbackProvider,employeeID,feedbackID")] EmployeeFeedback employeeFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "firstName", employeeFeedback.employeeID);
            ViewBag.feedbackID = new SelectList(db.Feedbacks, "feedbackID", "employeeName", employeeFeedback.feedbackID);
            return View(employeeFeedback);
        }

        // GET: EmployeeFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeFeedback employeeFeedback = db.EmployeeFeedbacks.Find(id);
            if (employeeFeedback == null)
            {
                return HttpNotFound();
            }
            return View(employeeFeedback);
        }

        // POST: EmployeeFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeFeedback employeeFeedback = db.EmployeeFeedbacks.Find(id);
            db.EmployeeFeedbacks.Remove(employeeFeedback);
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
