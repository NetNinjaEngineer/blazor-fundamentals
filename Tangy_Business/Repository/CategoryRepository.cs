using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository;

public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public CategoryDto Create(CategoryDto entity)
    {
        var category = new Category
        {
            Id = entity.Id,
            Name = entity.Name,
            CreatedAt = DateTime.Now
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public CategoryDto Update(CategoryDto entity)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
    {
        var obj = context.Categories.FirstOrDefault(x => x.Id == id);
        if (obj == null) return 0;
        context.Categories.Remove(obj);
        return context.SaveChanges();

    }

    public CategoryDto Get(int id)
    {
        var category = context.Categories.FirstOrDefault(x => x.Id == id);
        if (category is not null)
            return new CategoryDto { Id = category.Id, Name = category.Name };
        return new CategoryDto();
    }

    public IEnumerable<CategoryDto> GetAll()
    {
        var categories = context.Categories.ToList();
        return categories.Select(category => new CategoryDto { Id = category.Id, Name = category.Name }).ToList();
    }
}