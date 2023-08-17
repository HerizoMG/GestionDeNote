-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 17 août 2023 à 23:36
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
                          `idAnnee` int(5) NOT NULL,
                          `annee` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `classes`
--

CREATE TABLE `classes` (
                           `idClasse` int(5) NOT NULL,
                           `niveau` varchar(35) DEFAULT NULL
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
-- Structure de la table `etudiants`
--

CREATE TABLE `etudiants` (
                             `matricule` varchar(15) NOT NULL,
                             `nom` varchar(50) NOT NULL,
                             `prenoms` varchar(50) NOT NULL,
                             `adresse` varchar(30) NOT NULL,
                             `mail` varchar(40) NOT NULL,
                             `idClasse` int(5) NOT NULL,
                             `numSerie` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `etudiants`
--

INSERT INTO `etudiants` (`matricule`, `nom`, `prenoms`, `adresse`, `mail`, `idClasse`, `numSerie`) VALUES
                                                                                                       ('1', 'hasina', 'kely', 'ihosy', 'bara@gmail.com', 3, 1),
                                                                                                       ('2', 'string', 'string', 'string', 'string', 2, 2),
                                                                                                       ('3', 'string', 'string', 'string', 'string', 1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `matieres`
--

CREATE TABLE `matieres` (
                            `idMatiere` int(5) NOT NULL,
                            `nomMatiere` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `notes`
--

CREATE TABLE `notes` (
                         `idNote` int(5) NOT NULL,
                         `note` double NOT NULL,
                         `coefficient` int(5) NOT NULL,
                         `matricule` varchar(15) NOT NULL,
                         `idMatiere` int(5) NOT NULL,
                         `idAnneeScolaire` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `periodes`
--

CREATE TABLE `periodes` (
                            `idAnneeScolaire` int(5) NOT NULL,
                            `idAnnee` int(5) NOT NULL,
                            `numTrimestre` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `series`
--

CREATE TABLE `series` (
                          `numSerie` int(5) NOT NULL,
                          `nomSerie` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `series`
--

INSERT INTO `series` (`numSerie`, `nomSerie`) VALUES
                                                  (1, 'A1'),
                                                  (2, 'A2');

-- --------------------------------------------------------

--
-- Structure de la table `trimestres`
--

CREATE TABLE `trimestres` (
                              `numTrimestre` int(5) NOT NULL,
                              `nomTrimestre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
-- Index pour la table `etudiants`
--
ALTER TABLE `etudiants`
    ADD PRIMARY KEY (`matricule`),
  ADD KEY `idClasse` (`idClasse`),
  ADD KEY `numSerie` (`numSerie`);

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
  ADD KEY `idAnneeScolaire` (`idAnneeScolaire`),
  ADD KEY `idMatiere` (`idMatiere`);

--
-- Index pour la table `periodes`
--
ALTER TABLE `periodes`
    ADD PRIMARY KEY (`idAnneeScolaire`),
  ADD KEY `idAnnee` (`idAnnee`),
  ADD KEY `numTrimestre` (`numTrimestre`);

--
-- Index pour la table `series`
--
ALTER TABLE `series`
    ADD PRIMARY KEY (`numSerie`);

--
-- Index pour la table `trimestres`
--
ALTER TABLE `trimestres`
    ADD PRIMARY KEY (`numTrimestre`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `etudiants`
--
ALTER TABLE `etudiants`
    ADD CONSTRAINT `etudiants_ibfk_1` FOREIGN KEY (`idClasse`) REFERENCES `classes` (`idClasse`),
  ADD CONSTRAINT `etudiants_ibfk_2` FOREIGN KEY (`numSerie`) REFERENCES `series` (`numSerie`);

--
-- Contraintes pour la table `notes`
--
ALTER TABLE `notes`
    ADD CONSTRAINT `notes_ibfk_1` FOREIGN KEY (`matricule`) REFERENCES `etudiants` (`matricule`),
  ADD CONSTRAINT `notes_ibfk_2` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`),
  ADD CONSTRAINT `notes_ibfk_3` FOREIGN KEY (`idAnneeScolaire`) REFERENCES `periodes` (`idAnneeScolaire`),
  ADD CONSTRAINT `notes_ibfk_4` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`);

--
-- Contraintes pour la table `periodes`
--
ALTER TABLE `periodes`
    ADD CONSTRAINT `periodes_ibfk_1` FOREIGN KEY (`idAnnee`) REFERENCES `annees` (`idAnnee`),
  ADD CONSTRAINT `periodes_ibfk_2` FOREIGN KEY (`numTrimestre`) REFERENCES `trimestres` (`numTrimestre`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
