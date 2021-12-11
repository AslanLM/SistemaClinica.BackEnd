using System;

namespace SistemaClinica.BackEnd.API.Models
{
    public class Clinicas
    {

		public int IdClinica { get; set; }

		public string NombreClinica { get; set; }

		public string CedulaJuridica { get; set; }

		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }
	}
}
