using Nirdeshika.Application.DTOs;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Nirdeshika.Web.Export;

public class FamilyComponent(FamilyDto family, IEnumerable<FamilyMemberDto> familyMembers) : IComponent
{
    public void Compose(IContainer container)
    {
        container.Border(3, Colors.Grey.Lighten3).Padding(10).Column(column =>
        {
            column.Item()
                .PaddingBottom(2)
                .Text($"{family.Head} {family.Surname?.Name}")
                .FontColor(Colors.Blue.Accent3)
                .FontSize(16)
                .Bold();

            column.Item().Row(row =>
            {
                row.RelativeItem()
                    .Component(new FamilyMembersComponent("Males", Colors.Blue.Accent2, familyMembers.Where(x => x.Gender == 'M').ToList()));
            });

            column.Item().Row(row =>
            {
                row.RelativeItem()
                    .Component(new FamilyMembersComponent("Females", Colors.Pink.Accent2, familyMembers.Where(x => x.Gender == 'F').ToList()));
            });
        });
    }
}
