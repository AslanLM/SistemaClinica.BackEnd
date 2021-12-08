﻿CREATE PROCEDURE SP_Doctores_Actualizar
	@CedulaDoctor VARCHAR(12),
	@NombreDoctor VARCHAR(40),
	@Apellidos VARCHAR(60),
	@Telefono VARCHAR(12),
	@ModificadoPor VARCHAR(60)		
AS
BEGIN
	UPDATE Doctores 
	SET 
		NombreDoctor = @NombreDoctor, 
		Apellidos = @Apellidos, 
		Telefono = @Telefono,
		ModificadoPor = @ModificadoPor,
		FechaModificacion = GETDATE()
	WHERE 
		CedulaDoctor = @CedulaDoctor
END