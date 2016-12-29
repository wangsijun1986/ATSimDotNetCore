using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ATSimWeb.Config
{
    public class InjectionService
    {
        public InjectionService(IServiceCollection service)
        {
            AddService(service);
            AddData(service);
            AddCommon(service);
        }

        public void AddService(IServiceCollection service)
        {
            AssemblyName assemblyName = new AssemblyName("ATSimService");
            InjectionToServiceCollerction(service, assemblyName);
        }

        public void AddData(IServiceCollection service)
        {
            AssemblyName assemblyName = new AssemblyName("ATSimData");
            InjectionToServiceCollerction(service, assemblyName);
        }

        public void AddCommon(IServiceCollection service)
        {
            AssemblyName assemblyName = new AssemblyName("ATSimCommon");
            InjectionToServiceCollerction(service, assemblyName);
        }

        private void InjectionToServiceCollerction(IServiceCollection service, AssemblyName assemblyName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> interfaceType = types.Where(p => p.GetTypeInfo().IsInterface);
            foreach(Type item in interfaceType)
            {
                Type implementClass = types.Single(p => p.GetTypeInfo().ImplementedInterfaces.Contains(item));
                service.Add(new ServiceDescriptor(serviceType: item, implementationType: implementClass, lifetime: ServiceLifetime.Transient));
            }
            //foreach(Type item in types)
            //{
            //    TypeInfo typeInfo = item.GetTypeInfo();
            //    if (typeInfo.IsClass) {
            //        service.AddScoped(item);
            //    }
            //}
        }
    }
}
