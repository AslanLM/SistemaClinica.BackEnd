CREATE VIEW vwMedicamentos_SeleccionarTodos
AS
	SELECT * 
	FROM Medicamentos 
	WHERE 
		Activo = 1