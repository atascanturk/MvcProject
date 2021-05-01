using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanturkFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule :NinjectModule, INinjectModule
    {
        public override void Load()
        {
            Bind<CategoryManager>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<DbContext>().To<Context>();

        }
    }
}
