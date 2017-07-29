using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Infra;

namespace LG.Test.Infra.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
