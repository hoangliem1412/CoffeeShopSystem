using Autofac;
using Autofac.Integration.Mvc;
using CoffeeShop.Data.Infrastructure;
using CoffeeShop.Data.Repositories;
using CoffeeShop.Model.ModelEntity;
using CoffeeShop.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(CoffeeShop.Web.App_Start.Startup))]

namespace CoffeeShop.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //khoi tao khi goi inteface
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<CoffeeSystemDbContext>().AsSelf().InstancePerRequest();
            //khoi tao cac doi tuong co hau to repository va service
            //repository
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(r => r.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //service
            builder.RegisterAssemblyTypes(typeof(GroupTableService).Assembly)
                .Where(s => s.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //thay the co che mac dinh.

            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}