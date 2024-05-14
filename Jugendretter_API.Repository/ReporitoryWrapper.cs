using Jugendretter_API.Contracts;
using Jugendretter_API.Database;
using Jugendretter_API.Entities;


namespace Jugendretter_API.Repository
{
    public class ReporitoryWrapper : IRepositoryWrapper
    {
        private readonly JugendretterDBContext _context;

        private IUserRepository _user; 

        public IUserRepository User
        {
            get
            {
                if(_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }



        public ReporitoryWrapper(JugendretterDBContext context)
        {
            _context = context;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
