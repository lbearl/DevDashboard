using System.Collections.Generic;
using System.Linq;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.Services
{
    public class ServerService : ServiceBase<Server>, IServerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Server> GetAll()
        {
            return _unitOfWork.ServerRepository.GetAll().ToList();
        }

        public Server FindById(int id)
        {
            return _unitOfWork.ServerRepository.FindById(id);
        }

        public void Add(Server entity)
        {
            _unitOfWork.ServerRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public void Update(Server entity)
        {
            _unitOfWork.ServerRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Remove(Server entity)
        {
            _unitOfWork.ServerRepository.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public Server FindServerByHostname(string hostname)
        {
            return _unitOfWork.ServerRepository.FindByHostname(hostname);
        }
    }
}
