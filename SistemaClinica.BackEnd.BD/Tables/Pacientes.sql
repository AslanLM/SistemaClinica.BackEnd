CREATE TABLE Pacientes( 
	CedulaPaciente VARCHAR(12), 
	NombrePaciente VARCHAR(40) NOT NULL, 
	Apellidos VARCHAR(60) NOT NULL,  
	Telefono VARCHAR(12), 
	Edad INT NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Pacientes PRIMARY KEY(CedulaPaciente)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Pacientes que gestiona el sistema',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Cédula de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'CedulaPaciente'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'NombrePaciente'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Apellidos de los pacientes ',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'Apellidos'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Teléfono de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'Telefono'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Edad de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'Edad'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Fecha de creación del registro',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Fecha de modificación del registro',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Pacientes', 
    @level2type = N'Column',	@level2name = 'ModificadoPor'