using System.Collections.Generic;
using WebApplication1.Domain;

namespace WebApplication1.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        Category GetCategoryByID(int Id);
        Category Insert(Category category);

        void Delete(Category category);

        Category Update(Category category);

    }
}
