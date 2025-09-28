using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Nirdeshika.Web.Export;

public class FamilyDataDocument(IEnumerable<FamilyExportModel> families) : IDocument
{
    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));
                page.Content().Element(ComposeContent);
                page.Footer().AlignCenter().Text(text => text.CurrentPageNumber());
            });
    }

    void ComposeContent(IContainer container)
    {
        container.Column(column =>
        {
            foreach (var family in families)
            {
                if (!family.FamilyMembers.Any())
                {
                    continue;
                }

                column.Spacing(1, Unit.Centimetre);
                column.Item().Row(row =>
                {
                    row.RelativeItem().Component((new FamilyComponent(family.Family, family.FamilyMembers)));
                });
            }
        });
    }
}
