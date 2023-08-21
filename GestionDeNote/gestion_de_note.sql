-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : lun. 21 août 2023 à 03:56
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestion_de_note`
--

-- --------------------------------------------------------

--
-- Structure de la table `annees`
--

CREATE TABLE `annees` (
                          `idAnnee` int(11) NOT NULL,
                          `annee` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `annees`
--

INSERT INTO `annees` (`idAnnee`, `annee`) VALUES
    (1, '2022-2023');

-- --------------------------------------------------------

--
-- Structure de la table `classes`
--

CREATE TABLE `classes` (
                           `idClasse` int(11) NOT NULL,
                           `niveau` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `classes`
--

INSERT INTO `classes` (`idClasse`, `niveau`) VALUES
                                                 (1, 'Seconde'),
                                                 (2, 'Premiere'),
                                                 (3, 'Terminale');

-- --------------------------------------------------------

--
-- Structure de la table `coefficients`
--

CREATE TABLE `coefficients` (
                                `idCoeff` int(11) NOT NULL,
                                `coeff` int(11) NOT NULL,
                                `idSerie` int(11) NOT NULL,
                                `idMatiere` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `coefficients`
--

INSERT INTO `coefficients` (`idCoeff`, `coeff`, `idSerie`, `idMatiere`) VALUES
                                                                            (1, 3, 1, 1),
                                                                            (2, 3, 1, 2),
                                                                            (3, 3, 1, 3),
                                                                            (4, 3, 1, 4),
                                                                            (5, 3, 1, 5),
                                                                            (6, 2, 1, 6),
                                                                            (7, 3, 1, 7),
                                                                            (8, 3, 1, 8),
                                                                            (9, 2, 1, 9),
                                                                            (10, 4, 2, 1),
                                                                            (11, 4, 2, 2),
                                                                            (12, 3, 2, 3),
                                                                            (13, 3, 2, 4),
                                                                            (14, 2, 2, 5),
                                                                            (15, 3, 2, 6),
                                                                            (16, 3, 2, 7),
                                                                            (17, 3, 2, 8),
                                                                            (18, 2, 2, 9),
                                                                            (19, 3, 3, 1),
                                                                            (20, 3, 3, 2),
                                                                            (21, 3, 3, 3),
                                                                            (22, 3, 3, 4),
                                                                            (23, 3, 3, 5),
                                                                            (24, 3, 3, 6),
                                                                            (25, 3, 3, 7),
                                                                            (26, 3, 3, 8),
                                                                            (27, 2, 3, 9),
                                                                            (28, 3, 4, 1),
                                                                            (29, 3, 4, 2),
                                                                            (30, 3, 4, 3),
                                                                            (31, 3, 4, 4),
                                                                            (32, 3, 4, 5),
                                                                            (33, 3, 4, 6),
                                                                            (34, 3, 4, 7),
                                                                            (35, 3, 4, 8),
                                                                            (36, 2, 4, 9),
                                                                            (37, 3, 5, 1),
                                                                            (38, 3, 5, 2),
                                                                            (39, 3, 5, 3),
                                                                            (40, 3, 5, 4),
                                                                            (41, 3, 5, 5),
                                                                            (42, 3, 5, 6),
                                                                            (43, 3, 5, 7),
                                                                            (44, 3, 5, 8),
                                                                            (45, 2, 5, 9),
                                                                            (46, 3, 6, 1),
                                                                            (47, 3, 6, 2),
                                                                            (48, 3, 6, 3),
                                                                            (49, 3, 6, 4),
                                                                            (50, 3, 6, 5),
                                                                            (51, 3, 6, 6),
                                                                            (52, 3, 6, 7),
                                                                            (53, 3, 6, 8),
                                                                            (54, 2, 6, 9),
                                                                            (55, 3, 7, 1),
                                                                            (56, 3, 7, 2),
                                                                            (57, 3, 7, 3),
                                                                            (58, 3, 7, 4),
                                                                            (59, 3, 7, 5),
                                                                            (60, 3, 7, 6),
                                                                            (61, 3, 7, 7),
                                                                            (62, 3, 7, 8),
                                                                            (63, 2, 7, 9),
                                                                            (64, 3, 8, 1),
                                                                            (65, 3, 8, 2),
                                                                            (66, 5, 8, 3),
                                                                            (67, 5, 8, 4),
                                                                            (68, 3, 8, 5),
                                                                            (69, 3, 8, 6),
                                                                            (70, 3, 8, 7),
                                                                            (71, 3, 8, 8),
                                                                            (72, 2, 8, 9),
                                                                            (73, 6, 9, 1),
                                                                            (74, 6, 9, 2),
                                                                            (75, 3, 9, 3),
                                                                            (76, 3, 9, 4),
                                                                            (77, 3, 9, 5),
                                                                            (78, 3, 9, 6),
                                                                            (79, 3, 9, 7),
                                                                            (80, 3, 9, 8),
                                                                            (81, 2, 9, 9),
                                                                            (82, 3, 10, 1),
                                                                            (83, 3, 10, 2),
                                                                            (84, 3, 10, 3),
                                                                            (85, 3, 10, 4),
                                                                            (86, 3, 10, 5),
                                                                            (87, 3, 10, 6),
                                                                            (88, 3, 10, 7),
                                                                            (89, 3, 10, 8),
                                                                            (90, 2, 10, 9);

-- --------------------------------------------------------

--
-- Structure de la table `etudiants`
--

CREATE TABLE `etudiants` (
                             `matricule` varchar(15) NOT NULL,
                             `nom` varchar(100) NOT NULL,
                             `prenoms` varchar(100) NOT NULL,
                             `adresse` varchar(50) NOT NULL,
                             `email` varchar(50) NOT NULL,
                             `idSerie` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `etudiants`
--

INSERT INTO `etudiants` (`matricule`, `nom`, `prenoms`, `adresse`, `email`, `idSerie`) VALUES
                                                                                           ('001', 'Faly', 'Nirina', 'Tsaramandroso', 'antnfaly@gmail.com', 1),
                                                                                           ('002', 'Menja', 'Be', 'Ampopoka', 'zertyuiop', 1),
                                                                                           ('003', 'RAZAFINDRAFARA', 'Hasina', 'Anjoma', 'zrnn@gmail.com', 2),
                                                                                           ('004', 'Herizo', 'Niaina', 'Andrainjato', 'hero@gmail.com', 2),
                                                                                           ('005', 'Haja', 'toky', 'Atsahavola', 'haja@gmail.com', 10),
                                                                                           ('006', 'RAKOTO', 'Nandrianina', 'Anjoma', 'rakoto@gmail.com', 1),
                                                                                           ('007', 'MAHENINA', 'Andry', 'Talatamaty', 'andry@gmail.com', 9),
                                                                                           ('008', 'Saka', 'jonah', 'Tsaramandroso', 'jonah@gmail.com', 1);

-- --------------------------------------------------------

--
-- Structure de la table `matieres`
--

CREATE TABLE `matieres` (
                            `idMatiere` int(11) NOT NULL,
                            `nomMatiere` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `matieres`
--

INSERT INTO `matieres` (`idMatiere`, `nomMatiere`) VALUES
                                                       (1, 'Mathematique'),
                                                       (2, 'PC'),
                                                       (3, 'Francais'),
                                                       (4, 'Malagasy'),
                                                       (5, 'Anglais'),
                                                       (6, 'Philosophie'),
                                                       (7, 'Histoire-Geographie'),
                                                       (8, 'SVT'),
                                                       (9, 'EPS');

-- --------------------------------------------------------

--
-- Structure de la table `notes`
--

CREATE TABLE `notes` (
                         `idNote` int(11) NOT NULL,
                         `note` double NOT NULL,
                         `matricule` varchar(15) NOT NULL,
                         `idMatiere` int(11) NOT NULL,
                         `idPeriode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `periodes`
--

CREATE TABLE `periodes` (
                            `idPeriode` int(11) NOT NULL,
                            `idAnnee` int(11) NOT NULL,
                            `idTrimestre` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `periodes`
--

INSERT INTO `periodes` (`idPeriode`, `idAnnee`, `idTrimestre`) VALUES
                                                                   (1, 1, 1),
                                                                   (2, 1, 2),
                                                                   (3, 1, 3);

-- --------------------------------------------------------

--
-- Structure de la table `series`
--

CREATE TABLE `series` (
                          `idSerie` int(11) NOT NULL,
                          `nomSerie` varchar(50) NOT NULL,
                          `idClasse` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `series`
--

INSERT INTO `series` (`idSerie`, `nomSerie`, `idClasse`) VALUES
                                                             (1, 'Tronc Commun', 1),
                                                             (2, 'SCIENTIFIQUE', 2),
                                                             (3, 'LITTERAIRE', 2),
                                                             (4, 'A1', 3),
                                                             (5, 'A2', 3),
                                                             (6, 'C', 3),
                                                             (7, 'D', 3),
                                                             (8, 'L', 3),
                                                             (9, 'S', 3),
                                                             (10, 'OSE', 3);

-- --------------------------------------------------------

--
-- Structure de la table `trimestres`
--

CREATE TABLE `trimestres` (
                              `idTrimestre` int(11) NOT NULL,
                              `nomTrimestre` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `trimestres`
--

INSERT INTO `trimestres` (`idTrimestre`, `nomTrimestre`) VALUES
                                                             (1, 'Trimestre I'),
                                                             (2, 'Trimestre II'),
                                                             (3, 'Trimestre III');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `annees`
--
ALTER TABLE `annees`
    ADD PRIMARY KEY (`idAnnee`);

--
-- Index pour la table `classes`
--
ALTER TABLE `classes`
    ADD PRIMARY KEY (`idClasse`);

--
-- Index pour la table `coefficients`
--
ALTER TABLE `coefficients`
    ADD PRIMARY KEY (`idCoeff`),
    ADD KEY `idMatiere` (`idMatiere`),
    ADD KEY `idSerie` (`idSerie`);

--
-- Index pour la table `etudiants`
--
ALTER TABLE `etudiants`
    ADD PRIMARY KEY (`matricule`),
    ADD KEY `idSerie` (`idSerie`);

--
-- Index pour la table `matieres`
--
ALTER TABLE `matieres`
    ADD PRIMARY KEY (`idMatiere`);

--
-- Index pour la table `notes`
--
ALTER TABLE `notes`
    ADD PRIMARY KEY (`idNote`),
    ADD KEY `matricule` (`matricule`),
    ADD KEY `idMatiere` (`idMatiere`),
    ADD KEY `idPeriode` (`idPeriode`);

--
-- Index pour la table `periodes`
--
ALTER TABLE `periodes`
    ADD PRIMARY KEY (`idPeriode`),
    ADD KEY `idAnnee` (`idAnnee`),
    ADD KEY `idTrimestre` (`idTrimestre`);

--
-- Index pour la table `series`
--
ALTER TABLE `series`
    ADD PRIMARY KEY (`idSerie`),
    ADD KEY `idClasse` (`idClasse`);

--
-- Index pour la table `trimestres`
--
ALTER TABLE `trimestres`
    ADD PRIMARY KEY (`idTrimestre`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `coefficients`
--
ALTER TABLE `coefficients`
    MODIFY `idCoeff` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `coefficients`
--
ALTER TABLE `coefficients`
    ADD CONSTRAINT `coefficients_ibfk_1` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`),
    ADD CONSTRAINT `coefficients_ibfk_2` FOREIGN KEY (`idSerie`) REFERENCES `series` (`idSerie`);

--
-- Contraintes pour la table `etudiants`
--
ALTER TABLE `etudiants`
    ADD CONSTRAINT `etudiants_ibfk_1` FOREIGN KEY (`idSerie`) REFERENCES `series` (`idSerie`);

--
-- Contraintes pour la table `notes`
--
ALTER TABLE `notes`
    ADD CONSTRAINT `notes_ibfk_1` FOREIGN KEY (`matricule`) REFERENCES `etudiants` (`matricule`),
    ADD CONSTRAINT `notes_ibfk_2` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`),
    ADD CONSTRAINT `notes_ibfk_3` FOREIGN KEY (`idPeriode`) REFERENCES `periodes` (`idPeriode`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `periodes`
--
ALTER TABLE `periodes`
    ADD CONSTRAINT `periodes_ibfk_1` FOREIGN KEY (`idAnnee`) REFERENCES `annees` (`idAnnee`),
    ADD CONSTRAINT `periodes_ibfk_2` FOREIGN KEY (`idTrimestre`) REFERENCES `trimestres` (`idTrimestre`);

--
-- Contraintes pour la table `series`
--
ALTER TABLE `series`
    ADD CONSTRAINT `series_ibfk_1` FOREIGN KEY (`idClasse`) REFERENCES `classes` (`idClasse`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
