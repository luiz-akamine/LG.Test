using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Domain.Interfaces.Infra;

namespace LG.Test.Services
{
    public class CategoryService : DBServiceBase<Category>, ICategoryService
    {
        private readonly IUnitOfWorkService _uow;

        public CategoryService(IUnitOfWorkService uow) : base(uow)
        {
            _uow = uow;
        }
    }
}
