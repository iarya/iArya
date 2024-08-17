using iArya.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.DataLayer.Interfaces
{
    public  interface IUserRepository : IGenericRepository<User>
    {
        bool ExiestEmail(string email);
        User GetUserByUsername(string username);
    }
}
