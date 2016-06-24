using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using ObrazovneUstanove.Domain;
using ObrazovneUstanove.Service;

namespace ObrazovneUstanove.UI
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
        }

        public static void ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();
            ConfigureContainer(containerBuilder);

            containerBuilder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
            containerBuilder.RegisterFilterProvider();
            IContainer container = containerBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ObrazovneUstanoveContext>().AsSelf().InstancePerRequest();
            containerBuilder.RegisterType<ServiceContainer>().As<IServiceContainer>().PropertiesAutowired().InstancePerRequest();
            containerBuilder.RegisterType<KorisnikService>().As<IKorisnikService>().PropertiesAutowired().InstancePerRequest();
            containerBuilder.RegisterType<NaseljenoMjestoService>().As<INaseljenoMjestoService>().PropertiesAutowired().InstancePerRequest();
            containerBuilder.RegisterType<OpstinaService>().As<IOpstinaService>().PropertiesAutowired().InstancePerRequest();
            containerBuilder.RegisterType<StrucnaSpremaService>().As<IStrucnaSpremaService>().PropertiesAutowired().InstancePerRequest();
        }
    }
}
