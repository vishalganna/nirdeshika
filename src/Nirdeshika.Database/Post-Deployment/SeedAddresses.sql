SET IDENTITY_INSERT [dbo].[Addresses] ON;

MERGE INTO [dbo].[Addresses] AS Target
USING (VALUES
    (1, 'Area 1'),
    (2, 'Area 2'),
    (3, 'Area 3'),
    (4, 'Area 4'),
    (5, 'Area 5')
) AS Source ([Id], [Area])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Area])
    VALUES (Source.[Id], Source.[Area]);

SET IDENTITY_INSERT [dbo].[Addresses] OFF;