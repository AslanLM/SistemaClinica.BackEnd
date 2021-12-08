CREATE PROCEDURE SP_Medicamentos_Actualizar
	@IdMedicamento INT,
	@NombreMedicamento VARCHAR(150),
	@Precio DECIMAL(18,3),
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Medicamentos 
	SET 
		NombreMedicamento = @NombreMedicamento, 
		Precio = @Precio, 
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdMedicamento = @IdMedicamento
END