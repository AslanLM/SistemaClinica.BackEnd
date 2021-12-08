
CREATE DATABASE Clinica
GO

USE Clinica
GO

--Error de sintaxis: Sintaxis incorrecta cerca de CREATE.
--Error de sintaxis: Sintaxis incorrecta cerca de PROCEDURE.
--EXEC sp_addextendedproperty 
--	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
--   	@level0type = N'Schema',	@level0name = 'dbo',
--   	@level1type = N'Table',		@level1name = 'Doctores', 
--   	@level2type = N'Column',	@level2name = 'ModificadoPor'
--
--
--CREATE PROCEDURE SP_Doctores_Insertar
--	@CedulaDoctor VARCHAR(12),
--	@NombreDoctor VARCHAR(40),
--	@Apellidos VARCHAR(60),
--	@Telefono VARCHAR(12),
--	@CreadoPor VARCHAR(60)
--AS
--BEGIN
--	INSERT INTO Doctores 
--		(CedulaDoctor, NombreDoctor, Apellidos, Telefono, CreadoPor)
--	VALUES 
--		(@CedulaDoctor,	@NombreDoctor, @Apellidos, @Telefono, @CreadoPor)
--END



GO
