create database SPDT;
use SPDT;
create table students(
id int primary key identity(1,1),
name varchar(100) not null,
);

create table teachers(
id int primary key identity(1,1),
name varchar(100) not null,
);

insert into students(name) values
('Riyu'),
('Annu'),('Ritu'),('Vanshu');
insert into teachers(name) values('Ruxi'),('Piyu'),('Kittu'),('Saimu'),('Sangu');



create table roles(
id int primary key identity(1,1),
name varchar(100) not null,
s_id int not null,
t_id int not null,
constraint fk_std foreign key(s_id)
references students(id),
constraint fk_t foreign key(t_id)
references teachers(id),
);

ALTER TABLE roles
DROP CONSTRAINT fk_std;


alter table roles
drop column s_id ;

alter table students
add role_id int,
constraint fk_role foreign key(role_id)
references roles(id);


alter table teachers
add role_id int ,
constraint fk_roles foreign key (role_id)
references roles(id);

insert into roles(name) values
('Servant'),
('Manager'),
('Wife1'),('Wife2'),('C_Biter');

create procedure AddTeachersRole
		@id int,
		@role_id int
as
begin
	update teachers set role_id=@role_id where id=@id;
end;

select * from students;
select dbo.GetRoleIdByName('GOD');
create procedure AddStudentsRoles
@id int,
@role_id int

as
begin
	update students set role_id=@role_id where id=@id;
end;

create procedure AddRoles
@name varchar(200)
as
begin
insert into roles(name) values(@name);
end;

exec AddRoles @name='GOD';
exec AddTeachersRole @id=3, @role_id=4;
exec AddStudentsRoles @id=1, @role_id=9;

create function GetRoleIdByName(@roleName varchar(100))
returns int
as
begin
declare @roleId int;

select @roleId=id from roles where name=@roleName;
return @roleId;
end;

select dbo.GetRoleIdByName('Mommy');

create function GetRoleNamebyId (@id int)
returns varchar(200)
as
begin
	declare @name varchar(200);

	select @name=name from roles where id=@id;

	return @name;
end;

select dbo.GetRoleNamebyId(2);

select * from students;
select * from teachers;
select * from roles;

select ro.name as Role, s.name as students
from roles ro
join students s on s.role_id=ro.id;

SELECT 
    t.name AS TeacherName,
    r.name AS Role
FROM teachers t
JOIN roles r ON t.role_id = r.id;


select sr.name as StudentRoles, s.name as StudentName, tr.name as TeacherRole, t.name as TeacherName
from students s
join roles sr on sr.id=s.role_id
cross join teachers t
join roles tr on t.role_id=tr.id;

select r.name as Roles, s.name as Students, t.name as Teachers
from roles r
left join students s on s.role_id=r.id
left join teachers t on t.role_id=r.id;

