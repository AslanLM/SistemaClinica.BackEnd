using SistemaClinica.BackEnd.API.Models;
using SistemaClinica.BackEnd.API.Repository.Interfaces;
using SistemaClinica.BackEnd.API.RepositorySqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Repository 
{
    public class MedicamentosDeCitasRepository : ConexionBD, IMedicamentosDeCitasRepository
    {
        public MedicamentosDeCitasRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(MedicamentosDeCitas medicamentosDeCitas)
        {
            var query = "SP_MedicamentosDeCitas_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdMedicamento", medicamentosDeCitas.IdMedicamento);
            command.Parameters.AddWithValue("@IdCita", medicamentosDeCitas.IdCita);
            command.Parameters.AddWithValue("@Activo", medicamentosDeCitas.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", medicamentosDeCitas.ModificadoPor);

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(MedicamentosDeCitas medicamentosDeCitas)
        {

            var query = "SP_MedicamentosDecitas_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdMedicamento", medicamentosDeCitas.IdMedicamento);
            command.Parameters.AddWithValue("@IdCita", medicamentosDeCitas.IdCita);
            //command.Parameters.AddWithValue("@PrecioMedicamento", medicamentosDeCitas.PrecioMedicamento);
            command.Parameters.AddWithValue("@CreadoPor", medicamentosDeCitas.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public MedicamentosDeCitas SeleccionarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public MedicamentosDeCitas SeleccionarPorIdMultiple(int IdMedicamento, int IdCita)
        {
            var query = "SELECT * FROM vwMedicamentosDeCitas_SeleccionarTodos WHERE IdMedicamento = @IdMedicamento AND IdCita = @IdCita";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);
            command.Parameters.AddWithValue("@IdCita", IdCita);

            SqlDataReader reader = command.ExecuteReader();

            MedicamentosDeCitas MedicamentosDeCitasSeleccionado = new();

            while (reader.Read())
            {
                MedicamentosDeCitasSeleccionado.IdMedicamento = Convert.ToInt32(reader["IdMedicamento"]);
                MedicamentosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                MedicamentosDeCitasSeleccionado.PrecioMedicamento = Convert.ToDecimal(reader["PrecioMedicamento"]);
                MedicamentosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                MedicamentosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MedicamentosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MedicamentosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MedicamentosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return MedicamentosDeCitasSeleccionado;
            
        }

        public List<MedicamentosDeCitas> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwMedicamentosDeCitas_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<MedicamentosDeCitas> ListaTodosLosMedicamentosDeCitas = new List<MedicamentosDeCitas>();

            while (reader.Read())
            {
                MedicamentosDeCitas MedicamentosDeCitasSeleccionado = new();

                MedicamentosDeCitasSeleccionado.IdMedicamento = Convert.ToInt32(reader["IdMedicamento"]);
                MedicamentosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                MedicamentosDeCitasSeleccionado.PrecioMedicamento = Convert.ToDecimal(reader["PrecioMedicamento"]);
                MedicamentosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                MedicamentosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MedicamentosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MedicamentosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MedicamentosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosMedicamentosDeCitas.Add(MedicamentosDeCitasSeleccionado);
            }

            reader.Close();

            return ListaTodosLosMedicamentosDeCitas;
        }

        public List<MedicamentosDeCitas> SeleccionarTodosPorIdCita(int IdCita)
        {
            var query = "SELECT * FROM vwMedicamentosDeCitas_SeleccionarTodos WHERE IdCita = @IdCita ";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdCita", IdCita);


            SqlDataReader reader = command.ExecuteReader();

            List<MedicamentosDeCitas> ListaTodosLosMedicamentosDeCitas = new List<MedicamentosDeCitas>();

            while (reader.Read())
            {
                MedicamentosDeCitas MedicamentosDeCitasSeleccionado = new();

                MedicamentosDeCitasSeleccionado.IdMedicamento = Convert.ToInt32(reader["IdMedicamento"]);
                MedicamentosDeCitasSeleccionado.IdCita = Convert.ToInt32(reader["IdCita"]);
                MedicamentosDeCitasSeleccionado.PrecioMedicamento = Convert.ToDecimal(reader["PrecioMedicamento"]);
                MedicamentosDeCitasSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                MedicamentosDeCitasSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MedicamentosDeCitasSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MedicamentosDeCitasSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MedicamentosDeCitasSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosMedicamentosDeCitas.Add(MedicamentosDeCitasSeleccionado);
            }

            reader.Close();

            return ListaTodosLosMedicamentosDeCitas;
        }
    }
}

