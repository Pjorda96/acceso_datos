-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.1.26-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win32
-- HeidiSQL Versión:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para placemybet
CREATE DATABASE IF NOT EXISTS `placemybet` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;
USE `placemybet`;

-- Volcando estructura para tabla placemybet.apuesta
CREATE TABLE IF NOT EXISTS `apuesta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` int(11) NOT NULL,
  `importe` double NOT NULL,
  `mercado` int(11) NOT NULL,
  `cuota` double NOT NULL,
  `tipo` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `apuesta_usuario_fk` (`usuario`),
  KEY `mercado_fk` (`mercado`),
  CONSTRAINT `apuesta_usuario_fk` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`id`),
  CONSTRAINT `mercado_fk` FOREIGN KEY (`mercado`) REFERENCES `mercado` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla placemybet.datos_banco
CREATE TABLE IF NOT EXISTS `datos_banco` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `alias` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `titular` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tipo` int(11) NOT NULL DEFAULT '0',
  `numero` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `exp_time` datetime DEFAULT NULL,
  `cvv` int(11) DEFAULT NULL,
  `usuario` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_fk` (`usuario`),
  CONSTRAINT `usuario_fk` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla placemybet.mercado
CREATE TABLE IF NOT EXISTS `mercado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `partido` int(11) NOT NULL,
  `tipo` double NOT NULL,
  `cOver` double NOT NULL DEFAULT '0',
  `cUnder` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `partido_fk` (`partido`),
  CONSTRAINT `partido_fk` FOREIGN KEY (`partido`) REFERENCES `partido` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla placemybet.partido
CREATE TABLE IF NOT EXISTS `partido` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `local` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `visitante` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `hora` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- La exportación de datos fue deseleccionada.
-- Volcando estructura para tabla placemybet.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dni` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nombre` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `apellidos` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `birdth_date` datetime NOT NULL,
  `saldo` double NOT NULL DEFAULT '0',
  `active` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- La exportación de datos fue deseleccionada.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
