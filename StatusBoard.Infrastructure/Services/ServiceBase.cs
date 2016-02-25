using System;
using StatusBoard.Core.IExternalServices;

namespace StatusBoard.Infrastructure.Services
{
    public class ServiceBase<T> : IDisposable where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        //make protected to make it less likely someone directly uses this base type
        protected ServiceBase(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
