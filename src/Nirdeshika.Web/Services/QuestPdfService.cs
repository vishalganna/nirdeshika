using Nirdeshika.Application.Services;
using Nirdeshika.Domain.Extensions;
using Nirdeshika.Web.Export;
using QuestPDF.Fluent;

namespace Nirdeshika.Web.Services;

public class QuestPdfService(
    IFamilyService familyService,
    IFamilyMemberService familyMemberService)
{
    public async Task<byte[]> CreateFamilyDataPdfAsync(
        Tuple<bool, int, int> maleConfig,
        Tuple<bool, int, int> femaleConfig)
    {
        var families = await familyService.GetAllFamiliesAsync();

        var familyExportModels = new List<FamilyExportModel>();

        foreach (var family in families)
        {
            var members = await familyMemberService.GetByFamilyIdAsync(family.Id);

            var membersToInclude = 
                                        members.Where(m =>
                                        {
                                            var age = m.DateOfBirth.CalculateAge();
                                            return (maleConfig.Item1 && m.Gender == 'M' && age >= maleConfig.Item2 && age <= maleConfig.Item3) ||
                                                   (femaleConfig.Item1 && m.Gender == 'F' && age >= femaleConfig.Item2 && age <= femaleConfig.Item3);
                                        });

            var familyExportModel = new FamilyExportModel(family, membersToInclude);
            familyExportModels.Add(familyExportModel);
        }

        var document = new FamilyDataDocument(familyExportModels);
        using var stream = new MemoryStream();
        document.GeneratePdf(stream);
        return stream.ToArray();
    }
}
