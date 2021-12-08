CREATE FUNCTION fnDiagnosticosDeCitas_SeleccionarTodos() --Para esta Aplicación posiblemente esta FN no se utilice.
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDiagnosticosdeCitas_SeleccionarTodos