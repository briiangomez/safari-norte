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
    public partial class TipoServicioDAC : DataAccessComponent, IRepository<TipoServicio>
    {
        public TipoServicio Create(TipoServicio TipoServicio)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoServicio ([Nombre]) VALUES(@Nombre); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, TipoServicio.Nombre);
                TipoServicio.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return TipoServicio;
        }
		
        public List<TipoServicio> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio ";

            List<TipoServicio> result = new List<TipoServicio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoServicio TipoServicio = LoadTipoServicio(dr);
                        result.Add(TipoServicio);
                    }
                }
            }
            return result;
        }
		
        public TipoServicio ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre] FROM TipoServicio WHERE [Id]=@Id ";
            TipoServicio TipoServicio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        TipoServicio = LoadTipoServicio(dr);
                    }
                }
            }
            return TipoServicio;
        }
		
        public void Update(TipoServicio TipoServicio)
        {
            const string SQL_STATEMENT = "UPDATE TipoServicio SET [Nombre]= @Nombre WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, TipoServicio.Nombre);
                db.AddInParameter(cmd, "@Id", DbType.Int32, TipoServicio.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoServicio WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private TipoServicio LoadTipoServicio(IDataReader dr)
        {
            TipoServicio TipoServicio = new TipoServicio();
            TipoServicio.Id = GetDataValue<int>(dr, "Id");
            TipoServicio.Nombre = GetDataValue<string>(dr, "Nombre");
            return TipoServicio;
        }
    }
}

