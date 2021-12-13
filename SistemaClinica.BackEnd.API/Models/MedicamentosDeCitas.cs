using System;

namespace SistemaClinica.BackEnd.API.Models
{
	public class MedicamentosDeCitas
	{
		public int IdMedicamento { get; set; }

		public int IdCita { get; set; }

		public decimal PrecioMedicamento { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
