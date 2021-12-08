CREATE FUNCTION fnDoctores_SeleccionarDoctoresTodos()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwDoctores_SeleccionarTodos