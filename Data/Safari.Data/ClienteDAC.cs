using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using Safari.Framework.Common;
using Safari.Framework.Logging;

namespace Safari.Data
{
    public partial class ClienteDAC : DataAccessComponent, IRepository<Cliente>
    {
        public Cliente Create(Cliente cliente)
        {
            const string SQL_STATEMENT = "INSERT INTO Cliente ([Apellido], [Nombre], [Email], [Telefono], [URL], [FechaNacimiento], [Domicilio]) VALUES(@Apellido, @Nombre, @Email, @Telefono, @URL, @FechaNacimiento, @Domicilio); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@URL", DbType.AnsiString, cliente.URL);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                cliente.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return cliente;
        }
		
        public List<Cliente> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Apellido], [Nombre], [Email], [Telefono], [URL], [FechaNacimiento], [Domicilio] FROM Cliente ";

            List<Cliente> result = new List<Cliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cliente Cliente = LoadCliente(dr);
                        result.Add(Cliente);
                    }
                }
            }
            var log = ServiceFactory.Get<ILoggingService>();
            log.Log("Listado de clientes");
            return result;
        }
		
        public Cliente ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Apellido], [Nombre], [Email], [Telefono], [URL], [FechaNacimiento], [Domicilio] FROM Cliente WHERE [Id]=@Id ";
            Cliente Cliente = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Cliente = LoadCliente(dr);
                    }
                }
            }
            return Cliente;
        }
		
        public void Update(Cliente cliente)
        {
            const string SQL_STATEMENT = "UPDATE Cliente SET [Apellido] = @Apellido, [Nombre] = @Nombre, [Email] = @Email, [Telefono] = @Telefono, [URL]=@URL, [FechaNacimiento]=@FechaNacimiento, [Domicilio]=@Domicilio WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, cliente.Apellido);
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, cliente.Nombre);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, cliente.Telefono);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, cliente.Email);
                db.AddInParameter(cmd, "@URL", DbType.AnsiString, cliente.URL);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.DateTime, cliente.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, cliente.Domicilio);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cliente.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Cliente WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private Cliente LoadCliente(IDataReader dr)
        {
            Cliente cliente = new Cliente();
            cliente.Id = GetDataValue<int>(dr, "Id");
            cliente.Nombre = GetDataValue<string>(dr, "Nombre");
            cliente.Apellido = GetDataValue<string>(dr, "Apellido");
            cliente.Telefono = GetDataValue<string>(dr, "Telefono");
            cliente.Email = GetDataValue<string>(dr, "Email");
            cliente.URL = GetDataValue<string>(dr, "URL");
            cliente.FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento");
            cliente.Domicilio = GetDataValue<string>(dr, "Domicilio");
            return cliente;
        }
    }
}

