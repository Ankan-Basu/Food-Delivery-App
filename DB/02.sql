use FoodAppDB;

insert into categories (cat_name) values 
('Chinese'),
('South Indian'),
('Mughlai');

select * from categories c ;

insert into dishes (d_name,	is_non_veg,	d_categ) values 
('Mixed Fried Rice', true, 1),
('Veg Fried Rice', false, 1),
('Chicken Fried Rice', true, 1),
('Egg Fried Rice', true, 1),
('Veg Biryani', false, 3),
('Chicken Biryani', true, 3),
('Mutton Biryani', true, 3),
('Idli', false, 2),
('Plain Dosa', false, 2),
('Masala Dosa', false, 2),
('Uttapam', false, 2)

select * from dishes d join categories c on d.d_categ = c.cat_id ;

insert into addresses (line1, line2, line3, city, pin, state, country) values
('13/2 ABC Road', null, null, 'Kolkata', '700051', 'West Bengal', 'India'),
('2A NR Avenue', null, null, 'Kolkata', '700032', 'West Bengal', 'India'),
('48A/2 BM Sarani', 'Rajbajar', null, 'Kolkata', '700011', 'West Bengal', 'India');

select * from addresses a ;

insert into restaurants (r_name, r_addr, r_email) values 
('Rajshahi Restaurant', 1, 'rajshahi@mail.com'),
('Sifu Restaurant', 2, 'sifu@mail.com');

insert into menus (d_id, r_id,	price) values
(1, 2, 200),
(2, 2, 150),
(3, 2, 190),
(4, 2, 175),
(5, 1, 200),
(6, 1, 220),
(7, 1, 250),
(8, 1, 40),
(9, 1, 45),
(10, 1, 60);

select d.d_name, c.cat_name, r.r_name, price from 
menus m join restaurants r on m.r_id = r.r_id
join dishes d on m.d_id = d.d_id
join categories c on c.cat_id = d.d_categ 
order by r.r_name ;
