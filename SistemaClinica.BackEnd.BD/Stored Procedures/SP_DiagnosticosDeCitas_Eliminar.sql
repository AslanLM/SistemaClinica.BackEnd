CREATE PROCEDURE SP_DiagnosticosDeCitas_Eliminar
	@IdDiagnostico INT,
	@IdCita INT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE DiagnosticosDeCitas 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdDiagnostico = @IdDiagnostico AND
		IdCita = @IdCita
END