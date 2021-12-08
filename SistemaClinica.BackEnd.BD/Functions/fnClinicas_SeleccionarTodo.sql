CREATE FUNCTION fnClinicas_SeleccionarTodo()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwClinicas_SeleccionarTodo