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
    public class TipoMovimientoDAC : DataAccessComponent, IRepository<TipoMovimiento>
    {
        public TipoMovimiento Create(TipoMovimiento entity)
        {
            const string SQL_STATEMENT = @"INSERT INTO dbo.TipoMovimiento (Nombre, Multiplicador)
                                            SELECT @Nombre, @Multiplicador; SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, entity.Multiplicador);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = @"DELETE
                                            FROM   dbo.TipoMovimiento
                                            WHERE  Id = @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<TipoMovimiento> Read()
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre, Multiplicador 
                                            FROM   dbo.TipoMovimiento";

            List<TipoMovimiento> result = new List<TipoMovimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoMovimiento especie = LoadTipoMovimiento(dr);
                        result.Add(especie);
                    }
                }
            }
            return result;
        }

        public TipoMovimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre, Multiplicador 
                                            FROM   dbo.TipoMovimiento
                                            WHERE  Id = @Id ";
            TipoMovimiento entidad = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        entidad = LoadTipoMovimiento(dr);
                    }
                }
            }
            return entidad;
        }

        public void Update(TipoMovimiento entity)
        {
            const string SQL_STATEMENT = @"UPDATE dbo.TipoMovimiento
                                    SET    Nombre = @Nombre, Multiplicador = @Multiplicador
                                    WHERE  Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, entity.Multiplicador);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private TipoMovimiento LoadTipoMovimiento(IDataReader dr)
        {
            TipoMovimiento entidad = new TipoMovimiento
            {
                Id = GetDataValue<int>(dr, "Id"),
                Nombre = GetDataValue<string>(dr, "Nombre"),
                Multiplicador = GetDataValue<int>(dr, "Multiplicador")
            };
            return entidad;
        }
    }

}
