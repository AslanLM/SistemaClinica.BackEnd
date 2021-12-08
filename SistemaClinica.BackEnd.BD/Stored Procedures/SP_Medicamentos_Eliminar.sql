CREATE PROCEDURE SP_Medicamentos_Eliminar
	@IdMedicamento INT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Medicamentos 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdMedicamento = @IdMedicamento
END