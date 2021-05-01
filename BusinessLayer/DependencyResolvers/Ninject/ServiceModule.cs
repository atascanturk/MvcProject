using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Ninject.Modules;

namespace CanturkFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ServiceModule :NinjectModule 
    {
        public override void Load()
        {
            //Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<EfCategoryDal>();

        }
    }
}
