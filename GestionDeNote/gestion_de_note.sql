-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 17 août 2023 à 07:26
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
-- Structure de la table `classes`
--

CREATE TABLE `classes` (
  `ID_classe` varchar(10) NOT NULL,
  `niveau` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `classes`
--

INSERT INTO `classes` (`ID_classe`, `niveau`) VALUES
('1', 'Seconde'),
('2', 'Premiere'),
('3', 'Terminale');

-- --------------------------------------------------------

--
-- Structure de la table `etudiants`
--

CREATE TABLE `etudiants` (
  `num_matricule` varchar(15) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prenoms` varchar(50) DEFAULT NULL,
  `adresse` varchar(30) DEFAULT NULL,
  `mail` varchar(48) DEFAULT NULL,
  `num_serie` varchar(10) NOT NULL,
  `ID_classe` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `matieres`
--

CREATE TABLE `matieres` (
  `num_matiere` varchar(35) NOT NULL,
  `nom_matiere` varchar(35) DEFAULT NULL,
  `coefficient` varchar(2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `matieres`
--

INSERT INTO `matieres` (`num_matiere`, `nom_matiere`, `coefficient`) VALUES
('2', NULL, '3');

-- --------------------------------------------------------

--
-- Structure de la table `posseders`
--

CREATE TABLE `posseders` (
  `num_matricule` varchar(15) NOT NULL,
  `num_matiere` varchar(35) NOT NULL,
  `num_trimestre` varchar(3) NOT NULL,
  `note` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `series`
--

CREATE TABLE `series` (
  `num_serie` varchar(10) NOT NULL,
  `nom_serie` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `series`
--

INSERT INTO `series` (`num_serie`, `nom_serie`) VALUES
('1', 'A1'),
('2', 'A2'),
('3', 'C'),
('4', 'D'),
('5', 'L'),
('6', 'S'),
('7', 'OSE');

-- --------------------------------------------------------

--
-- Structure de la table `trimestres`
--

CREATE TABLE `trimestres` (
  `ID_annee_scolaire` varchar(20) DEFAULT NULL,
  `num_trimestre` varchar(3) NOT NULL,
  `nom_trimestre` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`ID_classe`);

--
-- Index pour la table `etudiants`
--
ALTER TABLE `etudiants`
  ADD PRIMARY KEY (`num_matricule`),
  ADD KEY `ID_classe` (`ID_classe`),
  ADD KEY `num_serie` (`num_serie`);

--
-- Index pour la table `matieres`
--
ALTER TABLE `matieres`
  ADD PRIMARY KEY (`num_matiere`);

--
-- Index pour la table `posseders`
--
ALTER TABLE `posseders`
  ADD PRIMARY KEY (`num_matricule`,`num_matiere`,`num_trimestre`),
  ADD KEY `num_matiere` (`num_matiere`),
  ADD KEY `num_trimestre` (`num_trimestre`);

--
-- Index pour la table `series`
--
ALTER TABLE `series`
  ADD PRIMARY KEY (`num_serie`);

--
-- Index pour la table `trimestres`
--
ALTER TABLE `trimestres`
  ADD PRIMARY KEY (`num_trimestre`);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `etudiants`
--
ALTER TABLE `etudiants`
  ADD CONSTRAINT `etudiants_ibfk_1` FOREIGN KEY (`ID_classe`) REFERENCES `classes` (`ID_classe`),
  ADD CONSTRAINT `etudiants_ibfk_2` FOREIGN KEY (`num_serie`) REFERENCES `series` (`num_serie`);

--
-- Contraintes pour la table `posseders`
--
ALTER TABLE `posseders`
  ADD CONSTRAINT `posseders_ibfk_1` FOREIGN KEY (`num_matricule`) REFERENCES `etudiants` (`num_matricule`),
  ADD CONSTRAINT `posseders_ibfk_2` FOREIGN KEY (`num_matiere`) REFERENCES `matieres` (`num_matiere`),
  ADD CONSTRAINT `posseders_ibfk_3` FOREIGN KEY (`num_trimestre`) REFERENCES `trimestres` (`num_trimestre`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
