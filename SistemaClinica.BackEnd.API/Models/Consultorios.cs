using System;

namespace SistemaClinica.BackEnd.API.Models
{
    public class Consultorios
	{
	public string IdConsultorio { get; set; }

	public string NombreConsultorio { get; set; }

	public int IdClinica { get; set; }

	public bool Activo { get; set; }

	public DateTime FechaCreacion { get; set; }

	public DateTime? FechaModificacion { get; set; }

	public string CreadoPor { get; set; }

	public string ModificadoPor { get; set; }

	}
}
