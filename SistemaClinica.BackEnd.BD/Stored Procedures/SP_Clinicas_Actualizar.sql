CREATE PROCEDURE SP_Clinicas_Actualizar
	@IdClinica INT,
	@NombreClinica VARCHAR(100),
	@Cedulajurica VARCHAR(25),
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Clinicas 
	SET 
		NombreClinica = @NombreClinica, 
		CedulaJuridica = @CedulaJurica, 
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdClinica = @IdClinica
END