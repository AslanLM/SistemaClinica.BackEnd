CREATE PROCEDURE SP_Pacientes_Actualizar
	@CedulaPaciente VARCHAR(12),
	@NombrePaciente VARCHAR(40),
	@Apellidos VARCHAR(60),
	@Telefono VARCHAR(12),
	@Edad INT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Pacientes 
	SET 
		NombrePaciente = @NombrePaciente, 
		Apellidos = @Apellidos, 
		Telefono = @Telefono,
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		CedulaPaciente = @CedulaPaciente
END