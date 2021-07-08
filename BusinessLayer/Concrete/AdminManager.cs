using BusinessLayer.Abstract;
using Core.Utilities.Security.Hashing;
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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(AdminAddDto adminAddDto,string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);        
          
            var admin = new Admin
            {
                Email = adminAddDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                UserName = adminAddDto.UserName,
                Role=adminAddDto.Role

            };

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

        public List<Admin> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetAll();
        }

        public bool GetByUserEmailAndPassword(AdminForLoginDto adminForLoginDto)
        {

            var userToCheck = _adminDal.Get(x => x.Email == adminForLoginDto.Email);

            if (userToCheck == null)
            {
                return false;
            }

            if (!HashingHelper.VerifyPasswordHash(adminForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return false;
            }

            return true;



        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
