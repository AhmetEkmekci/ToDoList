using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.DataAccessLayer;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Authorize]
    public class EntryController : Controller
    {
        IRepository<Model.Entry> EntityRepository;
        public EntryController(IRepository<Model.Entry> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        // GET: Entry
        public ActionResult Index(string q = null)
        {
            var model = EntityRepository
                .GetAll()
                .OrderBy(x=>x.EndDateUtc)
                .Where(x=>string.IsNullOrEmpty(q) || x.Title.Contains(q) || x.Content.Contains(q))
                .Take(20);
            return View();
        }

        // GET: Entry/Details/5
        public ActionResult Details(int id)
        {
            return View(EntityRepository.FindBy(x=>x.Id == id).FirstOrDefault());
        }

        // GET: Entry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entry/Create
        [HttpPost]
        public ActionResult Create(Entry entry)
        {
            entry = new Entry();
            try
            {
                EntityRepository.Add(entry);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entry/Edit/5
        public ActionResult Edit(int id)
        {
            return View(EntityRepository.FindBy(x=>x.Id == id).FirstOrDefault());
        }

        // POST: Entry/Edit/5
        [HttpPost]
        public ActionResult Edit(Entry entry)
        {
            try
            {
                EntityRepository.AddOrUpdate(entry);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Entry/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EntityRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
