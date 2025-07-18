using System.Data;

namespace Nirdeshika.Infrastructure.Data;
internal interface IConnectionFactory
{
    IDbConnection CreateConnection();
}
