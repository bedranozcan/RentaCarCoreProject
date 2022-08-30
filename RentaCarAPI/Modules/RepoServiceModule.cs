using Autofac;
using RentaCar.Core.Repositories;
using RentaCar.Core.Services;
using RentaCar.Core.UnitOfWorks;
using RentaCar.Repository;
using RentaCar.Repository.Repositories;
using RentaCar.Repository.UnitOfWorks;
using RentaCar.Service.Mapping;
using RentaCar.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace RentaCar.API.Modules
{
    public class RepoServiceModule:Module
    {
        //protected override void Load(ContainerBuilder builder)
        //{

        //    builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        //    builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

        //    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


        //   var apiAssembly=Assembly.GetExecutingAssembly();
        //   var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
        //   var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


        //   builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
        //   ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


        //   builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
        //   ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        //}
    }
}
