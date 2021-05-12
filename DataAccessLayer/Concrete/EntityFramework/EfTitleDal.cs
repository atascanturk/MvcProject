using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfTitleDal : EfEntityRepositoryBase<Title, Context>, ITitleDal
    {
        public List<CategoryDetailsDto> getCategoryDetails(Expression<Func<Category, bool>> filter = null)
        {
            using (Context context = new Context() )
            {
                var result = from c in filter == null ? context.Categories : context.Categories.Where(filter)
                             join t in context.Titles
                             on c.Id equals t.CategoryId
                             select new CategoryDetailsDto { CategoryId = c.Id, CategoryName = c.Name, TitleId = t.Id };

                return result.ToList();
            }

          
        }
    }
}
