using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        Category GetById(int id);
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        int Count(Expression<Func<Category, bool>> filter = null);
    }
}
