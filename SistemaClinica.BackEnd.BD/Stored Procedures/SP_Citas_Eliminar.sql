CREATE PROCEDURE SP_Citas_Eliminar
	@IdCita INT,
	@ModificadoPor VARCHAR(60)
AS
	UPDATE Citas 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdCita = @IdCita