CREATE PROCEDURE SP_Citas_Actualizar
	@IdCita INT,
	@FechaYHoraInicioCita DATETIME,
	@FechaYHoraFinCita DATETIME,
	@CedulaDoctor VARCHAR(12),
	@CedulaPaciente VARCHAR(12),
	@IdConsultorio VARCHAR(50),
	@IdDiagnostico INT,
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
		Activo = @Activo,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		IdCita = @IdCita
END