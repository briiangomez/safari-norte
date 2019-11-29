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
    public partial class SalaDAC : DataAccessComponent, IRepository<Sala>
    {
        public Sala Create(Sala Sala)
        {
            const string SQL_STATEMENT = "INSERT INTO Sala ([Nombre], [TipoSala]) VALUES(@Nombre, @TipoSala); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Sala.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, Sala.TipoSala);
                Sala.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return Sala;
        }

        public List<Sala> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala ";

            List<Sala> result = new List<Sala>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Sala Sala = LoadSala(dr);
                        result.Add(Sala);
                    }
                }
            }
            return result;
        }

        public Sala ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Nombre], [TipoSala] FROM Sala WHERE [Id]=@Id ";
            Sala Sala = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Sala = LoadSala(dr);
                    }
                }
            }
            return Sala;
        }

        public void Update(Sala Sala)
        {
            const string SQL_STATEMENT = "UPDATE Sala SET [Nombre]= @Nombre, [TipoSala]=@TipoSala WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Nombre", DbType.AnsiString, Sala.Nombre);
                db.AddInParameter(cmd, "@TipoSala", DbType.AnsiString, Sala.TipoSala);
                db.AddInParameter(cmd, "@Id", DbType.Int32, Sala.Id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Delete(int id)
        {
            const string SQL_STATEMENT = "DELETE Sala WHERE [Id]= @Id ";
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        private Sala LoadSala(IDataReader dr)
        {
            Sala Sala = new Sala();
            Sala.Id = GetDataValue<int>(dr, "Id");
            Sala.Nombre = GetDataValue<string>(dr, "Nombre");
            Sala.TipoSala = GetDataValue<string>(dr, "TipoSala");
            return Sala;
        }
    }
}

