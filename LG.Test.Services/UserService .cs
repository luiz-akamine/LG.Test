using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Domain.Interfaces.Infra;

namespace LG.Test.Services
{
    public class UserService : DBServiceBase<User>, IUserService
    {
        private readonly IUnitOfWorkService _uow;

        public UserService(IUnitOfWorkService uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
