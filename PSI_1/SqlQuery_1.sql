DROP DATABASE IF EXISTS livinparis;
CREATE DATABASE IF NOT EXISTS Livinparis;
USE Livinparis;

CREATE TABLE Utilisateurs(
   IdUtilisateur VARCHAR(50),
   nom VARCHAR(50) NOT NULL,
   prénom VARCHAR(50) NOT NULL,
   adresse VARCHAR(50) NOT NULL,
   numéro_de_téléphone VARCHAR(50) NOT NULL,
   email VARCHAR(50) NOT NULL,
   mdp VARCHAR(50) NOT NULL,
   PRIMARY KEY(IdUtilisateur)
);

CREATE TABLE Recette(
   nomRecette VARCHAR(50),
   PRIMARY KEY(nomRecette)
);

CREATE TABLE Client(
   IdUtilisateur VARCHAR(50),
   PRIMARY KEY(IdUtilisateur),
   FOREIGN KEY(IdUtilisateur) REFERENCES Utilisateurs(IdUtilisateur)
);

CREATE TABLE Cuisinier(
   IdUtilisateur VARCHAR(50),
   PRIMARY KEY(IdUtilisateur),
   FOREIGN KEY(IdUtilisateur) REFERENCES Utilisateurs(IdUtilisateur)
);

CREATE TABLE Panier_de_commandes(
   IdPanier VARCHAR(50),
   IdUtilisateur VARCHAR(50) NOT NULL,
   PRIMARY KEY(IdPanier),
   FOREIGN KEY(IdUtilisateur) REFERENCES Client(IdUtilisateur)
);

CREATE TABLE Entreprise(
   IdUtilisateur VARCHAR(50),
   PRIMARY KEY(IdUtilisateur),
   FOREIGN KEY(IdUtilisateur) REFERENCES Client(IdUtilisateur)
);

CREATE TABLE Commande(
   IdCommande VARCHAR(50),
   adresse VARCHAR(50) NOT NULL,
   IdPanier VARCHAR(50) NOT NULL,
   PRIMARY KEY(IdCommande),
   FOREIGN KEY(IdPanier) REFERENCES Panier_de_commandes(IdPanier)
);

CREATE TABLE Plat(
   IdPlat VARCHAR(50),
   nomPlat VARCHAR(50) NOT NULL,
   nationnalité VARCHAR(50),
   type VARCHAR(50),
   nb INT NOT NULL,
   prix DOUBLE NOT NULL,
   photo VARCHAR(50) NOT NULL,
   régime_spécial VARCHAR(50),
   date_de_fabrication DATE NOT NULL,
   date_de_péremption DATE NOT NULL,
   nomRecette VARCHAR(50),
   IdCommande VARCHAR(50) NOT NULL,
   IdUtilisateur VARCHAR(50) NOT NULL,
   PRIMARY KEY(IdPlat),
   UNIQUE(photo),
   FOREIGN KEY(nomRecette) REFERENCES Recette(nomRecette),
   FOREIGN KEY(IdCommande) REFERENCES Commande(IdCommande),
   FOREIGN KEY(IdUtilisateur) REFERENCES Cuisinier(IdUtilisateur)
);

CREATE TABLE Ingrédients(
   nomIngrédient VARCHAR(50) NOT NULL,
   IdPlat VARCHAR(50) NOT NULL,
   PRIMARY KEY(nomIngrédient),
   FOREIGN KEY(IdPlat) REFERENCES Plat(IdPlat)
);

CREATE TABLE Compose_de(
   nomIngrédient VARCHAR(50),
   nomRecette VARCHAR(50),
   PRIMARY KEY(nomIngrédient, nomRecette),
   FOREIGN KEY(nomIngrédient) REFERENCES Ingrédients(nomIngrédient),
   FOREIGN KEY(nomRecette) REFERENCES Recette(nomRecette)
);

CREATE TABLE Allergique(
   IdUtilisateur VARCHAR(50),
   nomIngrédient VARCHAR(50),
   PRIMARY KEY(IdUtilisateur, nomIngrédient),
   FOREIGN KEY(IdUtilisateur) REFERENCES Client(IdUtilisateur),
   FOREIGN KEY(nomIngrédient) REFERENCES Ingrédients(nomIngrédient)
);

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