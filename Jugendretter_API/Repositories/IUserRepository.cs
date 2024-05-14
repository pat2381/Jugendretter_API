using Jugendretter_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jugendretter_API.Repositories
{
    public interface IUserRepository
    {

        Task<List<User>> Get();

        Task<User> Get(int ID);

        Task<User> Create(User user);

        Task Update(User user);

        Task Delete(int ID);

    }
}
