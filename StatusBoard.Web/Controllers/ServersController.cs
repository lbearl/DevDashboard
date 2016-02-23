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
        private IUnitOfWork _unitOfWork;

        public ServersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Servers
        public ActionResult Index()
        {
            var vm = _unitOfWork.ServerRepository.GetAll().Select(x => new ViewModels.Server() {ServerId = x.Id, HostName = x.Hostname, DisplayName = x.DisplayName, IsActive = x.IsActive});
            return View(vm);
        }

        // GET: Servers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var server = _unitOfWork.ServerRepository.FindById(id);
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
                _unitOfWork.ServerRepository.Add(server);
                _unitOfWork.SaveChanges();
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
            var server = _unitOfWork.ServerRepository.FindById(id);
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
                _unitOfWork.ServerRepository.Update(server);
                _unitOfWork.SaveChanges();
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
            var server = _unitOfWork.ServerRepository.FindById(id);
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
            var server = _unitOfWork.ServerRepository.FindById(id);
            _unitOfWork.ServerRepository.Remove(server);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
