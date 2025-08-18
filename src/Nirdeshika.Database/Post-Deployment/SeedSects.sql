SET IDENTITY_INSERT [dbo].[Sects] ON;

MERGE INTO [dbo].[Sects] AS Target
USING (VALUES
    (1, 'Sthanakvasi (Amba Lal Ji)'),
    (2, 'Sthanakvasi (Ram Lal Ji)'),
    (3, 'Terapanthi')
) AS Source ([Id], [Name])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name])
    VALUES (Source.[Id], Source.[Name]);

SET IDENTITY_INSERT [dbo].[Sects] OFF;