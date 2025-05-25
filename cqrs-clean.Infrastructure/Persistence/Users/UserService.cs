using cqrs_clean.Application.Common;
using cqrs_clean.Application.Users.DTOs;
using cqrs_clean.Application.Users.Interfaces;
using cqrs_clean.Domain.Common.Interfaces;
using Mapster;

namespace cqrs_clean.Infrastructure.Persistence.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Users.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string username)
        {
         return await _unitOfWork.Users.ExistsAsync(username);
        }

        public async Task<ApiResponse<UserDto>> GetByIdAsync(int id)
        {
           var user =  await _unitOfWork.Users.GetByIdAsync(id);
           if (user == null) 
                return ApiResponse<UserDto>.Failure("User not found");

            var userDto = user.Adapt<UserDto>();

            return ApiResponse<UserDto>.Success(userDto);
        }

        public async Task<PaginatedList<UserDto>> GetPaginatedUsersAsync(
             int pageIndex = 1,
             int pageSize = 10,
             string? searchTerm = null,
             CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Users.GetAll();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(u =>
                    u.Username.Contains(searchTerm) ||
                    u.Email.Contains(searchTerm) ||
                    u.FullName.Contains(searchTerm));
            }

            var projectedQuery = query.ProjectToType<UserDto>();

            return await PaginatedList<UserDto>.CreateAsync(projectedQuery, pageIndex, pageSize, cancellationToken);
        }

        public async Task UpdateAsync(User user)
        { 
            await _unitOfWork.Users.UpdateAsync(user);
        }
    }
}
