CREATE DATABASE BD_TallerAutomotriz;
USE BD_TallerAutomotriz;

CREATE TABLE Refacciones(
CodigoBarras  VARCHAR(50) PRIMARY KEY NOT NULL,
Nombre VARCHAR(150),
Descripcion VARCHAR(250),
Marca VARCHAR(150),
Creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
Actualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

CREATE TABLE Herramientas(
CodigoHerramienta VARCHAR(50) PRIMARY KEY NOT NULL, 
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
  WHERE IdProducto=_IdProducto;
END;
//








