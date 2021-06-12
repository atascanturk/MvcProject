using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MySkillManager : IMySkillService
    {
        IMySkillDal _mySkillDal;

        public MySkillManager(IMySkillDal mySkillDal)
        {
            _mySkillDal = mySkillDal;
        }

        public List<MySkill> getAll()
        {
            return _mySkillDal.GetAll();
        }
    }
}
