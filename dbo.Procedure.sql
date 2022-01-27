--CREATE PROCEDURE [dbo].[Procedure]
--	@param1 int = 0,
--	@param2 int
--AS
--	SELECT @param1, @param2
--RETURN 0
CREATE PROCEDURE InsertEmployee

	@Id nvarchar(20),
    @Name nvarchar(20),
    @Lname nvarchar(20),
    @Email nvarchar(20),
    @Address nvarchar(20),
    @Father nvarchar(20),
    @Region nvarchar(20),
    @DOB nvarchar(20),
    @Contact nvarchar(20),
    @Gender nvarchar(20),
    @Program nvarchar(20)
	
	AS 
		BEGIN
            insert into Employees.dbo.Employees values(@Id ,@Name ,@Lname , @Email ,@Address ,@Father ,@Region ,@DOB ,@Contact ,@Gender,@Program)
		END