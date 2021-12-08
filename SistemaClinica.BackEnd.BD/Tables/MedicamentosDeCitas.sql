CREATE TABLE MedicamentosDeCitas( 
	IdMedicamento INT, 
	IdCita INT,
	PrecioMedicamento DECIMAL(18,3) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_MedicamentosDeCitas PRIMARY KEY(IdMedicamento, IdCita),
	CONSTRAINT FK_MedicamentosDeCitas_IdMedicamento FOREIGN KEY(IdMedicamento) REFERENCES Medicamentos(IdMedicamento),
	CONSTRAINT FK_MedicamentosDeCitas_IdCita FOREIGN KEY(IdCita) REFERENCES Citas(IdCita)
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Medicamentos para los pacientes atendidos en una cita',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'MedicamentosDeCitas'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de los medicamentos de los pacientes en una cita',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
    @level2type = N'Column',	@level2name = 'IdMedicamento'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de las citas de los pacientes para definir los medicamentos',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
    @level2type = N'Column',	@level2name = 'IdCita'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Precio de los medicamento dados a los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
    @level2type = N'Column',	@level2name = 'PrecioMedicamento'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'MedicamentosDeCitas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'