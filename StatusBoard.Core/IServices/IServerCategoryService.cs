using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusBoard.Core.Models;

namespace StatusBoard.Core.IServices
{
    public interface IServerCategoryService : IService<ServerCategory, int>
    {
        List<ServerCategory> GetAllCategories();
    }
}
