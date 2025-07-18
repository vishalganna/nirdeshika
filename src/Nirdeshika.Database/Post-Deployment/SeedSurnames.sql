SET IDENTITY_INSERT [dbo].[Surnames] ON;

MERGE INTO [dbo].[Surnames] AS Target
USING (VALUES
    (1, 'Surname 1'),
    (2, 'Surname 2'),
    (3, 'Surname 3'),
    (4, 'Surname 4'),
    (5, 'Surname 5')
) AS Source ([Id], [Name])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name])
    VALUES (Source.[Id], Source.[Name]);

SET IDENTITY_INSERT [dbo].[Surnames] OFF;