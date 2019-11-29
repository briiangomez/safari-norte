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
    public partial class TipoMovimientoDAC : DataAccessComponent, IRepository<TipoMovimiento>
    {
        public TipoMovimiento Create(TipoMovimiento TipoMovimiento)
        {
            const string SQL_STATEMENT = "INSERT INTO TipoMovimiento ([Nombre], [Multiplicador]) VALUES(@Nombre, @Multiplicador); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, TipoMovimiento.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, TipoMovimiento.Multiplicador);
                TipoMovimiento.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return TipoMovimiento;
        }
		
        public List<TipoMovimiento> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Multiplicador] FROM TipoMovimiento ";

            List<TipoMovimiento> result = new List<TipoMovimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        TipoMovimiento TipoMovimiento = LoadTipoMovimiento(dr);
                        result.Add(TipoMovimiento);
                    }
                }
            }
            return result;
        }
		
        public TipoMovimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [Multiplicador] FROM TipoMovimiento WHERE [Id]=@Id ";
            TipoMovimiento TipoMovimiento = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        TipoMovimiento = LoadTipoMovimiento(dr);
                    }
                }
            }
            return TipoMovimiento;
        }
		
        public void Update(TipoMovimiento TipoMovimiento)
        {
            const string SQL_STATEMENT = "UPDATE TipoMovimiento SET [Nombre]= @Nombre, [Multiplicador]= @Multiplicador WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, TipoMovimiento.Nombre);
                db.AddInParameter(cmd, "@Multiplicador", DbType.Int16, TipoMovimiento.Multiplicador);
                db.AddInParameter(cmd, "@Id", DbType.Int32, TipoMovimiento.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE TipoMovimiento WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private TipoMovimiento LoadTipoMovimiento(IDataReader dr)
        {
            TipoMovimiento TipoMovimiento = new TipoMovimiento();
            TipoMovimiento.Id = GetDataValue<int>(dr, "Id");
            TipoMovimiento.Nombre = GetDataValue<string>(dr, "Nombre");
            TipoMovimiento.Multiplicador = GetDataValue<Int16>(dr, "Multiplicador");
            return TipoMovimiento;
        }
    }
}

