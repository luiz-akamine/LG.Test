using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Services;

namespace LG.Test.Application
{
    public class UserApplication : ApplicationBase<User>, IUserApplication
    {
        private readonly IUserService _UserService;
        private readonly IUnitOfWorkService _uow;

        public UserApplication(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _UserService = uow.Service<IUserService>();
        }              
    }
}
