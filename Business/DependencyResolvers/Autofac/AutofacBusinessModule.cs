using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
          

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<SaleManager>().As<ISaleService>();
            builder.RegisterType<EfSaleDal>().As<ISaleDal>();







            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
