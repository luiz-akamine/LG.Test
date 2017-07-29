using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Test.Services
{
    public class ServiceBase : IServiceBase
    {
        private IUnitOfWorkService _uow;
        public ServiceBase(IUnitOfWorkService uow)
        {
            _uow = uow;
        }
    }
}
