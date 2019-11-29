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
    public partial class MovimientoDAC : DataAccessComponent, IRepository<Movimiento>
    {
        public Movimiento Create(Movimiento movimiento)
        {
            const string SQL_STATEMENT = "INSERT INTO Movimiento ([Fecha], [ClienteId], [TipoMovimientoId], [Valor]) VALUES(@Fecha, @ClienteId, @TipoMovimientoId, @Valor); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.DateTime, movimiento.Fecha);
                db.AddInParameter(cmd, "@ClienteId", DbType.Int32, movimiento.ClienteId);
                db.AddInParameter(cmd, "@TipoMovimientoId", DbType.Int32, movimiento.TipoMovimientoId);
                db.AddInParameter(cmd, "@Valor", DbType.Double, movimiento.Valor);
                movimiento.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return movimiento;
        }
		
        public List<Movimiento> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [ClienteId], [TipoMovimientoId], [Valor] FROM Movimiento ";

            List<Movimiento> result = new List<Movimiento>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Movimiento Movimiento = LoadMovimiento(dr);
                        result.Add(Movimiento);
                    }
                }
            }
            return result;
        }
		
        public Movimiento ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [ClienteId], [TipoMovimientoId], [Valor] FROM Movimiento WHERE [Id]=@Id ";
            Movimiento Movimiento = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Movimiento = LoadMovimiento(dr);
                    }
                }
            }
            return Movimiento;
        }

        public void Update(Movimiento movimiento)
        {
        }

        public void Delete(int id)
        {
        }

        private Movimiento LoadMovimiento(IDataReader dr)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.Id = GetDataValue<int>(dr, "Id");
            movimiento.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            movimiento.ClienteId = GetDataValue<int>(dr, "ClienteId");
            movimiento.Cliente = movimiento.ClienteId > 0 ? new ClienteDAC().ReadBy(movimiento.ClienteId) : new Cliente();
            movimiento.TipoMovimientoId = GetDataValue<int>(dr, "TipoMovimientoId");
            movimiento.TipoMovimiento = movimiento.TipoMovimientoId > 0 ? new TipoMovimientoDAC().ReadBy(movimiento.TipoMovimientoId) : new TipoMovimiento();
            movimiento.Valor = GetDataValue<Decimal>(dr, "Valor");
            return movimiento;
        }
    }
}

