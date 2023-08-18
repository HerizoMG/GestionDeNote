-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 18 août 2023 à 15:25
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
-- Base de données : `testeee`
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
                                              (1, '2022-2023'),
                                              (2, '2023-2024');

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
                                                                            (9, 2, 1, 9);

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
                             `idSerie` int(11) NOT NULL,
                             `idPeriode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `etudiants`
--

INSERT INTO `etudiants` (`matricule`, `nom`, `prenoms`, `adresse`, `email`, `idSerie`, `idPeriode`) VALUES
                                                                                                        ('001', 'string', 'string', 'string', 'string', 1, 1),
                                                                                                        ('002', 'azertyu', 'qsdfgh,', 'xcvbn', 'zertyuiop', 1, 1);

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
                         `idMatiere` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `notes`
--

INSERT INTO `notes` (`idNote`, `note`, `matricule`, `idMatiere`) VALUES
    (1, 12, '002', 1);

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
                                                                   (0, 1, 1),
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
                                                             (2, 'S', 2),
                                                             (3, 'L', 2),
                                                             (4, 'A1', 3);

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
    ADD KEY `idSerie` (`idSerie`),
    ADD KEY `idPeriode` (`idPeriode`);

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
    ADD KEY `idMatiere` (`idMatiere`);

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
    ADD CONSTRAINT `etudiants_ibfk_1` FOREIGN KEY (`idSerie`) REFERENCES `series` (`idSerie`),
    ADD CONSTRAINT `etudiants_ibfk_2` FOREIGN KEY (`idPeriode`) REFERENCES `periodes` (`idPeriode`);

--
-- Contraintes pour la table `notes`
--
ALTER TABLE `notes`
    ADD CONSTRAINT `notes_ibfk_1` FOREIGN KEY (`matricule`) REFERENCES `etudiants` (`matricule`),
    ADD CONSTRAINT `notes_ibfk_2` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`);

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
