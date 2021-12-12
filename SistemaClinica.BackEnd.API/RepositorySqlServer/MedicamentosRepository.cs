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
    public class MedicamentosRepository : ConexionBD, IMedicamentosRepository
    {
        public MedicamentosRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Medicamentos medicamentos)
        {
            var query = "SP_Pacientes_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdMedicamento", medicamentos.IdMedicamento);
            command.Parameters.AddWithValue("@NombreMedicamento", medicamentos.NombreMedicamento);
            command.Parameters.AddWithValue("@Precio", medicamentos.Precio);
            command.Parameters.AddWithValue("@Activo", medicamentos.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", medicamentos.ModificadoPor);
          
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Medicamentos medicamentos)
        {

            var query = "SP_Pacientes_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdMedicamento", medicamentos.IdMedicamento);
            command.Parameters.AddWithValue("@NombreMedicamento", medicamentos.NombreMedicamento);
            command.Parameters.AddWithValue("@Precio", medicamentos.Precio);
            command.Parameters.AddWithValue("@Activo", medicamentos.Activo);
            command.Parameters.AddWithValue("@ModificadoPor", medicamentos.ModificadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Medicamentos SeleccionarPorId(String IdMedicamento)
        {
            var query = "SELECT * FROM vwPaciente_SeleccionarTodos WHERE CedulaPaciente = @CedulaPaciente";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@IdMedicamento", IdMedicamento);

            SqlDataReader reader = command.ExecuteReader();

            Medicamentos MedicamentosSeleccionado = new();

            while (reader.Read())
            {
                MedicamentosSeleccionado.IdMedicamento = Convert.ToString(reader["CedulaPaciente"]);
                MedicamentosSeleccionado.NombreMedicamento = Convert.ToString(reader["NombrePaciente"]);
                MedicamentosSeleccionado.Precio = Convert.ToInt32(reader["Edad"]);
                MedicamentosSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                MedicamentosSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MedicamentosSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MedicamentosSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MedicamentosSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return MedicamentosSeleccionado;
        }

        public List<Pacientes> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwMedicamentos_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Pacientes> ListaTodosLosMedicamentos = new List<Medicamentos>();

            while (reader.Read())
            {
                Pacientes MedicamentosSeleccionado = new();

                MedicamentosSeleccionado.IdMedicamento = Convert.ToString(reader["IdMedicamento"]);
                MedicamentosSeleccionado.NombreMedicamento = Convert.ToString(reader["NombreMedicamento"]);
                MedicamentosSeleccionado.Precio = Convert.ToInt32(reader["Precio"]);
                MedicamentosSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                MedicamentosSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                MedicamentosSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                MedicamentosSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                MedicamentosSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);


                ListaTodosLosMedicamentos.Add(MedicamentosSeleccionado);
            }

            reader.Close();

            return ListaTodosLosMedicamentos;
        }
    }
}
