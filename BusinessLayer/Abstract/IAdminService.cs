using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetByUserNameAndPassword(string userName, string password);
        Admin Get(Expression<Func<Admin, bool>> filter = null);
        void Add(Admin admin);
        void Delete(Admin admin);
        void Update(Admin admin);
    }
}
