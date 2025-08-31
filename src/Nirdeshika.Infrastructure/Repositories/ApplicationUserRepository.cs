using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
public class ApplicationUserRepository(
    IConnectionFactory connectionFactory,
    ILogger<AddressRepository> logger
    ) : IApplicationUserRepository
{
    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM ApplicationUsers WHERE Email = @Email";
            return await connection.QueryFirstOrDefaultAsync<ApplicationUser>(sql, new { Email = email });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
        }

        return default;
    }

    public async Task AddUserAsync(string email)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            const string sql = "INSERT INTO ApplicationUsers (Email, IsApproved) VALUES (@Email, 0)";
            await connection.ExecuteAsync(sql, new { Email = email });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
        }
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            const string sql = "SELECT * FROM ApplicationUsers";
            return await connection.QueryAsync<ApplicationUser>(sql);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
        }

        return [];
    }

    public async Task ToggleApprovalAsync(int id)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            const string sql = "UPDATE ApplicationUsers SET IsApproved = ~IsApproved WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
        }
    }

    public async Task ToggleAdminStatusAsync(int id)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            const string sql = "UPDATE ApplicationUsers SET IsAdmin = ~IsAdmin WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while connecting to the database: {Message}", ex.Message);
        }
    }
}
