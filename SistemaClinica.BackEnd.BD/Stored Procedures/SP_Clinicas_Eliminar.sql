CREATE PROCEDURE SP_Clinicas_Eliminar
	@idClinica INT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE clinicas 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdClinica = @idClinica
END