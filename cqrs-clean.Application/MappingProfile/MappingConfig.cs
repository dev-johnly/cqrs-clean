using cqrs_clean.Application.Helper;
using cqrs_clean.Application.Users.Commands;
using cqrs_clean.Application.Users.Commands.UpdateUser;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs_clean.Application.MappingProfile;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateUserCommand, User>()
            .Map(dest => dest.PasswordHash, src => BCryptHelper.HashPassword(src.Password));

        config.NewConfig<UpdateUserCommand, User>()
         .IgnoreNullValues(true)
         .Ignore(dest => dest.Id)
         .Ignore(dest => dest.PasswordHash) // Prevent password overwrite unless explicitly handled
         .Map(dest => dest.UpdatedAt, src => DateTime.UtcNow); // Always update timestamp
    }
}
