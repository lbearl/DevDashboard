using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.IServices;
using StatusBoard.Core.Models;

namespace StatusBoard.Infrastructure.Services
{
    public class ServerCategoryService : ServiceBase<ServerCategory>, IServerCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServerCategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ServerCategory> GetAllCategories()
        {
            return _unitOfWork.ServerCategoryRepository.GetAll().ToList();
        }

        public List<ServerCategory> GetAllCategoriesForServer(int serverId)
        {
            return _unitOfWork.ServerCategoryRepository.GetAllCategoriesForServer(serverId).ToList();
        }

        public ServerCategory FindById(int id)
        {
            return _unitOfWork.ServerCategoryRepository.FindById(id);
        }

        public void Add(ServerCategory category)
        {
            _unitOfWork.ServerCategoryRepository.Add(category);
            _unitOfWork.SaveChanges();
        }

        public void Update(ServerCategory category)
        {
            _unitOfWork.ServerCategoryRepository.Update(category);
            _unitOfWork.SaveChanges();
        }

        public void Remove(ServerCategory category)
        {
            _unitOfWork.ServerCategoryRepository.Remove(category);
            _unitOfWork.SaveChanges();
        }
    }
}
