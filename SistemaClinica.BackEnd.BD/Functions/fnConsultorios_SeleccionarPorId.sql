CREATE FUNCTION fnConsultorios_SeleccionarPorId(@IdConsultorio VARCHAR(50))
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwConsultorios_SeleccionarTodos AS Consultorios
		WHERE 
			Consultorios.IdConsultorio = @IdConsultorio