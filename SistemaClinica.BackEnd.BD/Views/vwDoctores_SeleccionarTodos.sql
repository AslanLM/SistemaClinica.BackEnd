CREATE VIEW vwDoctores_SeleccionarTodos
AS
	SELECT * 
	FROM Doctores 
	WHERE 
		Activo = 1