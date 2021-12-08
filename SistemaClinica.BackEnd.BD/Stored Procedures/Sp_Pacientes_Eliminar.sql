CREATE PROCEDURE Sp_Pacientes_Eliminar
	@CedulaPaciente VARCHAR (12),
	@ModificadoPor VARCHAR(60)
AS
	UPDATE Pacientes 
	SET 
		Activo = 0,		
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		CedulaPaciente = @CedulaPaciente