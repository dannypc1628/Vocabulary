using System;
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
    public class VocabulariesController : Controller
    {
        VocabularyRepository vocabularyRepository;
        VocabularyTypeRepository vocabularyTypeRepository;
        UnitRepository unitRepository;

        public VocabulariesController()
        {
            vocabularyRepository = RepositoryHelper.GetVocabularyRepository();
            unitRepository = RepositoryHelper.GetUnitRepository();
            vocabularyTypeRepository = RepositoryHelper.GetVocabularyTypeRepository();
        }

        // GET: Vocabularies
        public ActionResult Index()
        {
            var vocabulary = vocabularyRepository.All();
            return View(vocabulary.ToList());
        }

        // GET: Vocabularies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = vocabularyRepository.Find(id.Value);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // GET: Vocabularies/Create
        public ActionResult Create()
        {
            ViewBag.UnitID = new SelectList(unitRepository.All(), "ID", "Topic");
            ViewBag.TypeID = new SelectList(vocabularyTypeRepository.All(), "ID", "Name");
            return View();
        }

        // POST: Vocabularies/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UnitID,Word,PartsOfSpeech,Chinese,TypeID")] Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                vocabularyRepository.Add(vocabulary);
                vocabularyRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.UnitID = new SelectList(unitRepository.All(), "ID", "Topic", vocabulary.UnitID);
            ViewBag.TypeID = new SelectList(vocabularyTypeRepository.All(), "ID", "Name", vocabulary.TypeID);
            return View(vocabulary);
        }

        // GET: Vocabularies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = vocabularyRepository.Find(id.Value);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitID = new SelectList(unitRepository.All(), "ID", "Topic", vocabulary.UnitID);
            ViewBag.TypeID = new SelectList(vocabularyTypeRepository.All(), "ID", "Name", vocabulary.TypeID);
            return View(vocabulary);
        }

        // POST: Vocabularies/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UnitID,Word,PartsOfSpeech,Chinese,TypeID")] Vocabulary vocabulary)
        {
            if (ModelState.IsValid)
            {
                vocabularyRepository.UnitOfWork.Context.Entry(vocabulary).State = EntityState.Modified;
                vocabularyRepository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.UnitID = new SelectList(unitRepository.All(), "ID", "Topic", vocabulary.UnitID);
            ViewBag.TypeID = new SelectList(vocabularyTypeRepository.All(), "ID", "Name", vocabulary.TypeID);
            return View(vocabulary);
        }

        // GET: Vocabularies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vocabulary vocabulary = vocabularyRepository.Find(id.Value);
            if (vocabulary == null)
            {
                return HttpNotFound();
            }
            return View(vocabulary);
        }

        // POST: Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vocabulary vocabulary = vocabularyRepository.Find(id);
            vocabularyRepository.Delete(vocabulary);
            vocabularyRepository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vocabularyRepository.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
