using LG.Test.Domain.Entities;
using System.Web.Http;
using LG.Test.Domain.Interfaces.Applications;

namespace LG.Test.API.Controllers
{    
    public class UserController : BaseController<User>
    {
        private readonly IUserApplication _userApplication;

        public UserController(IDBApplicationBase<User> baseApplication, IUserApplication userApplication) : base(baseApplication)
        {
            _userApplication = userApplication;
        }        
    }
}
