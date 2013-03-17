using DynamicLoopGoogleMaps.Domain.IoC.Registries;
using StructureMap;

namespace DynamicLoopGoogleMaps.IoC
{
    public static class ContainerBootStrap
    {
        public static void Bootstrap()
        {
            ObjectFactory.Configure(c => c.Scan(x =>
            {
                x.AssemblyContainingType<DomainRegistry>();
                x.LookForRegistries();
            }));
        }
    }
}