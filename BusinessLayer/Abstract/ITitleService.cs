using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITitleService
    {
        int Count(Expression<Func<Title, bool>> filter = null);
        List<Title> GetAll(Expression<Func<Title, bool>> filter = null);
        List<Title> GetAllByNonDeleted(int? authorId, Expression<Func<Title, bool>> filter = null);
        List<CategoryDetailsDto> GetCategoryDetails(Expression<Func<Category, bool>> filter = null);
        Title GetById(int id);
        void Add(Title title);
        void Delete(Title title);
        void Update(Title title);
        
    }
}
