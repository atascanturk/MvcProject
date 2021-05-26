using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        int Count(Expression<Func<About, bool>> filter = null);
        List<About> GetAll(Expression<Func<About, bool>> filter = null);
        About GetById(int id);
        void Add(About about);
        void Delete(About about);
        void Update(About about);
    }
}
