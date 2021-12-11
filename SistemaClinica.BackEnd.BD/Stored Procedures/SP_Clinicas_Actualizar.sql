CREATE PROCEDURE SP_Clinicas_Actualizar
	@IdClinica INT,
	@NombreClinica VARCHAR(100),
	@Cedulajuridica VARCHAR(25),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
	
AS
BEGIN
	UPDATE Clinicas 
	SET 
		NombreClinica = @NombreClinica, 
		CedulaJuridica = @CedulaJuridica,
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdClinica = @IdClinica
END