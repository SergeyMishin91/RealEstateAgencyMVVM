using Autofac;
using RealEstateAgency.DataAccess;
using RealEstateAgency.UI.Data;
using RealEstateAgency.UI.ViewModel;

namespace RealEstateAgency.UI.Sturtup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EstateOrganizeDbContext>().AsSelf();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<EstateDetailViewModel>().As<IEstateDetailViewModel>();


            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<EstateDataService>().As<IEstateDataService>();

            return builder.Build();
        }
    }
}
