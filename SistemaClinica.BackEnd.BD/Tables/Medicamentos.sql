CREATE TABLE Medicamentos( 
	IdMedicamento INT IDENTITY(1,1), 
	NombreMedicamento VARCHAR(150) NOT NULL,
	Precio DECIMAL(18,3) NOT NULL, 
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Medicamentos PRIMARY KEY(IdMedicamento)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Medicamentos de la clínica',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Medicamentos'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de los medicamentos de la clínica',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Medicamentos', 
    @level2type = N'Column',	@level2name = 'IdMedicamento'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre del medicamento',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Medicamentos', 
    @level2type = N'Column',	@level2name = 'NombreMedicamento'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Precio actual del medicamento',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Medicamentos', 
    @level2type = N'Column',	@level2name = 'Precio'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Medicamentos', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Medicamentos', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Medicamentos', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Medicamentos', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Medicamentos', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'