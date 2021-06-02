CREATE TRIGGER AutoDeleteWinnary
ON WinnarySet
INSTEAD OF DELETE
AS
DECLARE 
	@targetId int
BEGIN
	SELECT @targetId = i.Id FROM deleted i;
	DELETE FROM EmployeesSet1 WHERE EmployeesSet1.WinnaryId=@targetId;
	DELETE FROM WinnarySet WHERE WinnarySet.Id=@targetId;
END