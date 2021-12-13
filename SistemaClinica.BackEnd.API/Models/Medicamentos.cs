using System;

namespace SistemaClinica.BackEnd.API.Models
{
	public class Medicamentos
	{
		public string IdMedicamento { get; set; }

		public string NombreMedicamento { get; set; }

		public int Precio { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
