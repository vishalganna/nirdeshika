CREATE TABLE [dbo].[FamilyMembers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1000000, 1),
	[Name] VARCHAR(100) NOT NULL,
	[DateOfBirth] DATE NULL,
	[Gender] CHAR(1) NOT NULL,
	[MobileNumber] CHAR(10) NULL,
	[RelationTypeId] TINYINT NULL,
	[Relative] VARCHAR(100) NULL,
	[IsFamilyHead] BIT NOT NULL DEFAULT 0,
	[Sequence] TINYINT NOT NULL DEFAULT 0,
	[FamilyId] INT NOT NULL,
	CONSTRAINT [FK_FamilyMembers_Families] FOREIGN KEY ([FamilyId]) REFERENCES [dbo].[Families]([Id]),
	CONSTRAINT [FK_FamilyMembers_RelationshipTypes] FOREIGN KEY ([RelationTypeId]) REFERENCES [dbo].[RelationTypes]([Id]),
)
