using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TitleManager : ITitleService
    {
        ITitleDal _titleDal;

        public TitleManager(ITitleDal titleDal)
        {
            _titleDal = titleDal;
        }

        public int Count(Expression<Func<Title, bool>> filter = null)
        {
            return _titleDal.Count(filter);
        }

        public List<Title> GetAll(Expression<Func<Title, bool>> filter = null)
        {
            return _titleDal.GetAll(filter);
        }

        public List<CategoryDetailsDto> GetCategoryDetails(Expression<Func<Category, bool>> filter = null)
        {
            return _titleDal.getCategoryDetails(filter);
        }
    }
}
