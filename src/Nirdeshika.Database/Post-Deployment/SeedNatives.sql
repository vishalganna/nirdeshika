SET IDENTITY_INSERT [dbo].[Natives] ON;

MERGE INTO [dbo].[Natives] AS Target
USING (VALUES
    (1, 'Native 1'),
    (2, 'Native 2'),
    (3, 'Native 3'),
    (4, 'Native 4'),
    (5, 'Native 5')
) AS Source ([Id], [Name])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name])
    VALUES (Source.[Id], Source.[Name]);

SET IDENTITY_INSERT [dbo].[Natives] OFF;