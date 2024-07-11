create database FoodAppDB;

use FoodAppDB;

create table Addresses (
	addr_id int auto_increment primary key,
	line1 varchar(100) not null,
	line2 varchar(100),
	line3 varchar(100),
	city varchar(50) not null,
	state varchar(50) not null,
	country varchar(50) not null
);

alter table addresses add pin char(6) not null;

create table Customers (
	c_id int auto_increment primary key,
	c_name varchar(100),
	c_email varchar(50) not null,
	c_addr int,
	
	foreign key(c_addr) references Addresses(addr_id),
	constraint chk_email check(c_email like '%@%.%')
);

create table Restaurants (
	r_id int auto_increment primary key,
	r_name varchar(100),
	r_addr int,
	r_email varchar(50) not null,
	foreign key(r_addr) references Addresses(addr_id),
	constraint chk_email check(r_email like '%@%.%')
);

create table Deliverers (
	d_id int auto_increment primary key,
	d_name varchar(100),
	d_addr int,
	d_email varchar(50) not null,
	foreign key(d_addr) references Addresses(addr_id),
	constraint chk_email check(d_email like '%@%.%')
);

create table Categories (
	cat_id int auto_increment primary key,
	cat_name varchar(50) not null
);

create table Dishes (
	d_id int auto_increment primary key,
	d_name varchar(100) not null,
	is_non_veg bool not null,
	d_categ int not null,
	foreign key(d_categ) references Categories(cat_id)
);

create table Menus (
	d_id int not null,
	r_id int not null,
	price decimal(6,2) not null,
	
	foreign key(d_id) references Dishes(d_id),
	foreign key(r_id) references Restaurants(r_id),
	primary key(r_id, d_id)
);

create table CartItems (
	cust_id int,
	r_id int not null,
	d_id int not null,
	d_qn int default 1,
	cost decimal(10,2) not null,
	foreign key (cust_id) references Customers(c_id),
	foreign key (r_id) references Restaurants(r_id),
	foreign key (d_id) references Dishes(d_id),
	primary key(cust_id, r_id, d_id)
);

create table Orders (
	o_id char(36) default uuid() primary key,
	r_id int not null,
	c_id int not null,
	status varchar(10) not null default 'Pending',
	o_date datetime default curtime(),
	foreign key(r_id) references Restaurants(r_id),
	foreign key(c_id) references Customers(c_id),
	constraint chk_status check(status in ('Pending', 'Accepted', 'Rejected', 'Delivered', 'Lost'))
);

create table OrderItems (
	cust_id int,
	r_id int not null,
	d_id int not null,
	d_qn int default 1,
	cost decimal(10,2) not null,
	o_id char(36) not null,
	foreign key (cust_id) references Customers(c_id),
	foreign key (r_id) references Restaurants(r_id),
	foreign key (d_id) references Dishes(d_id),
	foreign key (o_id) references Orders(o_id),
	primary key(cust_id, r_id, d_id)	
);

drop table Orders;

create table Test (
	t_id char(36) default uuid() primary key,
	name varchar(50)
);

insert into Test (name) values ('Mr. Fresh');

select * from Test; 
