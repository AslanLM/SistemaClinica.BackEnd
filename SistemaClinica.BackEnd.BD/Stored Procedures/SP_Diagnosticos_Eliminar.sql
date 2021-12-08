CREATE PROCEDURE SP_Diagnosticos_Eliminar
	@IdDiagnostico INT,
	@ModificadoPor VARCHAR(60)
AS
	UPDATE Diagnosticos 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdDiagnostico = @IdDiagnostico