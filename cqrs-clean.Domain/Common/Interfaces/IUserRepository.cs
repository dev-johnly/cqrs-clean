using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Domain.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        IQueryable<User> GetAll();
        Task<bool> ExistsAsync(string username);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);

    }
}
