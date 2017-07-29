using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Services;

namespace LG.Test.Application
{
    public class CategoryApplication : ApplicationBase<Category>, ICategoryApplication
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWorkService _uow;

        public CategoryApplication(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _categoryService = uow.Service<ICategoryService>();
        }                           
    }
}
