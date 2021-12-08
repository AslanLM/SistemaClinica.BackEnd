CREATE FUNCTION fnCitas_SeleccionarPorId(@IdCita INT)
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwCitas_SeleccionarTodos AS Citas
		WHERE 
			Citas.IdCita = @IdCita