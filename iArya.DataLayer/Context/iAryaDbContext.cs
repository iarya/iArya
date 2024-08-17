using iArya.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.DataLayer.Context
{
    public class iAryaDbContext:DbContext
    {

        public iAryaDbContext(DbContextOptions<iAryaDbContext> options) : base(options)
        {
            
        }
        #region User Entities
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion


    }
}
