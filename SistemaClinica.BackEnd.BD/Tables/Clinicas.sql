--use master
--DROP DATABASE Clinica
--GO

CREATE TABLE Clinicas(  
	IdClinica INT IDENTITY(1,1),
	NombreClinica VARCHAR(100) NOT NULL,
	CedulaJuridica VARCHAR(25) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Clinicas PRIMARY KEY (IdClinica)
)
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description',	@value = 'Clínicas que el sistema gestiona',
   	@level0type = N'Schema',	@level0name = 'dbo',
  	@level1type = N'Table',		@level1name = 'Clinicas'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Código o identificador de la clínica',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'IdClinica'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre de la clínica',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'NombreClinica'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Cédula jurídica de la clínica',
   	@level0type =  N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'CedulaJuridica'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = InActivo o Borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Clinicas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'