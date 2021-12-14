CREATE PROCEDURE SP_Citas_Actualizar
	@IdCita INT,
	@FechaYHoraInicioCita DATETIME,
	@FechaYHoraFinCita DATETIME,
	@CedulaDoctor VARCHAR(12),
	@CedulaPaciente VARCHAR(12),
	@IdConsultorio VARCHAR(50),
	@IdDiagnostico INT,
	@MontoDeConsulta DECIMAL(18,3),
	@Activo BIT,
	@ModificadoPor VARCHAR(60)
AS
BEGIN
	UPDATE Citas 
	SET 
		FechaYHoraInicioCita = @FechaYHoraInicioCita,
		FechaYHoraFinCita = @FechaYHoraFinCita,
		CedulaDoctor = @CedulaDoctor, 
		CedulaPaciente = @CedulaPaciente, 
		IdConsultorio = @IdConsultorio, 
		IdDiagnostico = @IdDiagnostico,
		MontoDeConsulta = @MontoDeConsulta,
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdCita = @IdCita
END