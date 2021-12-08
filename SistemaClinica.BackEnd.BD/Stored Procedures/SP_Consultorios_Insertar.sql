CREATE PROCEDURE SP_Consultorios_Insertar
	@IdConsultorio VARCHAR(50), 
	@NombreConsultorio VARCHAR(50),
	@IdClinica INT,
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Consultorios 
		(IdConsultorio, NombreConsultorio, IdClinica, CreadoPor)
	VALUES 
		(@IdConsultorio, @NombreConsultorio, @IdClinica, @CreadoPor)
END