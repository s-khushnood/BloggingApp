create procedure CreateUser
@name varchar(30),
@email varchar(40),
@password varchar(20)
as
begin 
insert into Users(Username, useremail, password)
values(@name,@email,@password)
end


--create procedure CreateCategory
--@name varchar(50)
--as
--begin 
--insert into Categories(CatName)
--values(@name)
--end

--create procedure CreatePost
--@title varchar(500),
--@content varchar (3000),
--@category varchar(500),
--@userid int
--as
--begin 
--insert into Posts(title, content,category,userid)
--values(@title,@content,@category,@userid)
--end

--create procedure CreateComment
--@comment varchar(1000),
--@postid int,
--@userid int
--as
--begin 
--insert into Comments(comment,postid,userid)
--values(@comment,@postid,@userid)
--end