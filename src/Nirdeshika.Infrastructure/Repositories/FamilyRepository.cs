using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
public class FamilyRepository(
    IConnectionFactory connectionFactory,
    ILogger<FamilyRepository> logger
    ) : IFamilyRepository
{
    public int? Create(CreateFamilyDto family)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            var sql = @"INSERT INTO Families (Head, SurnameId, NativeId, SectId, AddressId) VALUES(@head, @surnameId, @nativeId, @sectId, @addressId)
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
            object parameters = new
            {
                head = family.Head,
                surnameId = family.SurnameId,
                nativeId = family.NativeId,
                sectId = family.SectId,
                addressId = family.AddressId
            };
            return connection.ExecuteScalar<int>(sql, parameters);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while adding family: {Message}", ex.Message);
        }

        return null;
    }

    public async Task<IEnumerable<Family>> GetAllAsync()
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();

            await using var result = await connection.QueryMultipleAsync("sp_Family_GetAll", commandType: CommandType.StoredProcedure);

            var families = result.Read<Family>().ToList();
            var surnames = result.Read<Surname>().ToDictionary(s => s.Id);
            var natives = result.Read<Native>().ToDictionary(n => n.Id);
            var sects = result.Read<Sect>().ToDictionary(s => s.Id);
            var addresses = result.Read<Address>().ToDictionary(a => a.Id);

            // Wire up nested data
            foreach (var family in families)
            {
                if (surnames.TryGetValue(family.SurnameId, out var surname))
                    family.Surname = surname;

                if (natives.TryGetValue(family.NativeId, out var native))
                    family.Native = native;

                if(sects.TryGetValue(family.SectId, out var sect))
                    family.Sect = sect;

                if (addresses.TryGetValue(family.AddressId, out var address))
                    family.Address = address;
            }

            return families;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while retrieving families: {Message}", ex.Message);
        }

        return Enumerable.Empty<Family>();
    }

    public async Task<Family?> GetByIdAsync(int id)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();
            var result = await connection.QueryAsync<Family, Surname, Native, Sect, Address, Family>(
                "sp_Family_GetById",
                (family, surname, native, sect, address) =>
                {
                    family.Surname = surname;
                    family.Native = native;
                    family.Sect = sect;
                    family.Address = address;
                    return family;
                },
                new { FamilyId = id },
                splitOn: "Id,Id,Id,Id,Id",
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while retrieving family: {Message}", ex.Message);
        }

        return default;
    }
}
