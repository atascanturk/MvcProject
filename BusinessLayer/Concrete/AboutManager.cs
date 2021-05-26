using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            _aboutDal.Add(about);
        }

        public int Count(Expression<Func<About, bool>> filter = null)
        {
           return _aboutDal.Count(filter);
        }

        public void Delete(About about)
        {
            _aboutDal.Delete(about);
        }

        public List<About> GetAll(Expression<Func<About, bool>> filter = null)
        {
            return _aboutDal.GetAll(filter);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.Id == id);
        }

        public void Update(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
