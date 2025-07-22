CREATE PROCEDURE [dbo].[sp_FamilyMember_Add]
	@name VARCHAR(100),
	@dateOfBirth DATE = NULL,
	@gender CHAR(1),
	@mobileNumber CHAR(10) = NULL,
	@relationTypeId TINYINT = NULL,
	@relative VARCHAR(100) = NULL,
	@isFamilyHead BIT = 0,
	@familyId INT,
    @newMemberId INT OUTPUT

AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @sequence TINYINT;

    IF @isFamilyHead = 1
    BEGIN
        SET @sequence = 1;
    END
    ELSE
    BEGIN
        SELECT @sequence = COUNT(*) + 1
        FROM dbo.FamilyMembers
        WHERE FamilyId = @familyId;
    END

    INSERT INTO dbo.FamilyMembers (
        [Name],
        DateOfBirth,
        Gender,
        MobileNumber,
        RelationTypeId,
        [Relative],
        IsFamilyHead,
        FamilyId,
        [Sequence]
    )
    VALUES (
        @name,
        @dateOfBirth,
        @gender,
        @mobileNumber,
        @relationTypeId,
        @relative,
        @isFamilyHead,
        @familyId,
        @sequence
    );

    SET @newMemberId = SCOPE_IDENTITY();
END