using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using Nirdeshika.Application.DTOs;
using Nirdeshika.Application.Repositories;
using Nirdeshika.Domain.Entities;
using Nirdeshika.Infrastructure.Data;

namespace Nirdeshika.Infrastructure.Repositories;
public class FamilyMemberRepository(
    IConnectionFactory connectionFactory,
    ILogger<FamilyMemberRepository> logger
    ) : IFamilyMemberRepository
{
    public async Task<IEnumerable<FamilyMember>> GetByFamilyId(int familyId)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();

            return await connection.QueryAsync<FamilyMember>("SELECT * FROM FamilyMembers WHERE FamilyId = @familyId", new { familyId });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while adding family: {Message}", ex.Message);
        }

        return Enumerable.Empty<FamilyMember>();
    }

    public async Task<int?> AddFamilyMemberAsync(CreateFamilyMemberDto familyMemberDto)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@name", familyMemberDto.Name);
            parameters.Add("@dateOfBirth", familyMemberDto.DateOfBirth);
            parameters.Add("@gender", familyMemberDto.Gender);
            parameters.Add("@mobileNumber", familyMemberDto.MobileNumber);
            parameters.Add("@relationTypeId", familyMemberDto.RelationTypeId);
            parameters.Add("@relative", familyMemberDto.Relative);
            parameters.Add("@isFamilyHead", familyMemberDto.IsFamilyHead);
            parameters.Add("@familyId", familyMemberDto.FamilyId);
            parameters.Add("@newMemberId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await connection.ExecuteAsync("sp_FamilyMember_Add", parameters, commandType: CommandType.StoredProcedure);

            return parameters.Get<int>("@newMemberId");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error while adding family: {Message}", ex.Message);
        }

        return default;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            using var connection = connectionFactory.CreateConnection();

            await connection.ExecuteAsync("DELETE FROM FamilyMembers WHERE Id = @id", new { id });

            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while deleting family member: {Message}", e.Message);
        }

        return false;
    }
}
