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
    public partial class PrecioDAC : DataAccessComponent, IRepositoryObject<Precio>
    {
        public Precio Create(Precio precio)
        {
            const string SQL_STATEMENT = "INSERT INTO Precio ([TipoServicioId], [FechaDesde], [FechaHasta], [Valor]) VALUES(@TipoServicioId, @FechaDesde, @FechaHasta, @Valor); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.AnsiString, precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, precio.FechaHasta);
                db.AddInParameter(cmd, "@Valor", DbType.Int32, precio.Valor);
                db.ExecuteScalar(cmd);
            }
            return precio;
        }
		
        public List<Precio> Read()
        {
            const string SQL_STATEMENT = "SELECT [TipoServicioId], [FechaDesde], [FechaHasta], [Valor] FROM Precio ";

            List<Precio> result = new List<Precio>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Precio Precio = LoadPrecio(dr);
                        result.Add(Precio);
                    }
                }
            }
            return result;
        }
                
        public Precio ReadBy(Precio precio)
        {
            const string SQL_STATEMENT = "SELECT [TipoServicioId], [FechaDesde], [FechaHasta], [Valor] FROM Precio WHERE [TipoServicioId] = @TipoServicioId AND [FechaDesde] = @FechaDesde AND [FechaHasta] = @FechaHasta ";
            Precio Precio = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, Precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, Precio.FechaDesde);
                db.AddInParameter(cmd, "@IdFechaHasta", DbType.DateTime, Precio.FechaHasta);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Precio = LoadPrecio(dr);
                    }
                }
            }
            return Precio;
        }
		
        public void Update(Precio precio)
        {
            const string SQL_STATEMENT = "UPDATE Precio SET [Valor] = @Valor WHERE [TipoServicioId] = @TipoServicioId AND [FechaDesde] = @FechaDesde AND [FechaHasta] = @FechaHasta";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Valor", DbType.AnsiString, precio.Valor);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, precio.FechaHasta);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(Precio precio)
        {
            const string SQL_STATEMENT = "DELETE Precio WHERE [TipoServicioId]= @TipoServicioId AND [FechaDesde] = @FechaDesde AND [FechaHasta] = @FechaHasta ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, precio.TipoServicioId);
                db.AddInParameter(cmd, "@FechaDesde", DbType.DateTime, precio.FechaDesde);
                db.AddInParameter(cmd, "@FechaHasta", DbType.DateTime, precio.FechaHasta);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        private Precio LoadPrecio(IDataReader dr)
        {
            Precio precio = new Precio();
            precio.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            precio.TipoServicio = precio.TipoServicioId > 0 ? new TipoServicioDAC().ReadBy(precio.TipoServicioId) : new TipoServicio();
            precio.FechaDesde = GetDataValue<DateTime>(dr, "FechaDesde");
            precio.FechaHasta = GetDataValue<DateTime>(dr, "FechaHasta");
            precio.Valor = GetDataValue<float>(dr, "Valor");
            return precio;
        }
    }
}

