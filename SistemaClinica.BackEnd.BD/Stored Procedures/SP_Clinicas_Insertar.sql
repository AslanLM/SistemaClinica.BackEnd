CREATE PROCEDURE SP_Clinicas_Insertar
	@NombreClinica VARCHAR(100),
	@CedulaJuridica VARCHAR(25),
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Clinicas 
		(NombreClinica, CedulaJuridica, CreadoPor)
	VALUES 
		(@NombreClinica, @CedulaJuridica, @CreadoPor)
END