CREATE PROCEDURE SP_Diagnosticos_Actualizar
	@IdDiagnostico INT,
	@Diagnostico VARCHAR(50),
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Diagnosticos 
	SET  
		Diagnostico =  @Diagnostico,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdDiagnostico = @IdDiagnostico
END