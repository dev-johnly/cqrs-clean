using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<bool> ExistsAsync(string username);
        Task DeleteAsync(int id);
        Task UpdateAsync(User user);
        Task<PaginatedList<UserDto>> GetPaginatedUsersAsync(
              int pageIndex = 1,
              int pageSize = 10,
              string? searchTerm = null,
              CancellationToken cancellationToken = default);

    }
}
