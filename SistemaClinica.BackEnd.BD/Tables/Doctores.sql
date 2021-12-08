CREATE TABLE Doctores( 
	CedulaDoctor VARCHAR(12),
	NombreDoctor VARCHAR(40) NOT NULL, 
	Apellidos VARCHAR(60) NOT NULL,  
	Telefono VARCHAR(12),
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Dosctores PRIMARY KEY(CedulaDoctor)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Doctores que gestionan el sistema',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Doctores'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Cédula del doctor o especialista',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Doctores', 
    @level2type = N'Column',	@level2name = 'CedulaDoctor'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre del doctor o especialista',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Doctores', 
    @level2type = N'Column',	@level2name = 'NombreDoctor'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Apellidos del doctor o especialista',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Doctores', 
    @level2type = N'Column',	@level2name = 'Apellidos'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Teléfono de doctor o especialista',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Doctores', 
    @level2type = N'Column',	@level2name = 'Telefono'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Doctores', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Doctores', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Doctores', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Doctores', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'