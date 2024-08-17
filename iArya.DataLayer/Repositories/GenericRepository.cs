using iArya.DataLayer.Context;
using iArya.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iArya.DataLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private iAryaDbContext _context;
        public GenericRepository(iAryaDbContext context) 
        {
             _context=context;
        }
        public void Add(T entity)
        {
             _context.Add(entity);
        }

        public void Delete(T entity)
        {
             _context.Remove(entity);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
             return _context.Set<T>().ToList();
        }

        public void Save()
        {
             _context.SaveChanges();
        }

        public void Update(T entity)
        {
             _context.Update(entity);
        }
    }
}
