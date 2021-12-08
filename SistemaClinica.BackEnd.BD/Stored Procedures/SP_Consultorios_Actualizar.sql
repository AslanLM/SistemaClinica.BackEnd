CREATE PROCEDURE SP_Consultorios_Actualizar
	@IdConsultorio VARCHAR(50),
	@NombreConsultorio VARCHAR(50),
	@IdClinica INT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Consultorios 
	SET 
		NombreConsultorio = @NombreConsultorio, 
		IdClinica = @IdClinica,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdConsultorio = @IdConsultorio		
END