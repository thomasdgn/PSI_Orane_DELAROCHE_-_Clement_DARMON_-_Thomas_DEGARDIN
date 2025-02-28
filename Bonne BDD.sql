DROP DATABASE IF EXISTS livinparis;
CREATE DATABASE IF NOT EXISTS livinparis;
USE livinparis;

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
   nomIngrédient VARCHAR(50),
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