CREATE FUNCTION fnMedicamentos_SeleccionarTodos()
	RETURNS TABLE AS 
	RETURN 
		SELECT * 
		FROM vwMedicamentos_SeleccionarTodos