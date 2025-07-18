CREATE TABLE [dbo].[Members]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[DateOfBirth] DATE NULL,
	[Gender] NCHAR(1) NOT NULL,
	[MobileNumber] VARCHAR(10) NULL,
	[RelationType] TINYINT NULL,
	[Relative] VARCHAR(100) NULL,
	[FamilyId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_Members_Families] FOREIGN KEY ([FamilyId]) REFERENCES [dbo].[Families]([Id]),
	CONSTRAINT [FK_Members_RelationshipTypes] FOREIGN KEY ([RelationType]) REFERENCES [dbo].[RelationTypes]([Id]),
)
