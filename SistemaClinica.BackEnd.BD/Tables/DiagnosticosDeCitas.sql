CREATE TABLE DiagnosticosDeCitas( 
	IdDiagnostico INT, 
	IdCita INT,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_DiagnosticosDeCitas PRIMARY KEY(IdDiagnostico, IdCita),
	CONSTRAINT FK_DiagnosticosDeCitas_IdDiagnostico FOREIGN KEY(IdDiagnostico) REFERENCES Diagnosticos(IdDiagnostico),
	CONSTRAINT FK_DiagnosticosDeCitas_IdCita FOREIGN KEY(IdCita) REFERENCES Citas(IdCita)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Diagnósticos de las citas de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'DiagnosticosDeCitas'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de los diagnósticos en citas de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
    @level2type = N'Column',	@level2name = 'IdDiagnostico'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de las citas de los pacientes para definir el diagnóstico',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
    @level2type = N'Column',	@level2name = 'IdCita'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'DiagnosticosDeCitas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'