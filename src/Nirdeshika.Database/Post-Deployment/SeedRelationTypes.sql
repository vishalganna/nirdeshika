SET IDENTITY_INSERT [dbo].[RelationTypes] ON;

MERGE INTO [dbo].[RelationTypes] AS Target
USING (VALUES
    (1, 'SO', 'Son of'),
    (2, 'DO', 'Daughter of'),
    (3, 'WO', 'Wife of')
) AS Source ([Id], [Type], [Description])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Type], [Description])
    VALUES (Source.[Id], Source.[Type], Source.[Description]);

SET IDENTITY_INSERT [dbo].[RelationTypes] OFF;