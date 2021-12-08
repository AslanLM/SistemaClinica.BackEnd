CREATE VIEW vwCitas_SeleccionarTodos
AS
	SELECT * FROM Citas 
	WHERE 
		Activo = 1