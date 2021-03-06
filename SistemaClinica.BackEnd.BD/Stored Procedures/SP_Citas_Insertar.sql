CREATE PROCEDURE SP_Citas_Insertar
	@FechaYHoraInicioCita DATETIME,
	@FechaYHoraFinCita DATETIME,
	@CedulaDoctor VARCHAR(12),
	@CedulaPaciente VARCHAR(12),
	@IdConsultorio VARCHAR(50),
	@IdDiagnostico INT,
	@MontoDeConsulta DECIMAL,
	@CreadoPor VARCHAR(60)
AS
BEGIN
	INSERT INTO Citas 
		(FechaYHoraInicioCita, FechaYHoraFinCita, CedulaDoctor, CedulaPaciente, IdConsultorio, IdDiagnostico, MontoDeConsulta, CreadoPor)
	VALUES 
		(@FechaYHoraInicioCita, @FechaYHoraFinCita, @CedulaDoctor, @CedulaPaciente, @IdConsultorio, @IdDiagnostico, @MontoDeConsulta, @CreadoPor)
END