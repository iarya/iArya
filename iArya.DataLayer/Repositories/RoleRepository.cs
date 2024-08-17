using iArya.DataLayer.Context;
using iArya.DataLayer.Interfaces;
using iArya.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iArya.DataLayer.Repositories
{
    public class RoleRepository : IRoleRepository
    {

       private iAryaDbContext _context;

        public RoleRepository(iAryaDbContext context)
        {
            _context = context  ;
        }
        public void AddRole(Role role)
        {
           _context.Roles.Add(role);
        }

        public void DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
        }

        public void EditRole(Role role)
        {
            _context.Roles.Update(role);
        }

        public List<Role> GetAllRoles()
        {
          return  _context.Roles.Where(r=>!r.IsDelete).ToList();
        }

        public Role GetRoleById(int RoleId)
        {
           return _context.Roles.Find(RoleId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
