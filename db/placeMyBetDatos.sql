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

-- Volcando datos para la tabla placemybet.apuesta: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `apuesta` DISABLE KEYS */;
REPLACE INTO `apuesta` (`id`, `usuario`, `importe`, `mercado`, `cuota`, `tipoApuesta`, `fecha`) VALUES
	(1, 1, 10, 2, 1.9, 1, '2019-10-19 19:39:09');
/*!40000 ALTER TABLE `apuesta` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet.datos_banco: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `datos_banco` DISABLE KEYS */;
/*!40000 ALTER TABLE `datos_banco` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet.mercado: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `mercado` DISABLE KEYS */;
REPLACE INTO `mercado` (`id`, `partido`, `tipo`, `cOver`, `cUnder`) VALUES
	(1, 1, 1.5, 1.5, 3),
	(2, 1, 2.5, 1.9, 1.9),
	(3, 1, 3.5, 3, 1.5);
/*!40000 ALTER TABLE `mercado` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet.partido: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `partido` DISABLE KEYS */;
REPLACE INTO `partido` (`id`, `local`, `visitante`, `hora`) VALUES
	(1, 'Valencia', 'Madrid', '2019-10-19 19:25:28'),
	(2, 'Real Madrid', 'Farça', '2019-10-19 19:25:28'),
	(3, 'sfgjmy', 'zdfgmn', '2019-10-19 19:25:28'),
	(4, 'Sevilla', 'Betis', '2019-10-19 19:25:28'),
	(5, 'Villa-Real', 'Getafe', '0000-00-00 00:00:00');
/*!40000 ALTER TABLE `partido` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet.usuario: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
REPLACE INTO `usuario` (`id`, `dni`, `nombre`, `apellidos`, `email`, `birdth_date`, `saldo`, `active`) VALUES
	(1, '12345678\r\n', 'Pablo', 'Jorda', 'email@email.com', '2019-10-19 19:28:49', 10, 0);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
