using System.Linq;
using System.Net;
using System.Web.Mvc;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Web.Controllers
{
    [Authorize]
    public class ServersController : Controller
    {
        private IServerService _serverService;

        public ServersController(IServerService serverService)
        {
            _serverService = serverService;
        }

        // GET: Servers
        public ActionResult Index()
        {
            var vm = _serverService.GetAll().Select(x => new ViewModels.Server() {ServerId = x.Id, HostName = x.Hostname, DisplayName = x.DisplayName, IsActive = x.IsActive});
            return View(vm);
        }

        // GET: Servers/Details/5
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
            var vm = new ViewModels.Server() { ServerId = server.Id, HostName = server.Hostname, DisplayName = server.DisplayName, IsActive = server.IsActive };

            return View(vm);
        }

        // GET: Servers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServerId,DisplayName,HostName,IsActive")] ViewModels.Server vm)
        {
            if (ModelState.IsValid)
            {
                var server = new Server() {IsActive = vm.IsActive, DisplayName = vm.DisplayName, Hostname = vm.HostName, Id = vm.ServerId};
                _serverService.Add(server);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: Servers/Edit/5
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
            var vm = new ViewModels.Server() { ServerId = server.Id, HostName = server.Hostname, DisplayName = server.DisplayName, IsActive = server.IsActive };
            return View(vm);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServerId,DisplayName,HostName,IsActive")] ViewModels.Server vm)
        {
            if (ModelState.IsValid)
            {
                var server = new Server() { IsActive = vm.IsActive, DisplayName = vm.DisplayName, Hostname = vm.HostName, Id = vm.ServerId };
                _serverService.Update(server);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Servers/Delete/5
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
            var vm = new ViewModels.Server() { ServerId = server.Id, HostName = server.Hostname, DisplayName = server.DisplayName, IsActive = server.IsActive };
            return View(vm);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var server = _serverService.FindById(id);
            _serverService.Remove(server);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serverService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
