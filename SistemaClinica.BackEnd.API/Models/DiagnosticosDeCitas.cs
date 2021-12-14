using System;

namespace SistemaClinica.BackEnd.API.Models
{
    public class DiagnosticosDeCitas
    {
		public int IdDiagnostico { get; set; }

		public int IdCita { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}

