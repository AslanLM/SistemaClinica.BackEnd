CREATE FUNCTION fnDiagnosticos_seleccionarPorId(@IdDiagnostico INT)
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDiagnosticos_SeleccionarTodos AS Diagnosticos
		WHERE 
			Diagnosticos.IdDiagnostico = @IdDiagnostico