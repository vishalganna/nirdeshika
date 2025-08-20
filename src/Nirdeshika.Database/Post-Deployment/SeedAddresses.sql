SET IDENTITY_INSERT [dbo].[Addresses] ON;

MERGE INTO [dbo].[Addresses] AS Target
USING (VALUES
    (1, 'Agrahara'),
    (2, 'Arakalgud'),
    (3, 'Ashoka Road'),
    (4, 'Bannur'),
    (5, 'Chamrajnagar'),
    (6, 'Chamundi Vihar'),
    (7, 'Channaraypatna'),
    (8, 'Gundalpete'),
    (9, 'Hand Post'),
    (10, 'HD Kote'),
    (11, 'Hinkal'),
    (12, 'Hunsur'),
    (13, 'Ittigegudu'),
    (14, 'KR Nagar'),
    (15, 'KT Street'),
    (16, 'Kushalnagar'),
    (17, 'Kuvempunagar'),
    (18, 'Mandi Mohalla'),
    (19, 'Mandya'),
    (20, 'Nagmangla'),
    (21, 'Nanjangud'),
    (22, 'Nazarabad'),
    (23, 'Pandavpura'),
    (24, 'Periyapatna'),
    (25, 'Royal City'),
    (26, 'Saraswatipuram'),
    (27, 'Siddarthanagar'),
    (28, 'Srirangpatna'),
    (29, 'Tilak Nagar'),
    (30, 'TN Pura'),
    (31, 'Vidyanaranpuram'),
    (32, 'Vijaynagar'),
    (33, 'Yadavgiri'),
    (33, 'Hebbal')
) AS Source ([Id], [Area])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Area])
    VALUES (Source.[Id], Source.[Area]);

SET IDENTITY_INSERT [dbo].[Addresses] OFF;