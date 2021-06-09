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

            Bind<IAboutService>().To<AboutManager>();
            Bind<IAboutDal>().To<EfAboutDal>();

            Bind<IAuthorService>().To<AuthorManager>();
            Bind<IAuthorDal>().To<EfAuthorDal>();

            Bind<IContactService>().To<ContactManager>();
            Bind<IContactDal>().To<EfContactDal>();

            Bind<IContentService>().To<ContentManager>();
            Bind<IContentDal>().To<EfContentDal>();

            Bind<ITitleService>().To<TitleManager>();
            Bind<ITitleDal>().To<EfTitleDal>();

            Bind<IMessageService>().To<MessageManager>();
            Bind<IMessageDal>().To<EfMessageDal>();

            Bind<IImageService>().To<ImageManager>();
            Bind<IImageDal>().To<EfImageDal>();

            Bind<IAdminService>().To<AdminManager>();
            Bind<IAdminDal>().To<EfAdminDal>();



        }
    }
}
