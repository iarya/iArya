using iArya.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.DataLayer.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int RoleId);

        void AddRole(Role role);
        void EditRole(Role role);
        void DeleteRole(Role role);
        void Save();
    }
}
