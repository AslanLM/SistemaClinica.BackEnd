CREATE PROCEDURE SP_Doctores_Insertar
	@CedulaDoctor VARCHAR(12),
	@NombreDoctor VARCHAR(40),
	@Apellidos VARCHAR(60),
	@Telefono VARCHAR(12),
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Doctores 
		(CedulaDoctor, NombreDoctor, Apellidos, Telefono, CreadoPor)
	VALUES 
		(@CedulaDoctor,	@NombreDoctor, @Apellidos, @Telefono, @CreadoPor)
END

