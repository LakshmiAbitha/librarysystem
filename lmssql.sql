create database libraryms

use libraryms

create table logindetails(
username varchar(50),
userpassword varchar(50)
)


create table bookdetails
(
bookid int primary key,
bookname varchar(50),
authorname varchar(50),
quantity int
)


create table studentdetails
(
rollno int primary key,
sname varchar(50),
dept varchar(50),
email varchar(50)
)


create table issuebook
(
rollno int references studentdetails(rollno),
bookid int 
)



insert into logindetails values('abi','pass123')

select * from logindetails
select * from bookdetails
select * from issuebook 
select * from studentdetails
