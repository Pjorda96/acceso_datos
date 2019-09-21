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


-- Volcando estructura de base de datos para dam
CREATE DATABASE IF NOT EXISTS `dam` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */;
USE `dam`;

-- Volcando estructura para tabla dam.apuesta
CREATE TABLE IF NOT EXISTS `apuesta` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mercado` int(11) NOT NULL,
  `cuota` double NOT NULL,
  `boleto` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `boleto` (`boleto`),
  KEY `mercado_fk` (`mercado`),
  CONSTRAINT `mercado_fk` FOREIGN KEY (`mercado`) REFERENCES `mercado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.apuesta: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `apuesta` DISABLE KEYS */;
/*!40000 ALTER TABLE `apuesta` ENABLE KEYS */;

-- Volcando estructura para tabla dam.boleto
CREATE TABLE IF NOT EXISTS `boleto` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `usuario` int(11) unsigned NOT NULL,
  `importe` double NOT NULL,
  `fecha` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_fk` (`usuario`),
  CONSTRAINT `usuario_fk` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.boleto: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `boleto` DISABLE KEYS */;
INSERT INTO `boleto` (`id`, `usuario`, `importe`, `fecha`) VALUES
	(4, 1, 10, '2019-09-21 12:05:52');
/*!40000 ALTER TABLE `boleto` ENABLE KEYS */;

-- Volcando estructura para tabla dam.datos_banco
CREATE TABLE IF NOT EXISTS `datos_banco` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `alias` varchar(50) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `titular` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `tipo` int(10) unsigned NOT NULL,
  `numero` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `exp_time` date DEFAULT NULL,
  `cvv` smallint(3) unsigned DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.datos_banco: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `datos_banco` DISABLE KEYS */;
INSERT INTO `datos_banco` (`id`, `alias`, `titular`, `tipo`, `numero`, `exp_time`, `cvv`) VALUES
	(1, 'Tarjeta', 'Titulat¡r tarjeta', 1, '1234567890123456', '2019-09-21', 123),
	(2, 'Cuenta', 'Titular cuenta', 2, 'ES0049 2352 08 2414205416', '0000-00-00', NULL);
/*!40000 ALTER TABLE `datos_banco` ENABLE KEYS */;

-- Volcando estructura para tabla dam.mercado
CREATE TABLE IF NOT EXISTS `mercado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `partido` int(11) NOT NULL,
  `tipo` int(10) unsigned NOT NULL,
  `c. over` double unsigned NOT NULL,
  `c. under` double unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `partido_fk` (`partido`),
  CONSTRAINT `partido_fk` FOREIGN KEY (`partido`) REFERENCES `partido` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.mercado: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `mercado` DISABLE KEYS */;
INSERT INTO `mercado` (`id`, `partido`, `tipo`, `c. over`, `c. under`) VALUES
	(1, 1, 1, 1.12, 12),
	(2, 1, 2, 1.5, 10),
	(3, 1, 3, 1.8, 5),
	(4, 1, 4, 3, 2),
	(5, 1, 5, 10, 1.5),
	(6, 1, 6, 12, 1.12);
/*!40000 ALTER TABLE `mercado` ENABLE KEYS */;

-- Volcando estructura para tabla dam.partido
CREATE TABLE IF NOT EXISTS `partido` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `local` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `visitante` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `hora` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.partido: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `partido` DISABLE KEYS */;
INSERT INTO `partido` (`id`, `local`, `visitante`, `hora`) VALUES
	(1, 'Valencia', 'Levante', '2019-09-21 11:28:32');
/*!40000 ALTER TABLE `partido` ENABLE KEYS */;

-- Volcando estructura para tabla dam.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `dni` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `nombre` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `apellidos` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `email` varchar(50) COLLATE utf8mb4_spanish_ci NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `saldo` double NOT NULL DEFAULT '0',
  `datos_banco` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `datos_banco_fk` (`datos_banco`),
  CONSTRAINT `datos_banco_fk` FOREIGN KEY (`datos_banco`) REFERENCES `datos_banco` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- Volcando datos para la tabla dam.usuario: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`id`, `dni`, `nombre`, `apellidos`, `email`, `fecha_nacimiento`, `saldo`, `datos_banco`) VALUES
	(1, '12345678a', 'Nombre', 'Apellido Apellido', 'email@emaail.com', '2019-09-21', 0, 1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
