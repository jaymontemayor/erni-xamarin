using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserApp.Models;

namespace UserApp.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
    }
}
