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

        public void Add(Title title)
        {
            _titleDal.Add(title);
        }

        public int Count(Expression<Func<Title, bool>> filter = null)
        {
            return _titleDal.Count(filter);
        }

        public void Delete(Title title)
        {
            _titleDal.Delete(title);
        }

        public List<Title> GetAll(Expression<Func<Title, bool>> filter = null)
        {
            return _titleDal.GetAll(filter,t=>t.Category,t => t.Author);
        }

        public Title GetById(int id)
        {
           return _titleDal.Get(t => t.Id == id);
        }

        public List<CategoryDetailsDto> GetCategoryDetails(Expression<Func<Category, bool>> filter = null)
        {
            return _titleDal.getCategoryDetails(filter);
        }

        public void Update(Title title)
        {
            _titleDal.Update(title);
        }
    }
}
