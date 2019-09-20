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
    public class TipoServicioDAC : DataAccessComponent, IRepository<TipoServicio>
    {
        public TipoServicio Create(TipoServicio entity)
        {
            const string SQL_STATEMENT = @"INSERT INTO dbo.TipoServicio (Nombre)
                                            SELECT @Nombre; SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                entity.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return entity;
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = @"DELETE
                                            FROM   dbo.TipoServicio
                                            WHERE  Id = @Id";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public List<TipoServicio> Read()
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre 
                                             FROM dbo.TipoServicio";

            List<TipoServicio> result = new List<TipoServicio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoServicio especie = LoadTipoServicio(dr);
                        result.Add(especie);
                    }
                }
            }
            return result;
        }

        public TipoServicio ReadBy(int id)
        {
            const string SQL_STATEMENT = @"SELECT Id, Nombre 
                                                FROM   dbo.TipoServicio
                                                WHERE  Id = @Id  ";
            TipoServicio especie = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        especie = LoadTipoServicio(dr);
                    }
                }
            }
            return especie;
        }

        public void Update(TipoServicio entity)
        {
            const string SQL_STATEMENT = @"UPDATE dbo.TipoServicio
                                            SET    Nombre = @Nombre
                                                WHERE Id = @Id";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, entity.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, entity.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private TipoServicio LoadTipoServicio(IDataReader dr)
        {
            TipoServicio entidad = new TipoServicio();
            entidad.Id = GetDataValue<int>(dr, "Id");
            entidad.Nombre = GetDataValue<string>(dr, "Nombre");
            return entidad;
        }
    }

}
