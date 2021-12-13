CREATE PROCEDURE SP_MedicamentosDeCitas_Actualizar --Para esta aplicación quizá este SP no se utilice
	@IdMedicamento INT, 
	@IdCita INT,
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	
	DECLARE @PrecioMedicamento DECIMAL(18,3)
	SET @PrecioMedicamento = (SELECT Precio FROM Medicamentos WHERE IdMedicamento = @IdMedicamento)

	UPDATE MedicamentosDeCitas 
	SET 
		IdMedicamento = @IdMedicamento, 
		IdCita = @IdCita, 
		PrecioMedicamento = @PrecioMedicamento,
        Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdMedicamento = @IdMedicamento AND
		IdCita = @IdCita
	--TODO: Luego de actualizar el registro, acá se debe actualizar el campo: MontoDeMedicamentos de la tabla Citas
END