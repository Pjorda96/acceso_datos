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

-- Volcando datos para la tabla placemybet01.apuestas: ~10 rows (aproximadamente)
DELETE FROM `apuestas`;
/*!40000 ALTER TABLE `apuestas` DISABLE KEYS */;
INSERT INTO `apuestas` (`Id`, `Importe`, `Cuota`, `TipoApuesta`, `Fecha`, `UsuarioId`, `MercadoId`) VALUES
	(1, 10, 1.2, 0, '2019-10-19 19:28:49.000000', 1, 1),
	(2, 100, 1.5, 1, '2019-10-19 19:28:49.000000', 2, 2),
	(3, 20, 1.5, 0, '2019-10-19 19:39:09.000000', 1, 1),
	(4, 20, 1.5, 0, '2019-10-19 19:39:09.000000', 1, 1),
	(5, 20, 1.5, 1, '2019-10-19 19:39:09.000000', 1, 1),
	(6, 20, 1.5, 1, '2019-10-19 19:39:09.000000', 1, 1),
	(7, 20, 1.5, 1, '2019-10-19 19:39:09.000000', 1, 5),
	(8, 20, 1.5, 0, '2019-10-19 19:39:09.000000', 1, 5),
	(9, 20, 1.5, 0, '2019-10-19 19:39:09.000000', 1, 5),
	(10, 20, 1.5, 0, '2019-10-19 19:39:09.000000', 1, 5);
/*!40000 ALTER TABLE `apuestas` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet01.datosbancos: ~2 rows (aproximadamente)
DELETE FROM `datosbancos`;
/*!40000 ALTER TABLE `datosbancos` DISABLE KEYS */;
INSERT INTO `datosbancos` (`Id`, `Alias`, `Titular`, `Tipo`, `Numero`, `ExpTime`, `Cvv`, `UsuarioId`) VALUES
	(1, 'Tarjeta Black', 'Pablo Jorda Garcia', 1, '126443653', '2019-10-19 19:28:49.000000', 123, 1),
	(2, 'Visa Super Platino', 'Eugenio', 1, '1266443653', '2019-10-19 19:28:49.000000', 321, 2);
/*!40000 ALTER TABLE `datosbancos` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet01.mercados: ~5 rows (aproximadamente)
DELETE FROM `mercados`;
/*!40000 ALTER TABLE `mercados` DISABLE KEYS */;
INSERT INTO `mercados` (`Id`, `Tipo`, `CUnder`, `COver`, `PartidoId`) VALUES
	(1, 1, 1.9, 1.9, 1),
	(2, 2, 1.5, 2.5, 2),
	(3, 3, 1.5, 3, 1),
	(4, 4, 1.5, 3, 1),
	(5, 5, 3.8, 1.2666666666666666, 1);
/*!40000 ALTER TABLE `mercados` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet01.partidos: ~3 rows (aproximadamente)
DELETE FROM `partidos`;
/*!40000 ALTER TABLE `partidos` DISABLE KEYS */;
INSERT INTO `partidos` (`Id`, `Local`, `Visitante`, `Hora`) VALUES
	(1, 'Valencia', 'Barsa', '2019-10-19 19:28:49.000000'),
	(2, 'Madrid', 'Leganes', '2019-10-19 19:28:49.000000'),
	(3, 'Levante', 'Atletico de Madrid', '2019-10-19 19:28:49.000000');
/*!40000 ALTER TABLE `partidos` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet01.usuarios: ~2 rows (aproximadamente)
DELETE FROM `usuarios`;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`UsuarioId`, `DNI`, `Nombre`, `Apellidos`, `Email`, `BirtdhDate`, `Saldo`, `Active`) VALUES
	(1, '12345678B', 'Pablo', 'Jorda Garcia', 'pjorda96@gmail.com', '2019-10-19 19:28:49.000000', 0, b'0'),
	(2, '87654321A', 'Eugenio', 'Tio Uge', 'halleck@gmail.com', '2019-10-19 19:28:49.000000', 100, b'0');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

-- Volcando datos para la tabla placemybet01.__efmigrationshistory: ~2 rows (aproximadamente)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20191108155723_migration01', '2.2.6-servicing-10079'),
	('20191108161739_migration02', '2.2.6-servicing-10079');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
