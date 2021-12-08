CREATE PROCEDURE SP_Pacientes_Insertar
	@CedulaPaciente VARCHAR(12),
	@NombrePaciente VARCHAR(40),
	@Apellidos VARCHAR(60),
	@Telefono VARCHAR(12),
	@Edad INT,
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Pacientes 
		(CedulaPaciente, NombrePaciente, Apellidos, Telefono, Edad, CreadoPor)
	VALUES (
		@CedulaPaciente, @NombrePaciente, @Apellidos, @Telefono, @Edad, @CreadoPor)
END