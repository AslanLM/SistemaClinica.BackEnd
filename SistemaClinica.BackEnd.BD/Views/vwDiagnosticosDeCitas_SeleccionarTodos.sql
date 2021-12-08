CREATE VIEW vwDiagnosticosDeCitas_SeleccionarTodos
AS
	SELECT * 
	FROM  DiagnosticosDeCitas 
	WHERE 
		Activo = 1