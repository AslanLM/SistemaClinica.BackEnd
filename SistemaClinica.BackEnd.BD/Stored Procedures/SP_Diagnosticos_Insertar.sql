CREATE PROCEDURE SP_Diagnosticos_Insertar
	 @Diagnostico VARCHAR(50),
	 @CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Diagnosticos 
		(Diagnostico, CreadoPor)
	VALUES 
		(@Diagnostico, @CreadoPor)
END