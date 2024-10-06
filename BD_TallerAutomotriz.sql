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
nombre VARCHAR(100), 
apellidopaterno VARCHAR(100), 
apellidomaterno VARCHAR(100),
fechanacimiento DATETIME,
rfc VARCHAR(11)
);

CREATE TABLE LoginUsuarios(
NickName VARCHAR(50),
Tipo ENUM('Administrador','Nivel 1', 'Nivel 2'),
Formulario ENUM('Refacciones','Herramientas', 'Refacciones y Herramientas', 'Administrar'),
Clave VARCHAR(255),
IdUsuario INT PRIMARY KEY, 
FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);

DELIMITER //
CREATE PROCEDURE p_ValidarU
(
   IN _NickName VARCHAR(50), 
   IN _Clave VARCHAR(255)
)
BEGIN
    DECLARE x INT;
    SELECT COUNT(*) FROM LoginUsuarios WHERE NickName=_NickName  AND Clave=_Clave INTO x;
    if X>0 then
    SELECT 'C0rr3cto' AS rs , (SELECT Tipo FROM LoginUsuarios WHERE NickName=_NickName AND Clave=_Clave) AS tipo,
	 (SELECT Formulario FROM LoginUsuarios WHERE NickName=_NickName AND Clave=_Clave) AS Formulario;
    ELSE
    SELECT 'Error' AS rs, 0 AS Tipo;
    END if;
END // 
DELIMITER ;









