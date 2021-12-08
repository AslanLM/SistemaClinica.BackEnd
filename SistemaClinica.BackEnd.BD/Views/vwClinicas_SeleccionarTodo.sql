CREATE VIEW vwClinicas_SeleccionarTodo
AS 
	SELECT * 
	FROM Clinicas 
	WHERE 
		Activo = 1