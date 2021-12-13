CREATE PROCEDURE SP_Medicamentos_Actualizar
	@IdMedicamento INT,
	@NombreMedicamento VARCHAR(150),
	@Precio DECIMAL(18,3),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Medicamentos 
	SET 
		NombreMedicamento = @NombreMedicamento, 
		Precio = @Precio, 
		ModificadoPor = @ModificadoPor,
		Activo = @Activo,
		FechaModificacion = GETDATE()
	WHERE 
		IdMedicamento = @IdMedicamento
END