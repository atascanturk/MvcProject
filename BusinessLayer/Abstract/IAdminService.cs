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
    public interface IAdminService
    {
        bool GetByUserEmailAndPassword(AdminForLoginDto adminForLoginDto);
        Admin Get(Expression<Func<Admin, bool>> filter = null);
        List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null);
        void Add(AdminAddDto adminAddDto, string password);
        void Delete(Admin admin);
        void Update(Admin admin);
    }
}
