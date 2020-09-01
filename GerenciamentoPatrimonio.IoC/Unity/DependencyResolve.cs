using GerenciamentoPatrimonio.Dominio.Interface.Repository;
using GerenciamentoPatrimonio.Dominio.Interface.Service;
using GerenciamentoPatrimonio.Dominio.Service;
using GerenciamentoPatrimonio.Infra;
using GerenciamentoPatrimonio.Infra.Repositories;
using GerenciamentoPatrimonio.Infra.Repositories.Base;
using GerenciamentoPatrimonio.Infra.Transactions;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace GerenciamentoPatrimonio.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, Context>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnityOfWork, UnityOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IServicePatrimonio, ServicePatrimonio>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceUsuario, ServiceUsuario>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceMarca, ServiceMarca>(new HierarchicalLifetimeManager());
            


            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
            container.RegisterType<IRepositoryPatrimonio, RepositoryPatrimonio>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryMarca, RepositoryMarca>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryUsuario, RepositoryUsuario>(new HierarchicalLifetimeManager());
            



        }

   
    }
}