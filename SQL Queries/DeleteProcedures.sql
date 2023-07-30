--create procedure deleteuserbyemail
--@email varchar(40)
--as
--begin
--delete from users where UserEmail=@email
--end

--create procedure deletepostbyid
--@postid int
--as
--begin
--delete from posts where postid=@postid
--end

--create procedure deletecommentbyid
--@commentid int
--as
--begin
--delete from comments where commentid=@commentid
--end

--create procedure deletecategorybyid
--@catid int
--as
--begin
--delete from categories where catid=@catid
--end

create procedure deleteuserbyid
@userid int
as
begin
delete from Users where UserId=@userid
end