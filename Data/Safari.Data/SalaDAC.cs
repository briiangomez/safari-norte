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
    public class SalaDAC : DataAccessComponent, IRepository<Sala>
    {
        public Sala Create(Sala entity)
        {
            const string SQL_STATEMENT = @"INSERT INTO dbo.Sala (Nombre, TipoSala)
                                    SELECT @Nombre, @TipoSala; SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.Int16, entity.TipoSala);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = @"DELETE
                                            FROM   dbo.Sala
                                            WHERE  Id = @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<Sala> Read()
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre, Multiplicador 
                                            FROM   dbo.TipoMovimiento";

            List<Sala> result = new List<Sala>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Sala entidad = LoadEntity(dr);
                        result.Add(entidad);
                    }
                }
            }
            return result;
        }

        public Sala ReadBy(int id)
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre, TipoSala 
                                            FROM   dbo.Sala
                                            WHERE  Id = @Id";
            Sala entidad = null;

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

        public void Update(Sala entity)
        {
            const string SQL_STATEMENT = @"UPDATE dbo.Sala
                                                SET    Nombre = @Nombre, TipoSala = @TipoSala
                                                WHERE  Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.String, entity.TipoSala);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Sala LoadEntity(IDataReader dr)
        {
            Sala entidad = new Sala
            {
                Id = GetDataValue<int>(dr, "Id"),
                Nombre = GetDataValue<string>(dr, "Nombre"),
                TipoSala = GetDataValue<string>(dr, "TipoSala")
            };
            return entidad;
        }
    }
}
