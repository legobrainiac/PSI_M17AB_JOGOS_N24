create table users (
	id int identity not null,
	username varchar(50) not null,
	pass varchar(50) not null,
	email varchar(150) not null,
	tipo int default 1,
);

create table products (
	id int identity not null,
	product_name varchar(100) not null,
	product_description varchar(1500),
	price decimal not null,
);

create table products_reviews (
	id int identity not null,
	id_user int foreign key references users(id),
	title varchar(100) not null,
	body varchar(8000) not null,
);

create table users_products (
	id int identity not null,
	id_user int foreign key references users(id),
	id_product int foreign key references products(id),
);

create table users_purchase (
	id int identity not null,
	id_user int foreign key references users(id),
	purchase_json varchar(8000) not null,
)

create table cart (
	id int identity not null,
	id_user int foreign key references users(id),
	cart_json varchar(8000) null,
);






