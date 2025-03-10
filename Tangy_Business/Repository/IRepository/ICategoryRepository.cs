using Tangy_Models;

namespace Tangy_Business.Repository.IRepository;

public interface ICategoryRepository
{
    CategoryDto Create(CategoryDto entity);
    CategoryDto Update(CategoryDto entity);
    int Delete(int id);
    CategoryDto Get(int id);
    IEnumerable<CategoryDto> GetAll();
}