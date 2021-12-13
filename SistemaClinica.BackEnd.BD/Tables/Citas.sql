CREATE TABLE Citas( 
	IdCita INT IDENTITY(1,1), 
	FechaYHoraInicioCita DATETIME NOT NULL, 
	FechaYHoraFinCita DATETIME NOT NULL, 
	CedulaDoctor VARCHAR(12) NOT NULL,
	CedulaPaciente VARCHAR(12) NOT NULL,
	IdConsultorio VARCHAR(50) NOT NULL,	
	IdDiagnostico INT,
	MontoDeConsulta DECIMAL(18,3) NOT NULL,
	MontoDeMedicamentos DECIMAL(18,3) DEFAULT 0 NOT NULL, --TODO: Por cada medicamento que se compre se debe actualizar este campo, para que sume el costo de cada medicamento
	MontoTotal AS MontoDeConsulta + MontoDeMedicamentos,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	FechaModificacion DATETIME,
	CreadoPor VARCHAR(60),
	ModificadoPor VARCHAR(60),
	CONSTRAINT PK_Citas PRIMARY KEY(IdCita),
	CONSTRAINT FK_Doctores_CedulaDoctor FOREIGN KEY(CedulaDoctor) REFERENCES Doctores(CedulaDoctor),
	CONSTRAINT FK_Pacientes_CedulaPaciente FOREIGN KEY(CedulaPaciente) REFERENCES Pacientes(CedulaPaciente),
	CONSTRAINT FK_Consultorios_IdConsultorio FOREIGN KEY(IdConsultorio) REFERENCES Consultorios(IdConsultorio),
	CONSTRAINT FK_Diagnosticos_IdDiagnostico FOREIGN KEY(IdDiagnostico) REFERENCES Diagnosticos(IdDiagnostico),
)
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Citas de todos los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Identificador de las citas de los pacientes',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'IdCita'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Fecha y hora inicio de la cita de los pacientes en un consultorio con un doctor',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'FechaYHoraInicioCita'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Fecha y hora fin de la cita de los pacientes en un consultorio con un doctor',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'FechaYHoraFinCita'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'La cédula del doctor que atiende a los pacientes en un consultorio',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'CedulaDoctor'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'La cédula del paciente que asiste a la cita',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'CedulaPaciente'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'El consultorio donde se lleva acabo la cita con el paciente',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'IdConsultorio'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'El diagnóstico de la cita con el paciente',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'IdDiagnostico'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Monto a cobrar al paciente por la consulta',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'MontoDeConsulta'
GO
EXEC sp_addextendedproperty 
    @name = N'MS_Description',	@value = 'Monto a cobrar al paciente por los medicamentos',
    @level0type = N'Schema',	@level0name = 'dbo',
    @level1type = N'Table',		@level1name = 'Citas', 
    @level2type = N'Column',	@level2name = 'MontoDeMedicamentos'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Campo Calculado: Costo total de la cita, incluye costo de la consulta más costo de los medicamentos comprados por el paciente',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'MontoTotal'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Condición en la que se encuentra el registro: 1 = Activo; 0 = inActivo o borrado',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'Activo'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de creación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'FechaCreacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Fecha de modificación del registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'FechaModificacion'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que crea el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'CreadoPor'
GO
EXEC sp_addextendedproperty 
	@name = N'MS_Description',	@value = 'Nombre del usuario que modifica el registro',
   	@level0type = N'Schema',	@level0name = 'dbo',
   	@level1type = N'Table',		@level1name = 'Citas', 
   	@level2type = N'Column',	@level2name = 'ModificadoPor'