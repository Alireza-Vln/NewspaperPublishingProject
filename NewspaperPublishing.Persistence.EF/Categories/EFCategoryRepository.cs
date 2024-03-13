using Microsoft.EntityFrameworkCore;
using NewspaperPublishing.Entities.Categories;
using NewspaperPublishing.Persistence.EF;
using NewspaperPublishing.Services.Categories.Contracts.Dtos;

namespace NewspaperPublishing.Spec.Tests.Categories
{
    public class EFCategoryRepository : CategoryRepository
    {
        readonly DbSet<Category> _categories;
       
        public EFCategoryRepository(EFDataContext context)
        {
            _categories = context.Categories;
        }

        public void Add(Category category)
        {

           _categories.Add(category);
        }

        public void Delete(Category? category)
        {
            _categories.Remove(category);
        }

        public Category? FindCategoryById(int id)
        {
            return _categories.FirstOrDefault(_ => _.Id == id);
        }

        public Category? FindCategoryTitle(string Title)
        {
            return _categories.FirstOrDefault(_ => _.Title == Title);
        }

        public List<GetCategoryDto> GetAll()
        {
            var category = _categories
                 .Select(_ => new GetCategoryDto
                 {
                     Id = _.Id,
                     Title = _.Title,
                     Weight = _.Weight,
                     View = _.View,
                     NewspaperId = _.NewspaperId
                 }).ToList();
            
            return category;  
            
            
        }
    }
}
