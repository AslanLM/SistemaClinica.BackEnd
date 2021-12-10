using System;

namespace SistemaClinica.BackEnd.API.Models
{
	public class Pacientes
	{
		public string CedulaPaciente { get; set; }

		public string NombrePaciente { get; set; }

		public string Apellidos { get; set; }

		public string Telefono { get; set; }

		public int Edad { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
