CREATE FUNCTION fnDiagnosticosDeCitas_SeleccionaPorId(@IdCita INT)
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDiagnosticosdeCitas_SeleccionarTodos AS DiagnosticosDeCitas
		WHERE 
			DiagnosticosDeCitas.IdCita = @IdCita