using cqrs_clean.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<bool> ExistsAsync(string username)
            => await _context.Users.AnyAsync(u => u.Username == username);

        public async Task DeleteAsync(int id)
        {
            var ex = await _context.Users.FindAsync($"{id}");
            _context.Users.Remove(ex);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

     
    }
}
