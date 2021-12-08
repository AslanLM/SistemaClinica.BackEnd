CREATE PROCEDURE SP_Doctores_Eliminar
	@CedulaDoctor VARCHAR (12),
	@ModificadoPor VARCHAR(60)
AS
	UPDATE Doctores 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		CedulaDoctor = @CedulaDoctor