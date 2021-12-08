CREATE FUNCTION fnDoctores_SeleccionarDoctorPorId(@CedulaDoctor VARCHAR (12))
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDoctores_SeleccionarTodos AS Doctores
		WHERE
			Doctores.CedulaDoctor = @CedulaDoctor