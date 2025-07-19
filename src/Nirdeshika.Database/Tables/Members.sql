CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1000000, 1),
	[DateOfBirth] DATE NULL,
	[Gender] NCHAR(1) NOT NULL,
	[MobileNumber] VARCHAR(10) NULL,
	[RelationType] TINYINT NULL,
	[Relative] VARCHAR(100) NULL,
	[IsFamilyHead] BIT NOT NULL DEFAULT 0,
	[Sequence] INT NOT NULL DEFAULT 0,
	[FamilyId] INT NOT NULL,
	CONSTRAINT [FK_Members_Families] FOREIGN KEY ([FamilyId]) REFERENCES [dbo].[Families]([Id]),
	CONSTRAINT [FK_Members_RelationshipTypes] FOREIGN KEY ([RelationType]) REFERENCES [dbo].[RelationTypes]([Id]),
)
