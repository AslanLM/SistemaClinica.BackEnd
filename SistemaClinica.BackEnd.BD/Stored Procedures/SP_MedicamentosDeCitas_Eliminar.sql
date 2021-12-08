CREATE PROCEDURE SP_MedicamentosDeCitas_Eliminar
	@IdMedicamento INT,
	@IdCita INT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE MedicamentosDeCitas 
	SET 
		Activo = 0,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdMedicamento = @IdMedicamento AND
		IdCita = @IdCita
	--TODO: Luego de actualizar el registro, acá se debe actualizar el campo: MontoDeMedicamentos de la tabla Citas
END