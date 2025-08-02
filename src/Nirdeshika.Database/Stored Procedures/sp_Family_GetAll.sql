CREATE PROCEDURE [dbo].[sp_Family_GetAll]
AS
	SELECT * FROM Families;

	SELECT * FROM Surnames;

	SELECT * FROM Natives;

	SELECT * FROM Sects;

	SELECT * FROM Addresses;
RETURN 0
