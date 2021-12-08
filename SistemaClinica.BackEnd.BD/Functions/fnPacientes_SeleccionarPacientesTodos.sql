CREATE FUNCTION fnPacientes_SeleccionarPacientesTodos()
	RETURNS TABLE AS
	RETURN 
		SELECT * 
		FROM vwPaciente_SeleccionarTodos