using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.RepositorySqlServer
{
    public class DiagnosticoRepository : ConexionBD, IDiagnosticoRepository
    {
        public DiagnosticoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Diagnosticos diagnosticos)
        {
            var query = "SP_Diagnosticos_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdDiagnostico", diagnosticos.IdDiagnostico);
            command.Parameters.AddWithValue("@Diagnostico", diagnosticos.Diagnostico);
            command.Parameters.AddWithValue("@Activo", diagnosticos.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", diagnosticos.ModificadoPor);


            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Diagnosticos diagnosticos)
        {

            var query = "SP_Diagnosticos_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            //command.Parameters.AddWithValue("@IdDiagnosticos", diagnosticos.IdDiagnosticos);
            command.Parameters.AddWithValue("@Diagnostico", diagnosticos.Diagnostico);
            command.Parameters.AddWithValue("@CreadoPor", diagnosticos.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Diagnosticos SeleccionarPorId(int IdDiagnostico)
        {
            var query = "SELECT * FROM vwDiagnosticos_SeleccionarTodos WHERE IdDiagnostico = @IdDiagnostico";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdDiagnostico", IdDiagnostico);

            SqlDataReader reader = command.ExecuteReader();

            Diagnosticos DiagnosticoSeleccionada = new();

            while (reader.Read())
            {
                DiagnosticoSeleccionada.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                DiagnosticoSeleccionada.Diagnostico = Convert.ToString(reader["Diagnostico"]);
                DiagnosticoSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                DiagnosticoSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DiagnosticoSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DiagnosticoSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DiagnosticoSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return DiagnosticoSeleccionada;
        }

        public List<Diagnosticos> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwDiagnosticos_SeleccionarTodos"; 
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Diagnosticos> ListaTodsLasDiagnosticos = new List<Diagnosticos>();

            while (reader.Read())
            {
                Diagnosticos DiagnosticoSeleccionada = new();

                DiagnosticoSeleccionada.IdDiagnostico = Convert.ToInt32(reader["IdDiagnostico"]);
                DiagnosticoSeleccionada.Diagnostico = Convert.ToString(reader["Diagnostico"]);
                DiagnosticoSeleccionada.Activo = Convert.ToBoolean(reader["Activo"]);
                DiagnosticoSeleccionada.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DiagnosticoSeleccionada.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DiagnosticoSeleccionada.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DiagnosticoSeleccionada.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodsLasDiagnosticos.Add(DiagnosticoSeleccionada);
            }

            reader.Close();

            return ListaTodsLasDiagnosticos;
        }

    }
}
