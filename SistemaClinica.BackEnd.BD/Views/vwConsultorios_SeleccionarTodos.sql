CREATE VIEW vwConsultorios_SeleccionarTodos
AS
	SELECT * FROM Consultorios 
	WHERE 
		Activo = 1