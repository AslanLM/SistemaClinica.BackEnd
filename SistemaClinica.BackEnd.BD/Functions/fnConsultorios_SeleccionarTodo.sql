CREATE FUNCTION fnConsultorios_SeleccionarTodo()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwConsultorios_SeleccionarTodos