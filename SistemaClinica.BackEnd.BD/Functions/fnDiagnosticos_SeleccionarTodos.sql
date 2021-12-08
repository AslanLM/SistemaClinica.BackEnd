CREATE FUNCTION fnDiagnosticos_SeleccionarTodos()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDiagnosticos_SeleccionarTodos