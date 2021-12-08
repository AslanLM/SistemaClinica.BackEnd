CREATE FUNCTION fnMedicamentosDeCitas_SeleccionarTodos() --Para esta Aplicación posiblemente esta FN no se utilice.
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwMedicamentosDeCitas_SeleccionarTodos