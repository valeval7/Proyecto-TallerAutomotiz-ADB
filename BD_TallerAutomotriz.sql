CREATE DATABASE BD_TallerAutomotriz;
USE BD_TallerAutomotriz;

CREATE TABLE Refacciones(
IdR INT PRIMARY KEY AUTO_INCREMENT,
CodigoBarras  VARCHAR(50),
Nombre VARCHAR(150),
Descripcion VARCHAR(250),
Marca VARCHAR(150),
Creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
Actualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE Herramientas(
IdH INT PRIMARY KEY AUTO_INCREMENT,
CodigoHerramienta VARCHAR(50), 
Nombre VARCHAR(150), 
Medida VARCHAR(150), 
Marca VARCHAR(150), 
Descripcion VARCHAR(250),
Creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
Actualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE Usuarios(
idusuario INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
Nombre VARCHAR(100), 
apellidopaterno VARCHAR(100), 
apellidomaterno VARCHAR(100),
fechanacimiento DATETIME,
rfc VARCHAR(11),
NickName VARCHAR(50),
Tipo ENUM('Nivel 1', 'Nivel 2'),
Formulario ENUM('Refacciones','Herramientas', 'Refacciones y Herramientas', 'Administrador'),
Clave VARCHAR(255)
);
SELECT * FROM usuarios;

INSERT INTO usuarios (IdUsuario, Nombre, apellidopaterno, apellidomaterno, fechanacimiento, rfc, NickName, Tipo, Formulario, Clave) 
VALUES (NULL, 'Valeria','Macias', 'Gonzalez', '2004-05-07', 'MAGV0705NR5', 'vmg', 1, 4, SHA1('1234'));


DELIMITER //
CREATE PROCEDURE p_ValidarU
(
   IN _NickName VARCHAR(50), 
   IN _Clave VARCHAR(255)
)
BEGIN
    DECLARE x INT;
    SELECT COUNT(*) FROM Usuarios WHERE NickName=_NickName  AND Clave=_Clave INTO x;
    if X>0 then
    SELECT 'C0rr3cto' AS rs , (SELECT Tipo FROM Usuarios WHERE NickName=_NickName AND Clave=_Clave) AS tipo,
	 (SELECT Formulario FROM Usuarios WHERE NickName=_NickName AND Clave=_Clave) AS formulario;
	 
    ELSE
    SELECT 'Error' AS rs, 0 AS Tipo;
    END if;
END // 
DELIMITER ;
CALL p_ValidarU('vmg', SHA1('1234'));


DELIMITER //
CREATE PROCEDURE p_EliminarUser
(
   IN _IdUsuario INT
)
BEGIN
   DELETE FROM Usuarios WHERE IdUsuario=_IdUsuario;
END;
//

DELIMITER //
CREATE PROCEDURE p_ModificarUser
(
   IN _IdUsuario INT,
   IN _Nombre VARCHAR(100), 
   IN _apellidopaterno VARCHAR(100), 
   IN _apellidomaterno VARCHAR(100),
   IN _fechanacimiento DATETIME,
   IN _rfc VARCHAR(11),
   IN _NickName VARCHAR(50),
   IN _Tipo ENUM('Nivel 1', 'Nivel 2'),
   IN _Formulario ENUM('Refacciones','Herramientas', 'Refacciones y Herramientas', 'Administrador'),
   IN _Clave VARCHAR(255)
)
BEGIN 
  UPDATE Usuarios 
  SET
  Nombre=_Nombre,
  apellidopaterno = _apellidopaterno, 
  apellidomaterno= _apellidomaterno,
  fechanacimiento= _fechanacimiento,
  rfc = _rfc,
  NickName = _NickName,
  Tipo =_Tipo,
  Formulario = _Formulario,
  Clave = _Clave
  WHERE _IdUsuario = IdUsuario;
END;
//


DELIMITER //
CREATE PROCEDURE p_ModificarHerramientas
(
	IN _IdH INT,
	IN  _CodigoHerramienta VARCHAR(50), 
	IN _Nombre VARCHAR(150), 
	IN _Medida VARCHAR(150), 
	IN _Marca VARCHAR(150), 
 	IN _Descripcion VARCHAR(250)
)
BEGIN 
  UPDATE herramientas
  SET
  CodigoHerramienta = _CodigoHerramienta,
  Nombre = _Nombre, 
  Medida= _Medida,
  Marca= _Marca,
  Descripcion = _Descripcion
  WHERE IdH = _idH;
END;
//



DELIMITER //
CREATE PROCEDURE p_EliminarHerramienta
(
   IN _IdH VARCHAR(50)
)
BEGIN
   DELETE FROM herramientas WHERE idH=_IdH;
END;
//



DELIMITER //
CREATE PROCEDURE p_ModificarRefacciones
(
	IN _IdR INT,
	IN  _CodigoBarras VARCHAR(50), 
	IN _Nombre VARCHAR(150), 
	IN _Descripcion VARCHAR(250),
	IN _Marca VARCHAR(150)
)
BEGIN 
  UPDATE Refacciones
  SET
  CodigoBarras = _CodigoBarras,
  Nombre = _Nombre, 
  descricion= _Medida,
  marca= _Marca
  WHERE IdR = _IdR;
END;
//



DELIMITER //
CREATE PROCEDURE p_EliminarRefacciones
(
   IN _CodigoBarras VARCHAR(50)
)
BEGIN
   DELETE FROM Refacciones WHERE CodigoBarras=_CodigoBarras;
END;
//

