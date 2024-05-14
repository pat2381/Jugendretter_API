using Jugendretter_API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jugendretter_API.Contracts
{
    public interface IUserRepository
    {

        Task<List<User>> Get();

        Task<User> Get(Guid ID);

        Task<User> Create(User user);

        Task Update(User user);

        Task Delete(Guid ID);

    }
}
