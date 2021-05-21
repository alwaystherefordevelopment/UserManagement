using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementDAL;
using UserManagementRepository.Models;

namespace UserManagementRepository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<UserModel> GetUserWithCountryCity();
    }
}
