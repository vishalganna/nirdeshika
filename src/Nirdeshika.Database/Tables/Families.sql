CREATE TABLE [dbo].[Families]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(100000, 1), 
    [Head] NVARCHAR(100) NOT NULL,
	[SurnameId] INT NOT NULL, 
	[NativeId] INT NOT NULL,
	[AddressId] INT NOT NULL,
    CONSTRAINT [FK_Families_Surname] FOREIGN KEY (SurnameId) REFERENCES [Surnames](Id),
	CONSTRAINT [FK_Families_Native] FOREIGN KEY (NativeId) REFERENCES [Natives](Id),
	CONSTRAINT [FK_Families_Area] FOREIGN KEY (AddressId) REFERENCES [Addresses](Id)
)
