using MyStore.Data;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetAllCategories();
        Categories GetCategoryById(int id);
        Categories AddCategory(Categories categoryToBeAdded);
        Categories UpdateCategory(Categories categoryToUpdate);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository categoryRepository;

        public CategoryService(ICategoriesRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Categories AddCategory(Categories categoryToBeAdded)
        {
            if (IsUniqueName(categoryToBeAdded.Categoryname))
            {
                return categoryRepository.AddCategory(categoryToBeAdded);
            }
            else
                return null;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }

        public Categories GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public Categories UpdateCategory(Categories categoryToUpdate)
        {
            return categoryRepository.Update(categoryToUpdate);
        }

        private bool IsUniqueName(string categoryName)
        {
            if (categoryRepository.IsUniqueName(categoryName) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
