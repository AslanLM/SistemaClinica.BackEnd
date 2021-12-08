CREATE TABLE Consultorios( 
	IdConsultorio VARCHAR(50), 
	NombreConsultorio VARCHAR(50) NOT Null,
	IdClinica INT NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Consultorios PRIMARY KEY(IdConsultorio),
	CONSTRAINT FK_Consultorios_IdClinica FOREIGN KEY(IdClinica) REFERENCES Clinicas(IdClinica)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Consultorios para atender a los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Consultorios'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de los consultorios',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Consultorios', 
    @level2type = N'Column',	@level2name = 'IdConsultorio'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Nombre o número del consultorio',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Consultorios', 
    @level2type = N'Column',	@level2name = 'NombreConsultorio'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de la clínica a la que pertenece el consultorio',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Consultorios', 
    @level2type = N'Column',	@level2name = 'IdClinica'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Consultorios', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Consultorios', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Consultorios', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Consultorios', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Consultorios', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'