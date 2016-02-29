using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using StatusBoard.Infrastructure.DbContext;

namespace StatusBoard.Web.Controllers
{
    public class ServerCategoriesController : Controller
    {
        private readonly IServerCategoryService _serverCategoryService;

        public ServerCategoriesController(IServerCategoryService serverCategoryService)
        {
            _serverCategoryService = serverCategoryService;
        }

        // GET: ServerCategories
        public ActionResult Index()
        {
            return View(_serverCategoryService.GetAllCategories().ToList());
        }

        // GET: ServerCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serverCategory = _serverCategoryService.FindById(id.Value);
            if (serverCategory == null)
            {
                return HttpNotFound();
            }
            return View(serverCategory);
        }

        // GET: ServerCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServerCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,CategoryColor)")] ServerCategory serverCategory)
        {
            if (ModelState.IsValid)
            {
                _serverCategoryService.Add(serverCategory);
                return RedirectToAction("Index");
            }

            return View(serverCategory);
        }

        // GET: ServerCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serverCategory = _serverCategoryService.FindById(id.Value);
            if (serverCategory == null)
            {
                return HttpNotFound();
            }
            return View(serverCategory);
        }

        // POST: ServerCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServerCategory serverCategory)
        {
            if (ModelState.IsValid)
            {
                _serverCategoryService.Update(serverCategory);
                return RedirectToAction("Index");
            }
            return View(serverCategory);
        }

        // GET: ServerCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serverCategory = _serverCategoryService.FindById(id.Value);
            if (serverCategory == null)
            {
                return HttpNotFound();
            }
            return View(serverCategory);
        }

        // POST: ServerCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var serverCategory = _serverCategoryService.FindById(id);
            _serverCategoryService.Remove(serverCategory);
            return RedirectToAction("Index");
        }
    }
}
