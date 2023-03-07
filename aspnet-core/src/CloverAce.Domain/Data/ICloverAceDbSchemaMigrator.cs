using System.Threading.Tasks;

namespace CloverAce.Data;

public interface ICloverAceDbSchemaMigrator
{
    Task MigrateAsync();
}
