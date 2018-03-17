using System;
using System.Collections.Generic;
using GAtec.Northwind.Domain.Business;
using GAtec.Northwind.Domain.Model;
using GAtec.Northwind.Domain.Repository;

namespace GAtec.Northwind.Business
{
    public class CategoryService : ICategoryService
    {
        public IDictionary<string, string> Validation { get, set; }
        private ICategoryRepository CategoryRepository { get; set; }

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
            this.Validation = new Dictionary<string, string>();
        }

        public void Add(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("The name is empty.");
            }

            CategoryRepository.Add(category);
        }

        public void Update(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new System.NotImplementedException();
        }

        private bool IsValid(Category category)
        {
            if (string.IsNullOrEmpty)
            if (CategoryRepository.ExistsName(category.Name, category.Id))
            {
                Validation.Add("Name", "The name already exists.");
            }
            return true;
        }
    }
}