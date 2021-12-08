CREATE PROCEDURE SP_DiagnosticosDeCitas_Insertar
	@IdDiagnostico INT, 
	@IdCita INT,
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO DiagnosticosDeCitas 
		(IdDiagnostico, IdCita, CreadoPor)
	VALUES
		(@IdDiagnostico, @IdCita, @CreadoPor)
END