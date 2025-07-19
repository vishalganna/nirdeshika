using System.Data;

namespace Nirdeshika.Infrastructure.Data;
public interface IConnectionFactory
{
    IDbConnection CreateConnection();
}
