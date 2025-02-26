CREATE TABLE Utilisateurs_(
   ID_utilisateur VARCHAR(50),
   nom VARCHAR(50),
   prénom VARCHAR(50),
   adresse VARCHAR(50),
   num_telephone VARCHAR(50),
   email VARCHAR(50),
   PRIMARY KEY(ID_utilisateur)
);

CREATE TABLE Client(
   ID_client VARCHAR(50),
   ID_utilisateur VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_client),
   UNIQUE(ID_utilisateur),
   FOREIGN KEY(ID_utilisateur) REFERENCES Utilisateurs_(ID_utilisateur)
);

CREATE TABLE Cuisinier(
   ID_cuisinier VARCHAR(50),
   ID_utilisateur VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_cuisinier),
   UNIQUE(ID_utilisateur),
   FOREIGN KEY(ID_utilisateur) REFERENCES Utilisateurs_(ID_utilisateur)
);

CREATE TABLE Commande(
   ID_commande VARCHAR(50),
   PrixCommande INT,
   Adresse_livraison VARCHAR(50),
   livraison BOOLEAN,
   ID_client VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_commande),
   FOREIGN KEY(ID_client) REFERENCES Client(ID_client)
);

CREATE TABLE Plat(
   ID_plat VARCHAR(50),
   nb_personne INT,
   dateperemption DATE,
   datefabrication DATE,
   prix INT,
   regime VARCHAR(50),
   nom_plat VARCHAR(50),
   Photo VARCHAR(50),
   ID_commande VARCHAR(50) NOT NULL,
   ID_cuisinier VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_plat),
   FOREIGN KEY(ID_commande) REFERENCES Commande(ID_commande),
   FOREIGN KEY(ID_cuisinier) REFERENCES Cuisinier(ID_cuisinier)
);

CREATE TABLE Ingrédients(
   Nom VARCHAR(50),
   ID_plat VARCHAR(50) NOT NULL,
   PRIMARY KEY(Nom),
   FOREIGN KEY(ID_plat) REFERENCES Plat(ID_plat)
);
