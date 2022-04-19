drop table appointments;
drop table availability;
drop table doctorservices;
drop table doctors;
drop table patients;
drop table times;
drop table services;
drop table users;

CREATE TABLE users ( 
 userId INT IDENTITY NOT NULL, 
 firstName VARCHAR (100) NOT NULL,
 lastName VARCHAR (100) NOT NULL,
 email VARCHAR (100) NOT NULL,
 password VARCHAR (100) NOT NULL,
 role int not null,
 CONSTRAINT pk_userId
 PRIMARY KEY ( userId ) ) ; 
 
 CREATE TABLE services ( 
 sId INT IDENTITY NOT NULL,
 sName VARCHAR (50),
 timeNeeded int not null,  
 CONSTRAINT pk_sId
 PRIMARY KEY ( sId ) ) ; 
 
 CREATE TABLE patients ( 
 pId int identity not null, 
 userId int not null,
 CONSTRAINT pk_pId
 PRIMARY KEY ( pId ) ) ; 
 
 ALTER TABLE patients ADD CONSTRAINT fk_pUserId
 FOREIGN KEY (userId) 
 REFERENCES users (userId) ;
 
 CREATE TABLE doctors ( 
 docId INT IDENTITY NOT NULL, 
 userId INT NOT NULL, 
 CONSTRAINT pk_docId
 PRIMARY KEY ( docId ) ) ; 
 
 ALTER TABLE doctors ADD CONSTRAINT fk_docUserId
 FOREIGN KEY (userId) 
 REFERENCES users (userId) ;
 
 create table doctorservices (
 dsId int identity not null,
 docId int not null,
 sId int not null,
 constraint pk_dsId
 primary key ( dsId ) );
 
 alter table doctorservices add constraint fk_dsDocId
 foreign key (docId)
 references doctors (docId) ;

 alter table doctorservices add constraint fk_dsSId
 foreign key (sId)
 references services (sId) ;

 create table times (
 timeId int identity not null,
 timeStart datetime not null,
 timeEnd datetime not null,
 constraint pk_timeId
 primary key ( timeId ) );

create table availability (
availId int identity not null,
docId int not null,
timeId int not null,
constraint pk_availId
primary key ( availId ) );

alter table availability add constraint fk_availDocId
foreign key (docId)
references doctors (docId);

alter table availability add constraint fk_availTimeId
foreign key (timeId)
references times (timeId);

create table appointments (
apptId int identity not null,
pId int not null,
docId int not null,
timeId int not null,
constraint pk_apptId
primary key ( apptId ) );

alter table appointments add constraint fk_apptDocId
foreign key (docId)
references doctors (docId);

alter table appointments add constraint fk_apptTimeId
foreign key (timeId)
references times (timeId);

alter table appointments add constraint fk_apptPId
foreign key (pId)
references patients (pId);


--  insert into items values 
-- ('Mozzarella Wedges', 'with marinara sauce', 11),
-- ('Deviled Eggs', 'topped with brown sugar bacon', 10),
-- ('Spinach Queso & Chips', 'melted cheese, artichoke, jalapeño, spinache, sundried tomato', 12),
-- ('Crispy Calamari & Shrimp', 'sweet red pepper, rémoulade, and cocktail sauces', 14),
-- ('Colossal Homemade Onion Rings - small plate', 'with honey mustard sauce', 9),
-- ('Colossal Homemade Onion Rings - large plate', 'with honey mustard sauce', 12),
-- ('Sweet Corn Tamale Cakes', 'avocado, pico de gallo, chipotle ranch, cilantro', 13),
-- ('Chicken Pizza Florentine', 'crispy thin crust, creamed spinach, cheese, diced tomato, jalapeño, artichoke', 13),
-- ('Jumbo Shrimp Cocktail', 'five jumbo shrimp, homemade zesty cocktail sauce', 14),
-- ('Chargrilled Shrimp & Crab Cake', 'four jumbo shrimp, crab cake, herb butter, dill caper sauce', 18),
-- ('Smoked Salmon Dip', 'garlic/black pepper smoked salmon, dill caper sauce, red onion, paprika, shrimp chips', 15),
-- ('Cup of Prime Rib Chili Soup', 'soup of the day', 6),
-- ('Cup of Tomato Dill Soup', 'soup of the day', 6),
-- ('Cup of Chicken Poblano Soup', 'soup of the day', 6),
-- ('House Salad', 'grape tomatoes, jack, cheddar, bacon, cucumbers, rice noodles', 6),
-- ('Balsamic Blue Cheese Chopped Salad', 'tossed with avocado, bacon, tortilla strips, onion, diced tomato', 7),
-- ('Caesar Salad', 'tossed with croutons, fresh grated parmesan', 6),
-- ('Caesar Salad with Grilled Chicken', 'tossed with croutons, fresh grated parmesan', 16),
-- ('Caesar Salad with Salmon Fillet', 'tossed with croutons, fresh grated parmesan', 20),
-- ('Grilled Chicken Salad - small plate', 'tossed with black olives, feta, cucumber, onion, rice noodles', 13),
-- ('Grilled Chicken Salad - large plate', 'tossed with black olives, feta, cucumber, onion, rice noodles', 16),
-- ('Santa Fe Grilled Chicken Salad - small plate', 'black beans, peppers, roasted corn, onion, jack, cheddar', 13),
-- ('Santa Fe Grilled Chicken Salad - large plate', 'black beans, peppers, roasted corn, onion, jack, cheddar', 16),
-- ('Crispy Chicken Tender Salad - small plate', 'grape tomatoes, rice noodles, bacon, jack, cheddar', 14),
-- ('Crispy Chicken Tender Salad - large plate', 'grape tomatoes, rice noodles, bacon, jack, cheddar', 17),
-- ('Sliced Tenderloin Caesar Salad - small plate', 'blue cheese, diced tomato, onion', 16),
-- ('Sliced Tenderloin Caesar Salad - large plate', 'blue cheese, diced tomato, onion', 20),
-- ('Slow Roasted Prime Rib Sandwich', 'au jus, onion roll, mac & cheese', 18),
-- ('Smoked Brisket Philly', 'green peppers, onions, mushrooms, roasted tomatoes, provolone, au jus, fries', 16),
-- ('Grilled Chicken Mozzarella', 'bacon, chipotle ranch, kaiser bun, sweet potato fries', 16),
-- ('Voodoo Chicken Tacos', 'crispy tenders, spicy aioli sauce, shredded cabbage, cilantro, pico de gallo, corn crème brûlée', 15),
-- ('Beyond Burger', 'plant based, cheddar, fried onion ring, chipotle ranch, BBQ sauce, brioche bun, sweet potato fries', 17),
-- ('Chop House Steakburger', 'choice of cheese, blue cheese, bacon, sautéed mushrooms, oinions, brioche bun, fries', 15),
-- ('Teriyaki-Glazed Grilled Chicken', 'fresh honey pineapple relish, rice pilaf, steamed broccoli', 18),
-- ('Grilled Chicken Parmesan - small plate', 'fresh mozzarella, marinara, herbed fettuccine, steamed broccoli', 16),
-- ('Grilled Chicken Parmesan - large plate', 'fresh mozzarella, marinara, herbed fettuccine, steamed broccoli', 18),
-- ('Rosemary Grilled Chicken', 'rice pilaf, steamed broccoli', 17),
-- ('Crispy Chicken Tenders - small plate', 'BBQ and honey mustard sauces, fries', 15),
-- ('Crispy Chicken Tenders - large plate', 'BBQ and honey mustard sauces, fries', 17),
-- ('Filet Mignon - 6 oz', 'the leanest, most tender cut of beef', 31),
-- ('Filet Mignon - 9 oz', 'the leanest, most tender cut of beef', 36),
-- ('Sirloin - 7 oz', 'a rich, flavorful, center-cut steak', 21),
-- ('Sirloin - 10 oz', 'a rich, flavorful, center-cut steak', 25),
-- ('Ribeye - 10 oz', 'a large, tender cut from the strip loin', 27),
-- ('Ribeye - 14 oz', 'a large, tender cut from the strip loin', 32),
-- ('New York Strip', 'a large, tender cut from the strip loin', 34),
-- ('T-Bone', 'enticing combination of the tenderloin and strip loin', 38),
-- ('Prime Rib - 8 oz', 'slow-roasted for 12 hours, au jus', 26),
-- ('Prime Rib - 12 oz', 'slow-roasted for 12 hours, au jus', 30),
-- ('Prime Rib - 16 oz', 'slow-roasted for 12 hours, au jus', 34),
-- ('Filet of Beef Medallions - 6 oz', 'our chefs daily preparation', 28),
-- ('Filet of Beef Medallions - 9 oz', 'our chefs daily preparation', 32),
-- ('Horseradish-Crusted Filet - 6 oz', 'crowned with a seared horseradish crust', 33),
-- ('Horseradish-Crusted Filet - 9 oz', 'crowned with a seared horseradish crust', 38),
-- ('New Zealand Lamb Chops - 6 oz', 'four rib chops, mint sauce', 30),
-- ('New Zealand Lamb Chops - 12 oz', 'four rib chops, mint sauce', 38),
-- ('USDA Prime Steak', 'highest quality, top two percent of beef', 55),
-- ('Chop House Pork Chop', 'thick, bone-in cut, cinnamon apple garnish, jumbo sweet potato', 21),
-- ('Petite Pork Chops', 'two seasons, center-cut chops, mashed potatoes, parmesan creamed spinach', 18),
-- ('Fall-Off-The-Bone BBQ Baby Back Ribs - half rack', 'cinnamon apple garnish, jumbo sweet potato', 20),
-- ('Fall-Off-The-Bone BBQ Baby Back Ribs - full rack', 'cinnamon apple garnish, jumbo sweet potato', 27),
-- ('BBQ Chicken & Baby Back Ribs Combo', 'cinnamon apple garnish, jumbo sweet potato', 26),
-- ('Baked Boston Schrod', 'Ritz cracker crumb breading, dill caper sauce, parmesan creamed spinach', 18),
-- ('Grilled North Atlantic Salmon', 'seasonal topping, rice pilaf, steamed broccoli', 23),
-- ('Chargrilled Jumbo Shrimp - small plate', 'herb butter fettuccine, steamed broccoli', 18),
-- ('Chargrilled Jumbo Shrimp - large plate', 'herb butter fettuccine, steamed broccoli', 23),
-- ('Homemade Blue Crab Cakes - small plate', 'mashed potatoes, sugar snap peas', 19),
-- ('Homemade Blue Crab Cakes - large plate', 'mashed potatoes, sugar snap peas', 25),
-- ('Cold Water Lobster Tail', 'oven roasted, parmesan and paprika, drawn butter, corn crème brûlée', 25),
-- ('Mahi Mahi', 'seasonal topping, rice pilaf', 20),
-- ('Seafood Fettuccine Alfredo - small plate', 'lobster, crab, shrimp, snap peas, mushrooms, tomato, green onion', 21),
-- ('Seafood Fettuccine Alfredo - large plate', 'lobster, crab, shrimp, snap peas, mushrooms, tomato, green onion', 25),
-- ('Chicken Fettuccine Alfredo - large plate', 'lobster, crab, shrimp, snap peas, mushrooms, tomato, green onion', 16),
-- ('Chicken Fettuccine Alfredo - large plate', 'lobster, crab, shrimp, snap peas, mushrooms, tomato, green onion', 19)
