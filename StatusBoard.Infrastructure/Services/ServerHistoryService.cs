using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.Services
{
    public class ServerHistoryService : ServiceBase<ServiceHistory>, IServerHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServerHistoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ServiceHistory FindById(int id)
        {
            return _unitOfWork.ServiceHistoryRepository.FindById(id);
        }

        public void Add(ServiceHistory entity)
        {
            _unitOfWork.ServiceHistoryRepository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public Task<int> AddAsync(ServiceHistory entity)
        {
            _unitOfWork.ServiceHistoryRepository.Add(entity);
            return _unitOfWork.SaveChangesAsync();
        }

        public void Update(ServiceHistory entity)
        {
            _unitOfWork.ServiceHistoryRepository.Update(entity);
            _unitOfWork.SaveChanges();
        }

        public void Remove(ServiceHistory entity)
        {
            _unitOfWork.ServiceHistoryRepository.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public List<ServiceHistory> GetAllHistoriesForHostById(int id)
        {
            return _unitOfWork.ServiceHistoryRepository.GetAllForHost(id).ToList();
        }

    }
}
