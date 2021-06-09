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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin Get(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.Get(filter);
        }

        public Admin GetByUserNameAndPassword(string userName, string password)
        {
           return _adminDal.Get(x => x.UserName == userName & x.Password == password);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
