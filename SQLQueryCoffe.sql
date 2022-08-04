create table About(

  AboutID int identity(1,1) primary key,
  AboutTitle nvarchar(25),
  AboutContent nvarchar (max),
  AboutPhoto nvarchar (max)
)
select * from About
truncate table About

create table Blogs(

  BlogsID int identity(1,1) primary key,
  BlogsTitle nvarchar(30),
  BlogsMain nvarchar(max),
  BlogsDate date,
  BlogsContent nvarchar (max),
  BlogsPhoto nvarchar (max)
)
select * from Blogs

create table Staff(

  StaffID int identity(1,1) primary key,
  StaffName nvarchar(40),
  StaffJob nvarchar (30),
  StaffPhoto nvarchar (max),
  StaffFacebook nvarchar(40),
  StaffInstagram nvarchar(40),
  StaffLinkedin nvarchar(40)
)
select * from Staff
 create table Gallery(
  GalleryID int identity(1,1) primary key,
  GalleryPhoto nvarchar(max)
 )
 select * from Gallery

 create table Contact(
  ContactID int identity(1,1) primary key,
  ContactName nvarchar(30),
  ContactEmail nvarchar(40),
  ContactMessage nvarchar(500)
 )
 select * from Contact

  create table Reservation(
  RsrvtnID int identity(1,1) primary key,
  RsrvtnName nvarchar(40),
  RsrvtnPhone nvarchar(20),
  RsrvtnDate date,
  RsrvtnTime nvarchar(20),
  RsrvtnMessage nvarchar(500)
 )
 select * from Reservation

 create table Info(
  InfoID int identity(1,1) primary key,
  InfoPlace nvarchar(100),
  InfoPhone nvarchar(20),
  InfoEmail nvarchar(40),
  InfoFacebook nvarchar(100),
  InfoInstagram nvarchar(100),
  InfoWhatsapp nvarchar(100),
  InfoOpenHours1 nvarchar(100),
  InfoOpenHours2 nvarchar(100)
 )
select * From Info
drop table Info
create table Comment(
  CommentID int identity(1,1) primary key,
  CommentName nvarchar(30),
  CommentEmail nvarchar(40),
  CommentMessage nvarchar(500),
  CommentBlogsId int
 )
 select * from Comment


 create view DetailView as(
select * from Blogs
left join Comment
on CommentID=CommentBlogsId
)


 create table Categoria
(
	CategoriaId int identity(1,1) primary key,
	CategoriaName nvarchar(25)
)

create table Sweets
(
	SweetsId int identity(1,1) primary key,
	SweetsName nvarchar(25),
	SweetsContent nvarchar(max),
	SweetsPrice nvarchar(10),
	SweetsPhoto nvarchar(max),
	SweetsCategoriaId int
)

create view Umumi as(
select * from Sweets
left join Categoria
on CategoriaId=SweetsCategoriaId
)

select * from Categoria
 
 create table UserLogin (
	UserLoginId int identity(1,1) primary key,
	Username nvarchar(25),
	Userpassword nvarchar(20)
 )
INSERT INTO UserLogin (Username, Userpassword)
VALUES ('Admin', '5678');
 select * from UserLogin