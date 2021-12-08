CREATE FUNCTION fnPacientes_SeleccionarPacientesPorId(@CedulaPaciente VARCHAR (12))
	RETURNS TABLE AS 
	RETURN 
		SELECT * 
		FROM vwPaciente_SeleccionarTodos AS Pacientes 
		WHERE 
			Pacientes.CedulaPaciente = @CedulaPaciente