CREATE PROCEDURE [dbo].[sp_Family_GetById]
    @familyId INT
AS
BEGIN
	SELECT 
		F.Id,
		F.Head,
		F.SurnameId,
		F.NativeId,
		F.AddressId,

		S.Id,
		S.[Name],

		N.Id,
		N.[Name],

		SC.Id,
		SC.[Name],

		A.Id,
		A.Area

	FROM Families F
	JOIN Surnames S ON F.SurnameId = S.Id
	JOIN Natives N ON F.NativeId = N.Id
	LEFT JOIN Sects SC ON F.SectId = SC.Id
	JOIN Addresses A ON F.AddressId = A.Id
	WHERE F.Id = @familyId
END