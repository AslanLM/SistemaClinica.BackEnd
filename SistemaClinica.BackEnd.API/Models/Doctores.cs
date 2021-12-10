using System;

namespace SistemaClinica.BackEnd.API.Models
{
	public class Doctores
	{
		public string CedulaDoctor { get; set; }

		public string NombreDoctor { get; set; }

		public string Apellidos { get; set; }

		public string Telefono { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
