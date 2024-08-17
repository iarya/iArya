using iArya.DataLayer.Context;
using iArya.DataLayer.Interfaces;
using iArya.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly iAryaDbContext _context;

        public UserRepository(iAryaDbContext  context) : base(context)
        {
            _context = context;
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }
        public bool ExiestEmail(string email)
        {
           return _context.Users.Any(u => u.Email == email);
        }
    }
}
