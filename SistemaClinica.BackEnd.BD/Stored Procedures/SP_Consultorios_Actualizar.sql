CREATE PROCEDURE SP_Consultorios_Actualizar
	@IdConsultorio VARCHAR(50),
	@NombreConsultorio VARCHAR(50),
	@IdClinica INT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)

AS
BEGIN
	UPDATE Consultorios 
	SET 
		NombreConsultorio = @NombreConsultorio, 
		IdClinica = @IdClinica,
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdConsultorio = @IdConsultorio		
END