using FoodDeliveryBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        

        public List<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c=>c.Name).ToList();
        }

        public Category GetCategory(int id)
        {
            //throw new NotImplementedException();
            return _context.Categories.SingleOrDefault(t => t.Id == id);
        }

        public void AddCategory(Category category)
        {
            //throw new NotImplementedException();
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        

        public void DeleteCategory(int id)
        {
            //throw new NotImplementedException();
            Category category = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
