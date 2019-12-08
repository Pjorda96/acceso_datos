-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.1.26-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win32
-- HeidiSQL Versión:             10.2.0.5599
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
  `tipoApuesta` int(11) NOT NULL,
  `fecha` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `apuesta_usuario_fk` (`usuario`),
  KEY `mercado_fk` (`mercado`),
  CONSTRAINT `apuesta_usuario_fk` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`id`),
  CONSTRAINT `mercado_fk` FOREIGN KEY (`mercado`) REFERENCES `mercado` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla placemybet.apuesta: ~0 rows (aproximadamente)
DELETE FROM `apuesta`;
/*!40000 ALTER TABLE `apuesta` DISABLE KEYS */;
INSERT INTO `apuesta` (`id`, `usuario`, `importe`, `mercado`, `cuota`, `tipoApuesta`, `fecha`) VALUES
	(1, 1, 10, 2, 1.9, 1, '2019-10-19 19:39:09');
/*!40000 ALTER TABLE `apuesta` ENABLE KEYS */;

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

-- Volcando datos para la tabla placemybet.datos_banco: ~0 rows (aproximadamente)
DELETE FROM `datos_banco`;
/*!40000 ALTER TABLE `datos_banco` DISABLE KEYS */;
/*!40000 ALTER TABLE `datos_banco` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla placemybet.mercado: ~3 rows (aproximadamente)
DELETE FROM `mercado`;
/*!40000 ALTER TABLE `mercado` DISABLE KEYS */;
INSERT INTO `mercado` (`id`, `partido`, `tipo`, `cOver`, `cUnder`) VALUES
	(1, 1, 1.5, 1.5, 3),
	(2, 1, 2.5, 1.9, 1.9),
	(3, 1, 3.5, 3, 1.5);
/*!40000 ALTER TABLE `mercado` ENABLE KEYS */;

-- Volcando estructura para tabla placemybet.partido
CREATE TABLE IF NOT EXISTS `partido` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `local` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `visitante` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `hora` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla placemybet.partido: ~0 rows (aproximadamente)
DELETE FROM `partido`;
/*!40000 ALTER TABLE `partido` DISABLE KEYS */;
INSERT INTO `partido` (`id`, `local`, `visitante`, `hora`) VALUES
	(1, 'Valencia', 'Madrid', '2019-10-19 19:25:28'),
	(2, 'Real Madrid', 'Farça', '2019-10-19 19:25:28'),
	(3, 'sfgjmy', 'zdfgmn', '2019-10-19 19:25:28'),
	(4, 'Sevilla', 'Betis', '2019-10-19 19:25:28'),
	(5, 'Villa-Real', 'Getafe', '0000-00-00 00:00:00');
/*!40000 ALTER TABLE `partido` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Volcando datos para la tabla placemybet.usuario: ~0 rows (aproximadamente)
DELETE FROM `usuario`;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`id`, `dni`, `nombre`, `apellidos`, `email`, `birdth_date`, `saldo`, `active`) VALUES
	(1, '12345678\r\n', 'Pablo', 'Jorda', 'email@email.com', '2019-10-19 19:28:49', 10, 0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
