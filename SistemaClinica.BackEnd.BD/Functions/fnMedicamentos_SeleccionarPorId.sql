CREATE FUNCTION fnMedicamentos_SeleccionarPorId(@IdMedicamento INT)
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwMedicamentos_SeleccionarTodos AS Medicamentos
		WHERE 
			Medicamentos.IdMedicamento = @IdMedicamento