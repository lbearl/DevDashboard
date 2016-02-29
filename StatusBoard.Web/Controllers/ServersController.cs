using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using StatusBoard.Core;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;
using System.Collections.Generic;

namespace StatusBoard.Web.Controllers
{
    [Authorize]
    public class ServersController : Controller
    {
        private readonly IServerService _serverService;
        private readonly IServerCategoryService _serverCategoryService;

        public ServersController(IServerService serverService, IServerCategoryService serverCategoryService)
        {
            _serverService = serverService;
            _serverCategoryService = serverCategoryService;
        }

        // GET: Servers
        [HttpGet]
        public ActionResult Index()
        {
            var vm = _serverService.GetAll().Select(x => new ViewModels.ServerVM() {ServerId = x.Id, HostName = x.Hostname, DisplayName = x.DisplayName});
            return View(vm);
        }

        // GET: Servers/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var server = _serverService.FindById(id.Value);
            if (server == null)
            {
                return HttpNotFound();
            }
            var vm = new ViewModels.ServerVM() { ServerId = server.Id, HostName = server.Hostname, DisplayName = server.DisplayName};

            return View(vm);
        }

        // GET: Servers/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.ServerVM vm)
        {
            if (ModelState.IsValid)
            {
                var server = new Server() {IsActive = vm.IsActive, DisplayName = vm.DisplayName, Hostname = vm.HostName, Id = vm.ServerId};
                _serverService.Add(server);
                return RedirectToAction(Constants.Controller.Actions.Index);
            }

            return View(vm);
        }

        // GET: Servers/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var server = _serverService.FindById(id.Value);
            if (server == null)
            {
                return HttpNotFound();
            }
            var vm = new ViewModels.ServerVM
            {
                ServerId = server.Id,
                HostName = server.Hostname,
                DisplayName = server.DisplayName,
                Categories = GetCategories()
            };
            return View(vm);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.ServerVM vm)
        {
            if (ModelState.IsValid)
            {
                var server = new Server() { IsActive = vm.IsActive, DisplayName = vm.DisplayName, Hostname = vm.HostName, Id = vm.ServerId };
                _serverService.Update(server);
                return RedirectToAction(Constants.Controller.Actions.Index);
            }
            return View(vm);
        }

        // GET: Servers/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var server = _serverService.FindById(id.Value);
            if (server == null)
            {
                return HttpNotFound();
            }
            var vm = new ViewModels.ServerVM() { ServerId = server.Id, HostName = server.Hostname, DisplayName = server.DisplayName};
            return View(vm);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var server = _serverService.FindById(id);
            _serverService.Remove(server);
            return RedirectToAction(Constants.Controller.Actions.Index);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serverService.Dispose();
            }
            base.Dispose(disposing);
        }

        private IEnumerable<SelectListItem> GetCategories()
        {
            var categories = _serverCategoryService.GetAllCategories()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                });

            return new SelectList(categories, "Value", "Text");
        } 

    }
}
