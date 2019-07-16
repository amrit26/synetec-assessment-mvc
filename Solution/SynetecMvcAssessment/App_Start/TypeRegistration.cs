using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using SynetecMvcAssessment.Application.DAL.Concrete;
using SynetecMvcAssessment.Application.Services.Concrete;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using SynetecMvcAssessment.Application.ModelBuilders.Concrete;

namespace InterviewTestTemplatev2.App_Start
{
    public static class TypeRegistration
    {
        public static void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(new HttpConfiguration());

            builder.RegisterType<EmployeeService>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<EmployeeRepository>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<BonusPoolModelBuilder>().AsImplementedInterfaces().InstancePerDependency();

            var container = builder.Build();

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}