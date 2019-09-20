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
    public class MascotaDAC : DataAccessComponent, IRepository<Mascota>
    {
        public Mascota Create(Mascota entity)
        {
            const string SQL_STATEMENT = @"INSERT INTO dbo.Paciente (ClienteId, Nombre, FechaNacimiento, EspecieId, Observacion)
    SELECT @ClienteId, @Nombre, @FechaNacimiento, @EspecieId, @Observacion; SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, entity.ClienteId);
                db.AddInParameter(cmd, "@EspecieId", DbType.Int32, entity.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, entity.Observacion);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, entity.FechaNacimiento);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = @"DELETE
                                            FROM   dbo.Paciente
                                            WHERE  Id = @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Mascota> Read()
        {
            const string SQL_STATEMENT = @"SELECT Id, Apellido, Nombre, Email, Telefono, Url, FechaNacimiento, Domicilio 
                    FROM   dbo.Cliente";

            List<Mascota> result = new List<Mascota>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Mascota entidad = LoadEntity(dr);
                        result.Add(entidad);
                    }
                }
            }
            return result;
        }

        private Mascota LoadEntity(IDataReader dr)
        {
            Mascota entidad = new Mascota
            {
                Id = GetDataValue<int>(dr, "Id"),
                Nombre = GetDataValue<string>(dr, "Nombre"),
                ClienteId = GetDataValue<int>(dr, "ClienteId"),
                EspecieId = GetDataValue<int>(dr, "EspecieId"),
                Observacion = GetDataValue<string>(dr, "Observacion"),
                Especie = ObtenerEspecie(GetDataValue<int>(dr, "EspecieId")),
                FechaNacimiento = GetDataValue<DateTime>(dr, "FechaNacimiento")
            };
            return entidad;
        }

        private Especie ObtenerEspecie(int especieID)
        {
            return new EspecieDAC().ReadBy(especieID);
        }

        public Mascota ReadBy(int id)
        {
            const string SQL_STATEMENT = @"SELECT Id, ClienteId, Nombre, FechaNacimiento, EspecieId, Observacion 
                                            FROM   dbo.Paciente
                                            WHERE  Id = @Id ";
            Mascota entidad = null;

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

        public void Update(Mascota entity)
        {
            const string SQL_STATEMENT = @"UPDATE dbo.Paciente
            SET    ClienteId = @ClienteId, Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, EspecieId = @EspecieId, 
                   Observacion = @Observacion
            WHERE  Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, entity.ClienteId);
                db.AddInParameter(cmd, "@EspecieId", DbType.Int32, entity.EspecieId);
                db.AddInParameter(cmd, "@Observacion", DbType.AnsiString, entity.Observacion);
                db.AddInParameter(cmd, "@FechaNacimiento", DbType.Date, entity.FechaNacimiento);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Mascota> ObtenerMascotaCliente(int idCliente)
        {
            const string SQL_STATEMENT = @"SELECT Id, Apellido, Nombre, Email, Telefono, Url, FechaNacimiento, Domicilio 
                    FROM   dbo.Cliente
                    WHERE  ClienteId = @ClienteId";

            List<Mascota> result = new List<Mascota>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, idCliente);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Mascota entidad = LoadEntity(dr);
                        result.Add(entidad);
                    }
                }
            }
            return result;
        }
    }
}
