CREATE VIEW vwMedicamentosDeCitas_SeleccionarTodos
AS
	SELECT * 
	FROM  MedicamentosDeCitas 
	WHERE 
		Activo = 1