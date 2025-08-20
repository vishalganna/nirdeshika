SET IDENTITY_INSERT [dbo].[Surnames] ON;

MERGE INTO [dbo].[Surnames] AS Target
USING (VALUES
    (1, 'Babel'),
    (2, 'Bambaki'),
    (3, 'Bhandari'),
    (4, 'Bhatewara'),
    (5, 'Bohra'),
    (6, 'Bolya'),
    (7, 'Borana'),
    (8, 'Chawat'),
    (9, 'Chopra'),
    (10, 'Dak'),
    (11, 'Dalal'),
    (12, 'Derasariya'),
    (13, 'Desarala'),
    (14, 'Dungarwal'),
    (15, 'Gandhi'),
    (16, 'Ganna'),
    (17, 'Gugaliya'),
    (18, 'Jaroli'),
    (19, 'Kalya'),
    (20, 'Katariya'),
    (21, 'Khamesara'),
    (22, 'Khar Gandhi'),
    (23, 'Kothari'),
    (24, 'Losar'),
    (25, 'Mandot'),
    (26, 'Maru'),
    (27, 'Mehar'),
    (28, 'Mehta'),
    (29, 'Mogra'),
    (30, 'Motawat'),
    (31, 'Mutha'),
    (32, 'Nagori'),
    (33, 'Nahar'),
    (34, 'Nangawat'),
    (35, 'Pichholiya'),
    (36, 'Pitaliya'),
    (37, 'Pokharna'),
    (38, 'Porwad'),
    (39, 'Samra'),
    (40, 'Sarnot'),
    (41, 'Sehlot'),
    (42, 'Siroya'),
    (43, 'Srimal'),
    (44, 'Sukhlecha'),
    (45, 'Vaya')
) AS Source ([Id], [Name])
ON Target.[Id] = Source.[Id]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name])
    VALUES (Source.[Id], Source.[Name]);

SET IDENTITY_INSERT [dbo].[Surnames] OFF;