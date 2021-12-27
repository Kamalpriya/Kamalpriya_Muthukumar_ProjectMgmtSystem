using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.PersistenceLayer.Repository
{
    // (Sprint II) -- 1. Create Repository Interface - Generic Repository created for User, Project, Task
    public interface IGenericRepository<T>
    {
        public Task<T> CreateAsync(T item);
        public Task<T> UpdateAsync(int id, T item);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> DeleteAsync(int id);
    }
}
