using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace ModernStore.Infra.Contexts
{
    class ConfigurationDbModernStore : DbConfiguration
    {
        public ConfigurationDbModernStore()
        {
            SetDatabaseInitializer(new DropCreateDatabaseAlways<ModernStoreDataContext>());
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
