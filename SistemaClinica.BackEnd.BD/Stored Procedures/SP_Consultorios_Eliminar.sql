CREATE PROCEDURE SP_Consultorios_Eliminar
	@IdConsultorio VARCHAR(50),
	@ModificadoPor VARCHAR(60)
AS
	UPDATE Consultorios 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdConsultorio = @IdConsultorio