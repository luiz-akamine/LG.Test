using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;

namespace LG.Test.API.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(IDBApplicationBase<Category> baseApplication, ICategoryApplication categoryApplication) : base(baseApplication)
        {
            _categoryApplication = categoryApplication;
        }        
    }
}
