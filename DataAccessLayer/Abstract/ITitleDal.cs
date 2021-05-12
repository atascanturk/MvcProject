using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ITitleDal :IEntityRepository<Title>
    {
        List<CategoryDetailsDto> getCategoryDetails(Expression<Func<Category, bool>> filter = null);
    }
}
