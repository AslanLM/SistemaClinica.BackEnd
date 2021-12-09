using System.Data.SqlClient; //Requiere de instalar este paquete con Nuget

namespace SistemaClinica.BackEnd.API.RepositorySqlServer
{
    public abstract class ConexionBD
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }
    }
}
