CREATE PROCEDURE SP_Diagnosticos_Actualizar
	@IdDiagnostico INT,
	@Diagnostico VARCHAR(50),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Diagnosticos 
	SET  
		Diagnostico =  @Diagnostico,
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdDiagnostico = @IdDiagnostico
END