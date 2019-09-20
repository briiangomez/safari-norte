using Microsoft.Practices.EnterpriseLibrary.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public class ClienteDAC : DataAccessComponent, IRepository<Cliente>
    {
        public Cliente Create(Cliente entity)
        {
            const string SQL_STATEMENT = @"INSERT INTO dbo.Cliente (Apellido, Nombre, Email, Telefono, Url, FechaNacimiento, Domicilio)
                SELECT @Apellido, @Nombre, @Email, @Telefono, @Url, @FechaNacimiento, @Domicilio; SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, entity.Url);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, entity.FechaNacimiento);
                db.AddInParameter(cmd, "@Domicilio", DbType.String, entity.Domicilio);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = @"DELETE
                                            FROM   dbo.Cliente
                                            WHERE  Id = @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Cliente> Read()
        {
            const string SQL_STATEMENT = @"SELECT Id, Apellido, Nombre, Email, Telefono, Url, FechaNacimiento, Domicilio 
                    FROM   dbo.Cliente";

            List<Cliente> result = new List<Cliente>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cliente entidad = LoadEntity(dr);
                        result.Add(entidad);
                    }
                }
            }
            return result;
        }

        private Cliente LoadEntity(IDataReader dr)
        {
            Cliente entidad = new Cliente
            {
                Id = GetDataValue<int>(dr, "Id"),
                Nombre = GetDataValue<string>(dr, "Nombre"),
                Apellido = GetDataValue<string>(dr, "Apellido"),
                Email = GetDataValue<string>(dr, "Email"),
                Domicilio = GetDataValue<string>(dr, "Domicilio"),
                Telefono = GetDataValue<string>(dr, "Telefono"),
                Url = GetDataValue<string>(dr, "Url"),
                FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento"),
                Mascotas = ObtenerMascotas(GetDataValue<int>(dr, "Id"))
            };
            return entidad;
        }

        private List<Mascota> ObtenerMascotas(int IdCliente)
        {
            return new MascotaDAC().ObtenerMascotaCliente(IdCliente);
        }

        public Cliente ReadBy(int id)
        {
            const string SQL_STATEMENT = @"SELECT Id, Apellido, Nombre, Email, Telefono, Url, FechaNacimiento, Domicilio 
                                            FROM   dbo.Cliente
                                            WHERE  Id = @Id ";
            Cliente entidad = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        entidad = LoadEntity(dr);
                    }
                }
            }
            return entidad;
        }

        public void Update(Cliente entity)
        {
            const string SQL_STATEMENT = @"UPDATE dbo.Cliente
                                            SET    Apellido = @Apellido, Nombre = @Nombre, Email = @Email, Telefono = @Telefono, Url = @Url, 
                                                   FechaNacimiento = @FechaNacimiento, Domicilio = @Domicilio
                                            WHERE  Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Apellido", DbType.AnsiString, entity.Apellido);
                db.AddInParameter(cmd, "@Email", DbType.AnsiString, entity.Email);
                db.AddInParameter(cmd, "@Telefono", DbType.AnsiString, entity.Telefono);
                db.AddInParameter(cmd, "@Url", DbType.AnsiString, entity.Url);
                db.AddInParameter(cmd, "@Domicilio", DbType.AnsiString, entity.Domicilio);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, entity.FechaNacimiento);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
