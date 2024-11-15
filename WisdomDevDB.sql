CREATE DATABASE WisdomDevDB;
GO 

USE WisdomDevDB;
GO

-- Tabla UsuarioCorriente
CREATE TABLE UsuarioEstudiante (
    idUsuarioEstudiante INT IDENTITY PRIMARY KEY,
	documentoIdentificacion VARCHAR(11),
    nombreCompleto VARCHAR(100),
    edad INT,
    telefono VARCHAR(10),
    genero VARCHAR(10),
    pais VARCHAR(25) DEFAULT 'Colombia',
    ciudad VARCHAR(25) DEFAULT 'Medellín'
);

-- Tabla UsuarioAdministrador
CREATE TABLE UsuarioAdministrador (
    idUsuarioAdministrador INT IDENTITY PRIMARY KEY,
	documentoIdentificacion VARCHAR(11),
    nombreCompleto VARCHAR(100),
    edad INT,
    telefono VARCHAR(10),
    genero VARCHAR(10),
    pais VARCHAR(25) DEFAULT 'Colombia',
    ciudad VARCHAR(25) DEFAULT 'Medellín',
);

-- Tabla CuentaCorriente
CREATE TABLE CuentaEstudiante (
    idCuentaEstudiante INT IDENTITY PRIMARY KEY,
	idUsuarioEstudiante INT,
	correo VARCHAR(100),
    contraseña VARCHAR(40),
    FOREIGN KEY(idUsuarioEstudiante) REFERENCES UsuarioEstudiante(idUsuarioEstudiante)
);

-- Tabla CuentaAdministrador
CREATE TABLE CuentaAdministrador (
    idCuentaAdministrador INT IDENTITY PRIMARY KEY,
	idUsuarioAdministrador INT,
	correo VARCHAR(100),
    contraseña VARCHAR(40)
    FOREIGN KEY(idUsuarioAdministrador) REFERENCES UsuarioAdministrador(idUsuarioAdministrador)
);

-- Tabla Ciclo
CREATE TABLE Ciclo (
	idCiclo INT IDENTITY PRIMARY KEY,
	nombreCiclo VARCHAR(25),
	descripcion VARCHAR(500)
);

-- Tabla Curso
CREATE TABLE Curso (
    idCurso INT IDENTITY PRIMARY KEY,
	idCiclo INT,
    nombreCurso VARCHAR(100),
	cargaHoraria VARCHAR(3),
	ultimaActualizacion DATE DEFAULT GETDATE(),
	autor VARCHAR(100),
	alumnos INT,
    descripcion VARCHAR(500),
	FOREIGN KEY(idCiclo) REFERENCES Ciclo(idCiclo)
);

-- Tabla CuentaCurso
CREATE TABLE CuentaCurso (
	idCuentaCurso INT IDENTITY PRIMARY KEY,
	idCuentaEstudiante INT,
	idCurso INT,
	estado VARCHAR(20),
	progreso INT DEFAULT 0,
	FOREIGN KEY(idCuentaEstudiante) REFERENCES CuentaEstudiante(idCuentaEstudiante),
	FOREIGN KEY(idCurso) REFERENCES Curso(idCurso)
);

-- Insertar datos
INSERT INTO UsuarioEstudiante(documentoIdentificacion, nombreCompleto, edad, telefono, genero)
VALUES 
('1020987654', 'Luis Ramírez', 20, '555-1234', 'Masculino'),
('1030654852', 'Andrea Gómez', 22, '555-5678', 'Femenino'),
('1010279642', 'Camila Martínez', 19, '555-8765', 'Femenino');

SELECT * FROM UsuarioEstudiante;

--
INSERT INTO UsuarioAdministrador(documentoIdentificacion, nombreCompleto, edad, telefono, genero)
VALUES 
('1020987123', 'Juan Álvarez', 22, '555-9871', 'Masculino'),
('1030654123', 'Jaider Ríos', 20, '555-7891', 'Masculino'),
('1010279123', 'Diego Romero', 19, '555-6541', 'Masculino');

SELECT * FROM UsuarioAdministrador;

--
INSERT INTO CuentaEstudiante (idUsuarioEstudiante, correo, contraseña)
VALUES 
(1, 'luis.ramirez@pascualbravo.edu.co', '1020987654'),
(2, 'andrea.gomez@pascualbravo.edu.co', '1030654852'),
(3, 'camila.martinez@pascualbravo.edu.co', '1010279642');

SELECT * FROM CuentaEstudiante;

--
INSERT INTO CuentaAdministrador (idUsuarioAdministrador, correo, contraseña)
VALUES 
(1, 'juan.alvarez@pascualbravo.edu.co', '1020987123'),
(2, 'jaider.rios@pascualbravo.edu.co', '1030654123'),
(3, 'diego.romero@pascualbravo.edu.co', '1010279123');

SELECT * FROM CuentaAdministrador;

--
INSERT INTO Ciclo (nombreCiclo, descripcion)
VALUES 
('Análisis', ''),
('Diseño', ''),
('Desarrollo', ''),
('Diseño', ''),
('Diseño', '');

SELECT * FROM Ciclo;

INSERT INTO Curso (idCiclo, nombreCurso, cargaHoraria, autor, alumnos, descripcion)
VALUES 
(1,'Requerimientos funcionales y no funcionales', '6h', 'Diego Romero', 0, 'Identificar y documentar las necesidades y requisitos del cliente. '),
(2,'Prototipado de UX/UI', '6h', 'Juan Alvarez', 0, ''),
(3,'Lógica de programación y buenas prácticas', '6h', 'Jaider Rios', 0, '');

SELECT * FROM Curso;