CREATE DATABASE todolist;

USE todolist;

CREATE TABLE users (
	id int auto_increment,
    name varchar(150) not null,
    primary key (id)
)engine=InnoDB;

CREATE TABLE tasks (
	id int auto_increment,
    title varchar(255) not null,
    description text,
    created_at date,
    user_id int,
    primary key (id),
    foreign key (user_id) references users(id)    
)engine=InnoDB;