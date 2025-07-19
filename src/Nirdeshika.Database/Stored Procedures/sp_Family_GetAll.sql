CREATE PROCEDURE [dbo].[sp_Family_GetAll]
AS
	SELECT * FROM Families;

	SELECT * FROM Surnames;

	SELECT * FROM Natives;

	SELECT * FROM Addresses;
RETURN 0
