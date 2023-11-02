create database MinhTamEcommerce
go

use MinhTamEcommerce
go

create table "Role"(
	id int identity primary key,
	"name" varchar(255) not null,
	"description" nvarchar(max)
)
go

create table Account (
	id int identity primary key,
	username varchar(max) not null,
	"password" varchar(max) not null,
	firstname nvarchar(255) not null,
	lastname nvarchar(255) not null,
	email varchar(max) not null,
	phone varchar(20) not null,
	"address" nvarchar(max) not null,
	avatar varchar(max),
	is_active bit default 0,
	security_code varchar(10),
	role_id int not null,
	"description" nvarchar(max),
	create_at date,
)
go



create table APIToken(
	id int identity primary key,
	token_refresh varchar(max) not null,
	account_id int not null,
	create_date datetime not null,
	expire_date datetime not null
)
go


create table Comment(
	id int identity primary key,
	product_id bigint not null ,
	account_id int not null,
	parent_comment_id int,
	comment nvarchar(max) not null,
	create_date datetime not null,
	foreign key (account_id) references Account(id),
    foreign key (product_id) references Product(id)
)
go

create table AccountPayment(
	id bigint identity primary key,
	account_id int not null,
	created datetime not null,
	payment_type nvarchar(max),

)
go


create table Category(
	id int identity primary key,
	"name" nvarchar(255) not null,
	"description" nvarchar(max),
	images varchar(max) not null ,
	create_at datetime,
	update_at datetime
)
go


create table Supplier(
	id int identity primary key,
	"name" nvarchar(max) not null,
	"description" nvarchar(max),
)
go

create table Product(
	id bigint identity primary key,
	"name" nvarchar(max) not null,
	price float not null,
	"description" nvarchar(max),
	"image" varchar(max) not null,
	category_id int not null,
	discount_id int not null,
	supplier_id int not null,
	summary nvarchar(max),
	create_at datetime,
	update_at datetime,
	rating smallint default 0,
	gender nvarchar(50)
)
go

create table "Collection"(
	id int identity primary key,
	product_id bigint not null,
	size_option varchar(255) not null ,
	account_id int not null,
	"description" varchar(max)

)
go


create table ProductSizeOption(
	product_id bigint ,
	size_option varchar(255) not null ,
	quantity_stock int not null,
	quantity_sold int not null,
	"description" varchar(max),
	primary key (product_id,size_option)
)
go


create table Discount(
	id int identity primary key,
	precent float not null,
	"description" nvarchar(max),
	start_time datetime not null,
	end_time datetime not null
)
go

create table Cart(
	id int primary key identity,
	account_id int not null,
	create_at datetime not null,
	completed_at datetime,
)
go

create table CartDetail(
	cart_id int,
	product_id bigint not null,
	size_option nvarchar(255)  not null,
	quantity int not null,
	primary key (cart_id, product_id)
)
go

create table "Order"(
	id int primary key identity,
	order_date datetime not null,
	"status" nvarchar(255) ,
	total_price float  not null,
	account_id int not null,
	"address" nvarchar(max) not null,
	phone varchar(20) not null,
	payment_method nvarchar(255)
)
go

create table OrderDetail(
	order_id int ,
	product_id bigint not null,
	size_option nvarchar(255) not null,
	quantity int not null
	primary key (order_id,product_id)
)
go


alter table Account 
add constraint FK_Account_Role foreign key (role_id) references "Role"(id)
go

alter table APIToken 
add constraint FK_APIToken_Account foreign key (account_id) references Account(id)
go

alter table Product 
add constraint FK_Product_Supplier foreign key (supplier_id) references Supplier(id)
go

alter table Product 
add constraint FK_Product_Discount foreign key (discount_id) references Discount(id)
go

alter table Product 
add constraint FK_Product_Category foreign key (category_id) references Category(id)
go

alter table ProductSizeOption 
add constraint FK_ProductSizeOption_Product foreign key (product_id) references Product(id)
go

alter table "Collection" 
add constraint FK_Collection_Product foreign key (product_id) references Product(id)
go

alter table Cart 
add constraint FK_Cart_Account foreign key (account_id) references Account(id)
go

alter table CartDetail
add constraint FK_CartDetail_Cart foreign key (cart_id) references Cart(id)
go

alter table CartDetail
add constraint FK_CartDetail_Product foreign key (product_id) references Product(id)
go


alter table "Order" 
add constraint FK_Order_Account foreign key (account_id) references Account(id)
go

alter table OrderDetail
add constraint FK_orderDetail_Order foreign key (order_id) references "Order"(id)
go

alter table OrderDetail
add constraint FK_OrderDetail_Product foreign key (product_id) references Product(id)
go

