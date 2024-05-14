
namespace Jugendretter_API.Contracts
{
    public interface IRepositoryWrapper
    {

        IUserRepository User { get; }

        void Save();
    }
}
