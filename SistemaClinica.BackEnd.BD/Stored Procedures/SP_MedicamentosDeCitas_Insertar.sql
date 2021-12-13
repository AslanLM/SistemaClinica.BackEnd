CREATE PROCEDURE SP_MedicamentosDeCitas_Insertar
	@IdMedicamento INT, 
	@IdCita INT,	
	@CreadoPor VARCHAR(60)
AS
BEGIN
	
	DECLARE @PrecioMedicamento DECIMAL(18,3)
	SET @PrecioMedicamento = (SELECT Precio FROM Medicamentos WHERE IdMedicamento = @IdMedicamento)

	INSERT INTO MedicamentosDeCitas 
		(IdMedicamento, IdCita, PrecioMedicamento, CreadoPor)
	VALUES 
		(@IdMedicamento, @IdCita, @PrecioMedicamento, @CreadoPor)

	DECLARE @SumaPrecioMedicamento DECIMAL(18,3)
	SET @SumaPrecioMedicamento = (SELECT SUM(PrecioMedicamento) FROM MedicamentosDeCitas WHERE Activo = 1 AND IdCita = @IdCita)

	UPDATE Citas SET MontoDeMedicamentos  = @SumaPrecioMedicamento WHERE IdCita = @IdCita
	--TODO: Luego de insertar el registro, acá se debe actualizar el campo: MontoDeMedicamentos de la tabla Citas
END