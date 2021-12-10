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
    public class DoctoresRepository : ConexionBD, IDoctoresRepository
    {
        public DoctoresRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Actualizar(Doctores doctor)
        {
            var query = "SP_Doctores_Actualizar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaDoctor", doctor.CedulaDoctor);
            command.Parameters.AddWithValue("@NombreDoctor", doctor.NombreDoctor);
            command.Parameters.AddWithValue("@Apellidos", doctor.Apellidos);
            command.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            command.Parameters.AddWithValue("@ModificadoPor", doctor.ModificadoPor);
           

            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Doctores doctor)
        {

            var query = "SP_Doctores_Insertar";
            var command = CreateCommand(query);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CedulaDoctor", doctor.CedulaDoctor);
            command.Parameters.AddWithValue("@NombreDoctor", doctor.NombreDoctor);
            command.Parameters.AddWithValue("@Apellidos", doctor.Apellidos);
            command.Parameters.AddWithValue("@Telefono", doctor.Telefono);
            command.Parameters.AddWithValue("@CreadoPor", doctor.CreadoPor);

            command.ExecuteNonQuery();

            //throw new NotImplementedException();
        }

        public Doctores SeleccionarPorId(String CedulaDoctor)
        {
            var query = "SELECT * FROM vwDoctores_SeleccionarTodos WHERE CedulaDoctor = @CedulaDoctor";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@CedulaDoctor", CedulaDoctor);

            SqlDataReader reader = command.ExecuteReader();

            Doctores DoctorSeleccionado = new();

            while (reader.Read())
            {
                DoctorSeleccionado.CedulaDoctor = Convert.ToString(reader["CedulaDoctor"]);
                DoctorSeleccionado.NombreDoctor = Convert.ToString(reader["NombreDoctor"]);
                DoctorSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                DoctorSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                DoctorSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DoctorSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DoctorSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DoctorSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DoctorSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

            }

            reader.Close();

            return DoctorSeleccionado;
        }

        public List<Doctores> SeleccionarTodos()
        {
            var query = "SELECT * FROM vwDoctores_SeleccionarTodos";
            var command = CreateCommand(query);

            SqlDataReader reader = command.ExecuteReader();

            List<Doctores> ListaTodosLosDoctores = new List<Doctores>();

            while (reader.Read())
            {
                Doctores DoctorSeleccionado = new();

                DoctorSeleccionado.CedulaDoctor = Convert.ToString(reader["CedulaDoctor"]);
                DoctorSeleccionado.NombreDoctor = Convert.ToString(reader["NombreDoctor"]);
                DoctorSeleccionado.Apellidos = Convert.ToString(reader["Apellidos"]);
                DoctorSeleccionado.Telefono = Convert.ToString(reader["Telefono"]);
                DoctorSeleccionado.Activo = Convert.ToBoolean(reader["Activo"]);
                DoctorSeleccionado.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                DoctorSeleccionado.FechaModificacion = (DateTime?)(reader.IsDBNull("FechaModificacion") ? null : reader["FechaModificacion"]);
                DoctorSeleccionado.CreadoPor = Convert.ToString(reader["CreadoPor"]);
                DoctorSeleccionado.ModificadoPor = Convert.ToString(reader["ModificadoPor"]);

                ListaTodosLosDoctores.Add(DoctorSeleccionado);
            }

            reader.Close();

            return ListaTodosLosDoctores;
        }
    }
}
