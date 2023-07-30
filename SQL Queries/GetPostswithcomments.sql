CREATE PROCEDURE GetPostsWithComments
AS
BEGIN
    WITH PostComments AS (
        SELECT p.PostID, p.Title, p.Content, p.UserID, p.Category, u.UserName,
               c.CommentID, c.Comment
        FROM Posts p
        LEFT JOIN Comments c ON p.PostID = c.PostID
        JOIN Users u ON p.UserID = u.UserID
    )
    SELECT PostID, Title, Content, UserID, UserName, Category,
           STUFF((
             SELECT '; ' + Comment
             FROM PostComments pc
             WHERE pc.PostID = p.PostID
             FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Comments
    FROM PostComments p
    GROUP BY PostID, Title, Content, UserID, UserName, Category
    ORDER BY PostID;
END