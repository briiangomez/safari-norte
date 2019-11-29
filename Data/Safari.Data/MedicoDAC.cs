using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;

namespace Safari.Data
{
    public partial class MedicoDAC : DataAccessComponent, IRepository<Medico>
    {
        public Medico Create(Medico cliente)
        {
            const string SQL_STATEMENT = "INSERT INTO Medico ([TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Email], [Telefono], [Especialidad], [FechaNacimiento]) VALUES(@TipoMatricula, @NumeroMatricula, @Apellido, @Nombre, @Email, @Telefono, @Especialidad, @FechaNacimiento); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, cliente.TipoMatricula);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, cliente.NumeroMatricula);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, cliente.Especialidad);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, cliente.FechaNacimiento);
                cliente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return cliente;
        }
		
        public List<Medico> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Email], [Telefono], [Especialidad], [FechaNacimiento] FROM Medico ";

            List<Medico> result = new List<Medico>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Medico Medico = LoadMedico(dr);
                        result.Add(Medico);
                    }
                }
            }
            return result;
        }
		
        public Medico ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [TipoMatricula], [NumeroMatricula], [Apellido], [Nombre], [Email], [Telefono], [Especialidad], [FechaNacimiento] FROM Medico WHERE [Id]=@Id ";
            Medico Medico = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Medico = LoadMedico(dr);
                    }
                }
            }
            return Medico;
        }
		
        public void Update(Medico cliente)
        {
            const string SQL_STATEMENT = "UPDATE Medico SET [TipoMatricula] = @TipoMatricula, [NumeroMatricula] = @NumeroMatricula, [Apellido] = @Apellido, [Nombre] = @Nombre, [Email] = @Email, [Telefono] = @Telefono, [Especialidad]=@Especialidad, [FechaNacimiento]=@FechaNacimiento WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoMatricula", DbType.AnsiString, cliente.TipoMatricula);
                db.AddInParameter(cmd, "@NumeroMatricula", DbType.Int32, cliente.NumeroMatricula);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@Especialidad", DbType.AnsiString, cliente.Especialidad);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cliente.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Medico WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private Medico LoadMedico(IDataReader dr)
        {
            Medico cliente = new Medico();
            cliente.Id = GetDataValue<int>(dr, "Id");
            cliente.TipoMatricula = GetDataValue<string>(dr, "TipoMatricula");
            cliente.NumeroMatricula = GetDataValue<int>(dr, "NumeroMatricula");
            cliente.Nombre = GetDataValue<string>(dr, "Nombre");
            cliente.Apellido = GetDataValue<string>(dr, "Apellido");
            cliente.Telefono = GetDataValue<string>(dr, "Telefono");
            cliente.Email = GetDataValue<string>(dr, "Email");
            cliente.Especialidad = GetDataValue<string>(dr, "Especialidad");
            cliente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            return cliente;
        }
    }
}

