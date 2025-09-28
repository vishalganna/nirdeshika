using Nirdeshika.Application.DTOs;
using Nirdeshika.Domain.Extensions;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Nirdeshika.Web.Export;

public class FamilyMembersComponent(string title, Color nameColor, List<FamilyMemberDto> familyMembers) : IComponent
{
    public void Compose(IContainer container)
    {
        if (!familyMembers.Any())
        {
            return;
        }

        container.PaddingVertical(10).Column(column =>
        {
            column
                .Item()
                .PaddingBottom(5)
                .Text(title)
                .SemiBold();

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.ConstantColumn(25);
                    columns.ConstantColumn(150);
                });

                table.Header(header =>
                {
                    header.Cell().Element(CellHeaderStyle).Text("#");
                    header.Cell().Element(CellHeaderStyle).Text("Name");
                    header.Cell().Element(CellHeaderStyle).AlignRight().Text("Age");
                    header.Cell().Element(CellHeaderStyle).AlignRight().Text("Mobile");

                    static IContainer CellHeaderStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold())
                            .PaddingVertical(5)
                            .BorderBottom(1)
                            .BorderColor(Colors.Black);
                    }
                });

                foreach (var member in familyMembers)
                {
                    table.Cell().Element(CellBodyStyle)
                        .Text((familyMembers.IndexOf(member) + 1).ToString());

                    table.Cell()
                        .Element(CellBodyStyle)
                        .Text(member.Name)
                        .FontColor(nameColor);

                    table.Cell().Element(CellBodyStyle)
                        .AlignRight()
                        .Text(member.DateOfBirth.CalculateAge().ToString());

                    table.Cell().Element(CellBodyStyle)
                        .AlignRight()
                        .Text(member.MobileNumber);

                    static IContainer CellBodyStyle(IContainer container)
                    {
                        return container.BorderBottom(1)
                            .BorderColor(Colors.Grey.Lighten2)
                            .PaddingVertical(5);
                    }
                }
            });
        });
    }
}
