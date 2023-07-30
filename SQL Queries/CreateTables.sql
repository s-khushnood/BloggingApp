Create table Users(
UserId int primary key identity (1,1) not null,
Username varchar(50) not null,
UserEmail varchar(60) not null unique,
Password  varchar(20) not null,
UserTime datetime default current_timestamp)

Create table Categories(
CatId int primary key identity (1,1) not null,
CatName varchar(50) not null)

Create table Posts(
PostId int primary key identity (1,1) not null,
UserId int,
Title varchar(500) not null,
Content varchar(3000) not null,
Category varchar(50) not null,
Posttime datetime default current_timestamp)


create table Comments(
CommentId int primary key identity (1,1) not null,
PostId int,
UserId int,
Comment varchar(1000) not null,
Commenttime datetime default current_timestamp
)