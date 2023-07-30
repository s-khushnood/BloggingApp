--CREATE PROCEDURE GetUserByEmail
--    @UserEmail varchar(40)

--AS
--BEGIN
--    SELECT * FROM Users WHERE UserEmail = @UserEmail
--END

--CREATE PROCEDURE GetPostById
--    @userid INT
--AS
--BEGIN
--    SELECT * FROM Posts WHERE Userid = @userid
--END

--create procedure GetAllPosts
--As
--Begin
--select * from Posts
--end

--create procedure GetCategories
--As
--Begin
--select * from Categories
--end

create procedure GetUsers
As
Begin
select * from Users
end

