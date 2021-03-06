﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VocabularyProject.Models;

namespace VocabularyProject.Controllers
{
    public class UnitsController : Controller
    {
        UnitRepository unitRepository;
        BookRepository bookRepository;

        public UnitsController()
        {
            unitRepository = RepositoryHelper.GetUnitRepository();
            bookRepository = RepositoryHelper.GetBookRepository();
        }

        // GET: Units
        public ActionResult Index()
        {
            var unit = unitRepository.All();
            return View(unit.ToList());
        }
        public ActionResult List(int? bookID)
        {
            if (bookID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var unitList = unitRepository.Where(u => u.BookID == bookID);
            return View("index", unitList);


        }

        //GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.Find(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(bookRepository.All(), "ID", "Name");
            return View();
        }

        // POST: Units/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Number,Topic,BookID")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                unitRepository.Add(unit);
                unitRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(bookRepository.All(), "ID", "Name", unit.BookID);
            return View(unit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.Find(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(bookRepository.All(), "ID", "Name", unit.BookID);
            return View(unit);
        }

        // POST: Units/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Number,Topic,BookID")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                unitRepository.UnitOfWork.Context.Entry(unit).State = EntityState.Modified;
                unitRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(bookRepository.All(), "ID", "Name", unit.BookID);
            return View(unit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = unitRepository.Find(id.Value);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = unitRepository.Find(id);
            unitRepository.Delete(unit);
            unitRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
