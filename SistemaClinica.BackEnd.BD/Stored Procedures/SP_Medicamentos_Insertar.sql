CREATE PROCEDURE SP_Medicamentos_Insertar
	@NombreMedicamento VARCHAR(150),
	@Precio DECIMAL(18,3),
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Medicamentos 
		(NombreMedicamento, Precio, CreadoPor)
	VALUES
		(@NombreMedicamento, @Precio, @CreadoPor)
END