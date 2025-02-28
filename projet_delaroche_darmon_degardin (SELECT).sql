insert into Utilisateurs values ("A2TDGDelaroche", "Delaroche", "Orane", "188 Rue Gallieni", "0749992897", "orane.delaroche@edu.devinci.fr", "root");
insert into Utilisateurs values ("A2TDGDarmon", "Darmon", "Clément", "12 Avenue Léonard de Vinci", "0695800686", "clement.darmon@edu.devinci.fr", "root");
insert into Utilisateurs values ("A2TDGDegardin", "Degardin", "Thomas", "12 Avenue Léonard de Vinci", "0649443259", "thomas.degardin@edu.devinci.fr", "root");

insert into Recette values ("Pâtes aux fromages");

insert into Client values ("A2TDGDelaroche");
insert into Client values ("A2TDGDegardin");

insert into Cuisinier values ("A2TDGDarmon");

insert into Panier_de_commandes values ("Panier01", "A2TDGDelaroche");

insert into Entreprise values ("A2TDGDegardin");

insert into Commande values ("Commande01", "188 Rue Gallieni", "Panier01");

insert into Plat values ("Plat01", "Pâtes", "italienne", "plat principal", 2, 10, "photo", "aucun régime spécial", '2025-02-27', '2025-02-28', "Pâtes aux fromages", "Commande01", "A2TDGDarmon");

insert into Ingrédients values ("pâtes", "Plat01");
insert into Ingrédients values ("fromage", "Plat01");
insert into Ingrédients values ("gluten", "Plat01");
insert into Ingrédients values ("lactose", "Plat01");

insert into Compose_de values ("pâtes", "Pâtes aux fromages");
insert into Compose_de values ("fromage", "Pâtes aux fromages");
insert into Compose_de values ("gluten", "Pâtes aux fromages");
insert into Compose_de values ("lactose", "Pâtes aux fromages");

insert into Allergique values ("A2TDGDelaroche", "gluten");
insert into Allergique values ("A2TDGDegardin", "lactose");

select * from Utilisateurs;
select * from Recette;
select * from Client;
select * from Cuisinier;
select * from Panier_de_commandes;
select * from Entreprise;
select * from Commande;
select * from Plat;
select * from Ingrédients;
select * from Compose_de;
select * from Allergique;