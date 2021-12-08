CREATE VIEW vwPaciente_SeleccionarTodos
AS
	SELECT * 
	FROM Pacientes 
	WHERE 
		Activo = 1