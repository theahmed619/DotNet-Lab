create database college;
use college;

create table students(
s_id int primary key not null identity(1,1),
name varchar(200) not null,
marks int 
);

select * from students;

insert into students(name,marks) values('Jon',99),('Ron',88);

update students set marks=29 where name='Jon';

create table teachers(
t_id int primary key not null identity(1,1),
name varchar(200) not null,
salary int 
);

select * from teachers;

insert into teachers(name, salary) values('Jenny',50000),('Harry',20000);

create table subjects(
sub_id int primary key not null identity(1,1),
t_id int ,
s_id int,

constraint fk_teacher foreign key (t_id)
references teachers(t_id)

);

alter table subjects 
add constraint fk_student foreign key (s_id)
references students(s_id);

INSERT INTO students (name, marks)
VALUES 
('Tina', 85),
('Ravi', 72),
('Priya', 91),
('Vikram', 66),
('Sara', 78),
('Kabir', 59),
('Meena', 92),
('Farhan', 88),
('Simran', 73),
('Arjun', 64);


INSERT INTO teachers (name, salary)
VALUES 
('Mr. Sharma', 55000),
('Ms. Kapoor', 60000),
('Mr. Iyer', 58000),
('Mrs. Fernandes', 62000),
('Mr. Khan', 57000),
('Ms. Bose', 54000),
('Mr. Patel', 61000),
('Mr. Verma', 50000),
('Mrs. Naik', 53000),
('Ms. D’Souza', 59000);

INSERT INTO subjects (s_id, t_id)
VALUES
(13, 2),
(2, 1),
(3, 5),
(4, 4),
(5, 3),
(6, 6),
(7, 7),
(8, 2),
(9, 8),
(10, 10);

alter table subjects 
add name varchar(200);

UPDATE subjects
SET name = 'Economics'
WHERE sub_id = 7;

UPDATE subjects
SET name = 'Economics'
WHERE sub_id = 8;

UPDATE subjects
SET name = 'Maths'
WHERE sub_id = 10;




select * from students;
select * from teachers;
select * from subjects;

select * from students where name like 's%';

select s.name as StudentName, sub.name as SubjectName, t.name as TeacherName
from subjects sub
inner join students s on sub.s_id=s.s_id
inner join teachers t on sub.t_id=t.t_id;

SELECT s.name AS StudentName, t.name AS TeacherName
FROM students s
CROSS JOIN teachers t;

--Retrieve all student names along with their subject names.

--Display the names of teachers and the subjects they are assigned to.

select t.name AS TeacherName, sub.name as SubjectName
from subjects sub
inner join teachers t on sub.t_id=t.t_id;

--List all subjects along with the names of the students and teachers associated with them.

SELECT sub.name as Subject, s.name as Student, t.name as Teacher
from subjects sub 
inner join students s on sub.s_id=s.s_id
inner join teachers t on sub.t_id=t.t_id;

--Show students who are not enrolled in any subject.
select s.name
from students s
left join subjects sub on sub.s_id=s.s_id
where sub.s_id is null; 

SELECT s.name
FROM subjects sub
RIGHT JOIN students s ON sub.s_id = s.s_id
WHERE sub.s_id IS NULL;



--Get the list of teachers who are not assigned to any subject.
select t.name
from teachers t
left join subjects sub on sub.t_id=t.t_id
where sub.t_id is null;

select t.name
from subjects sub
right join teachers t on t.t_id=sub.t_id
where sub.t_id is null;

--Find the number of subjects assigned to each teacher.


--List all students and count how many subjects each student is enrolled in.

--Show the details of students and their teachers where the student’s marks are greater than 80.

--Get all combinations of student and teacher pairs, even if they are not connected through a subject.

--Display all subjects even if they don't have a student or a teacher assigned.

--For each teacher, display their name along with the total number of unique students they teach.

--List students who are assigned to more than one teacher.

--Retrieve all teacher-student pairs that are not linked via any subject.

--Show students along with their highest scoring subject (assume each subject can have a marks column).

--Find the average marks per teacher across all their students’ subjects.

--Get the names of students and teachers who are linked through subjects and also have names starting with the same letter.

--List all students who share the same teacher in at least two different subjects.

--Show all students who are enrolled in subjects taught by teachers with salary above 60,000.

--Display the subject name along with student and teacher names, but include NULLs if any are missing.


--group by and aggregate
--Find the total number of students in the students table.
select count(*) from students;

--Find the average marks scored by all students.
select avg(marks) from students;

--Find the highest salary among all teachers.
SELECT top 1 name, salary
FROM teachers
ORDER BY salary DESC;

SELECT top 1 name, salary
FROM teachers
WHERE salary < (SELECT MAX(salary) FROM teachers)
order by  salary  desc;

select * from teachers;


--Count the number of teachers in the teachers table.
select count(*) from teachers;

--Find the sum of marks of all students.
select sum(marks) from students;

--Intermediate Level
--Find the total marks scored by each student (assuming multiple entries per student).
SELECT name, SUM(marks) AS TotalMarks
FROM students
GROUP BY name;

select * from students;

--Find the number of subjects assigned to each teacher.
SELECT t.name AS TeacherName, COUNT(sub.sub_id) AS SubjectCount
FROM teachers t
LEFT JOIN subjects sub ON t.t_id = sub.t_id
GROUP BY t.name;


--Find the average salary of teachers grouped by salary range (e.g., salary above 30000 and below).


--Count how many students scored more than 80 marks show thier name.
SELECT name, COUNT(*) AS HighScorers
FROM students
WHERE marks > 80;



--Find the maximum marks scored by students in each subject.

--Advanced Level
--Find the teacher(s) with the highest number of assigned subjects.

--Find the average marks of students grouped by their assigned teacher.

--Find the total salary paid to teachers grouped by the number of subjects they teach.

--Find the number of students assigned to each teacher and order the result by descending number of students.

--Find the teacher(s) with no subjects assigned (use aggregate + join).

select * from teachers;

select top 1 name ,salary from teachers
where salary <(select max(salary) from teachers)
order by salary desc;

select t.name 
from subjects sub
left join teachers t on sub.t_id=t.t_id
where sub.name not in ('IT');


SELECT t.name, sub.name, t.salary
FROM teachers t
LEFT JOIN subjects sub ON sub.t_id = t.t_id
ORDER BY 
   CASE WHEN sub.name IS NULL THEN 1 ELSE 0 END,
   t.salary DESC;

create procedure InsertStudent
		@name varchar(50),
		@marks int
as 
begin
 insert into students(name,marks) values(@name,@marks)
end;
exec InsertStudent @name='Ahmy' , @marks=66;


create procedure SelectAllStudents

as
begin
select * from students;
end;

exec SelectAllStudents;

create procedure UpdateStudent
		@id int,
		@name varchar(200)
as
begin

update students set name=@name where s_id=@id
end;

exec UpdateStudent @id=13, @name='Aaraon';

exec SelectAllStudents;

select upper(name) from students;

create function GetFullName(@First varchar(50), @Last varchar(50))
returns varchar(100)
as
begin
return (@First+''+@Last);
end;

select dbo.GetFullName('Ahmed','Yo');

select name , count(*)
from students 
group by name
having count(*) >1;