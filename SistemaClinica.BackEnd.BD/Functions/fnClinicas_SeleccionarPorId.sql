CREATE FUNCTION fnClinicas_SeleccionarPorId(@IdClinica INT)
	RETURNS TABLE 
	AS
	RETURN 
		SELECT * 
		FROM vwClinicas_SeleccionarTodo AS Clinicas 
		WHERE 
			Clinicas.IdClinica =  @IdClinica