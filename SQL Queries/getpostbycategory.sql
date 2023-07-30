CREATE PROCEDURE GetPostsByCategory
    @CatName varchar(50)
AS
BEGIN
    SELECT *
    FROM Posts
    WHERE Category = @CatName
    ORDER BY PostID
END