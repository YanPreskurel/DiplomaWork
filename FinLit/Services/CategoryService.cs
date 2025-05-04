using FinLit.Data.Interfaces;

namespace FinLit.Services
{
    public class CategoryService
    {
        private readonly ICategories categoriesRepository;
        public CategoryService(ICategories categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        //some functions
    }
}
