using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic , IABMLogic<Categories, int>
    {
        public List<Categories> GetAll()
        {
            return _northwindContext.Categories.ToList();
        }

        public Categories GetById(int id)
        {
            return _northwindContext.Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public int GetLastId()
        {
            return this.GetAll().Last().CategoryID;
        }
        public void Add(Categories category)
        {
            _northwindContext.Categories.Add(category);
            _northwindContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = GetById(id);
            if (categoryToDelete != null)
            {
                _northwindContext.Categories.Remove(categoryToDelete);
                _northwindContext.SaveChanges();
            } else
            {
                throw new NotFoundDBException();
            }
        }

        public void Update(Categories categoryToUpdate, string description)
        {
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Description = description;
                _northwindContext.SaveChanges();
            } else
            {
                throw new NotFoundDBException();
            }
        }

    }
}
