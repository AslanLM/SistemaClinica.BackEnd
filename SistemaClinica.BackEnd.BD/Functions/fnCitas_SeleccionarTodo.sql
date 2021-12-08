CREATE FUNCTION fnCitas_SeleccionarTodo()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwCitas_SeleccionarTodos