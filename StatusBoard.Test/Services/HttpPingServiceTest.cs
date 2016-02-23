using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StatusBoard.Core.IServices;

namespace StatusBoard.Test.Services
{
    class HttpPingServiceTest
    {
        private Mock<IUnitOfWork> uow;

        public HttpPingServiceTest()
        {
            uow = new Mock<IUnitOfWork>();


        }
    }
}
