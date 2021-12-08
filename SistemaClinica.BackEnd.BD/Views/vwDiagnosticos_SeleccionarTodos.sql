CREATE VIEW vwDiagnosticos_SeleccionarTodos
AS
	SELECT * 
	FROM Diagnosticos 
	WHERE 
		Activo = 1