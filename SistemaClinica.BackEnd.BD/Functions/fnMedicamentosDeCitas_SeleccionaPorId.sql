CREATE FUNCTION fnMedicamentosDeCitas_SeleccionaPorId(@IdCita INT)
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwMedicamentosDeCitas_SeleccionarTodos AS MedicamentosDeCitas
		WHERE 
			MedicamentosDeCitas.IdCita = @IdCita