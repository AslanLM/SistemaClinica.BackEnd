CREATE PROCEDURE SP_DiagnosticosDeCitas_Actualizar --Para esta Aplicación posiblemente este SP no se utilice.
	@IdDiagnostico INT, 
	@IdCita INT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE DiagnosticosDeCitas 
	SET 
		--IdDiagnostico = @IdDiagnostico, 
		--IdCita = @IdCita, 
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdDiagnostico = @IdDiagnostico AND
		IdCita = @IdCita

END