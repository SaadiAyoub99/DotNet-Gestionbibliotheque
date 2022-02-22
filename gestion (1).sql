-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost
-- Généré le : mar. 22 fév. 2022 à 14:47
-- Version du serveur :  10.4.17-MariaDB
-- Version de PHP : 7.3.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestion`
--

-- --------------------------------------------------------

--
-- Structure de la table `cd`
--

CREATE TABLE `cd` (
  `id_cd` int(200) NOT NULL,
  `titre` varchar(200) NOT NULL,
  `auteur` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `cd`
--

INSERT INTO `cd` (`id_cd`, `titre`, `auteur`) VALUES
(8, 'Album Black Star', 'Mitalika'),
(9, 'Mixtape Nord', 'Ultras'),
(11, 'Ep - Alien', 'Inkonnu');

-- --------------------------------------------------------

--
-- Structure de la table `emprunt`
--

CREATE TABLE `emprunt` (
  `id_em` int(200) NOT NULL,
  `date_emprunt` date NOT NULL,
  `Periode_emprunt` varchar(200) NOT NULL,
  `nom_ouvrage` varchar(200) NOT NULL,
  `nom_client` varchar(100) NOT NULL,
  `cin` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `emprunt`
--

INSERT INTO `emprunt` (`id_em`, `date_emprunt`, `Periode_emprunt`, `nom_ouvrage`, `nom_client`, `cin`) VALUES
(16, '2021-12-27', '15', 'Marvel', 'Tahiri Mohamed ', 'EE123654'),
(17, '2021-11-10', '7', 'Mixtape Nord', 'simo', 'SH123');

-- --------------------------------------------------------

--
-- Structure de la table `livre`
--

CREATE TABLE `livre` (
  `id_livre` int(200) NOT NULL,
  `titre` varchar(20) NOT NULL,
  `auteur` varchar(200) NOT NULL,
  `editeur` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `livre`
--

INSERT INTO `livre` (`id_livre`, `titre`, `auteur`, `editeur`) VALUES
(12, 'World football', 'awad', 'Mohamed'),
(13, 'Marvel', ' brose calven', 'steve nike'),
(14, 'La mémoire d\'un roi', 'Eric Lamela', 'Eddriss brahim'),
(16, 'La mémoire d\'un roi', 'Eric Lamela', 'Eddriss brahim');

-- --------------------------------------------------------

--
-- Structure de la table `periodique`
--

CREATE TABLE `periodique` (
  `id_p` int(200) NOT NULL,
  `Nom` varchar(200) NOT NULL,
  `periodicite` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `periodique`
--

INSERT INTO `periodique` (`id_p`, `Nom`, `periodicite`) VALUES
(8, 'Daily Mirror', 'Hebdo'),
(9, 'Mondo deportivo', 'Quotidien'),
(10, 'Marca', 'Quotidient'),
(11, 'The Telegraf', 'Mensuel'),
(12, 'France Football', 'Annuel');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cd`
--
ALTER TABLE `cd`
  ADD PRIMARY KEY (`id_cd`);

--
-- Index pour la table `emprunt`
--
ALTER TABLE `emprunt`
  ADD PRIMARY KEY (`id_em`);

--
-- Index pour la table `livre`
--
ALTER TABLE `livre`
  ADD PRIMARY KEY (`id_livre`);

--
-- Index pour la table `periodique`
--
ALTER TABLE `periodique`
  ADD PRIMARY KEY (`id_p`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cd`
--
ALTER TABLE `cd`
  MODIFY `id_cd` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT pour la table `emprunt`
--
ALTER TABLE `emprunt`
  MODIFY `id_em` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pour la table `livre`
--
ALTER TABLE `livre`
  MODIFY `id_livre` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT pour la table `periodique`
--
ALTER TABLE `periodique`
  MODIFY `id_p` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
