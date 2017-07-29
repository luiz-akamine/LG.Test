using LG.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Test.Domain.Interfaces.Applications
{
    public interface IUserApplication : IApplicationBase, IDBApplicationBase<User>
    {
    }
}
