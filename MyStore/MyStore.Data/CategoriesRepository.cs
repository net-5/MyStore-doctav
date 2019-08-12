using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyStore.Data
{
    public interface ICategoriesRepository
    {
        List<Categories> GetAllCategories();
        Categories GetCategoryById(int id);
        Categories Update(Categories categoryToUpdate);
        Categories AddCategory(Categories categoryToBeAdded);
        bool IsUniqueName(string categoryName);
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly StoreContext storeContext;

        public CategoriesRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Categories AddCategory(Categories categoryToBeAdded)
        {
            var addedCategory = storeContext.Add(categoryToBeAdded);
            storeContext.SaveChanges();
            return addedCategory.Entity;
        }

        public List<Categories> GetAllCategories()
        {
            return storeContext.Categories.ToList();
        }

        public Categories GetCategoryById(int id)
        {
            return storeContext.Categories.Find(id);
        }

        public Categories Update(Categories categoryToUpdate)
        {
            var updatedCategory = storeContext.Update(categoryToUpdate);
            storeContext.SaveChanges();
            return updatedCategory.Entity;
        }

        public bool IsUniqueName(string categoryName)
        {
            int nr = storeContext.Categories.Count(x => x.Categoryname == categoryName);
            if (nr==0)
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
