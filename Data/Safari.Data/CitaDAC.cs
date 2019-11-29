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
    public partial class CitaDAC : DataAccessComponent, IRepository<Cita>
    {
        public Cita Create(Cita cita)
        {
            try
            {
                const string SQL_STATEMENT = "INSERT INTO Cita ([Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedDate] , [CreatedBy]) VALUES(@Fecha, @MedicoId, @PacienteId, @SalaId, @TipoServicioId, @Estado, @CreatedDate , @CreatedBy); SELECT SCOPE_IDENTITY();";

                var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
                using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
                {
                    db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                    db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                    db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                    db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                    db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                    db.AddInParameter(cmd, "@Estado", DbType.String, cita.Estado);
                    db.AddInParameter(cmd, "@CreatedDate", DbType.DateTime, cita.CreatedDate);
                    db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cita.CreatedBy);
                    cita.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
                }

            }
            catch (Exception ex)
            {
                var wrapper = new Exception("Error al agregar Especie a base de datos", ex);
                throw wrapper;
            }

            return cita;
        }
		
        public List<Cita> Read()
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedDate] , [CreatedBy], [ChangedDate], [ChangedBy], [DeletedDate], [DeletedBy], [Deleted] FROM Cita WHERE deleted = 0";

            List<Cita> result = new List<Cita>();
            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cita Cita = LoadCita(dr);
                        result.Add(Cita);
                    }
                }
            }
            return result;
        }
		
        public Cita ReadBy(int id)
        {
            const string SQL_STATEMENT = "SELECT [Id], [Fecha], [MedicoId], [PacienteId], [SalaId], [TipoServicioId], [Estado], [CreatedDate] , [CreatedBy], [ChangedDate], [ChangedBy], [DeletedDate], [DeletedBy], [Deleted] FROM Cita WHERE [Id]=@Id ";
            Cita Cita = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        Cita = LoadCita(dr);
                    }
                }
            }
            return Cita;
        }
		
        public void Update(Cita cita)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Fecha] = @Fecha, [MedicoId] = @MedicoId, [PacienteId] = @PacienteId, [SalaId] = @SalaId, [TipoServicioId] = @TipoServicioId, [Estado] = @Estado, [ChangedDate] = @ChangedDate, [ChangedBy] = @ChangedBy WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Fecha", DbType.DateTime, cita.Fecha);
                db.AddInParameter(cmd, "@MedicoId", DbType.Int32, cita.MedicoId);
                db.AddInParameter(cmd, "@PacienteId", DbType.Int32, cita.PacienteId);
                db.AddInParameter(cmd, "@SalaId", DbType.Int32, cita.SalaId);
                db.AddInParameter(cmd, "@TipoServicioId", DbType.Int32, cita.TipoServicioId);
                db.AddInParameter(cmd, "@Estado", DbType.AnsiString, cita.Estado);
                db.AddInParameter(cmd, "@ChangedDate", DbType.DateTime, cita.ChangedDate);
                db.AddInParameter(cmd, "@ChangedBy", DbType.AnsiString, cita.ChangedBy);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cita.Id);
                db.ExecuteNonQuery(cmd);
            }
        }
		
        public void Delete(int id)
        {
            const string SQL_STATEMENT = "UPDATE Cita SET [Deleted] = 1, [DeletedDate] = @DeletedDate, [DeletedBy] = @DeletedBy WHERE [Id]= @Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@DeletedDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(cmd, "@DeletedBy", DbType.AnsiString, "user");
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }

        }
		
        private Cita LoadCita(IDataReader dr)
        {
            Cita cita = new Cita();
            cita.Id = GetDataValue<int>(dr, "Id");
            cita.Fecha = GetDataValue<DateTime>(dr, "Fecha");
            cita.MedicoId = GetDataValue<int>(dr, "MedicoId");
            cita.Medico = cita.MedicoId > 0 ? new MedicoDAC().ReadBy(cita.MedicoId) : null;
            cita.PacienteId = GetDataValue<int>(dr, "PacienteId");
            cita.Paciente = cita.PacienteId > 0 ? new PacienteDAC().ReadBy(cita.PacienteId) : null;
            cita.SalaId = GetDataValue<int>(dr, "SalaId");
            cita.Sala = cita.SalaId > 0 ? new SalaDAC().ReadBy(cita.SalaId) : null;
            cita.TipoServicioId = GetDataValue<int>(dr, "TipoServicioId");
            cita.Estado = GetDataValue<string>(dr, "Estado");
            cita.CreatedDate = GetDataValue<DateTime>(dr, "CreatedDate");
            cita.CreatedBy = GetDataValue<int>(dr, "CreatedBy");
            cita.ChangedDate = GetDataValue<DateTime>(dr, "ChangedDate");
            cita.ChangedBy = GetDataValue<int>(dr, "ChangedBy");
            cita.DeletedDate = GetDataValue<DateTime>(dr, "DeletedDate");
            cita.Deleted = GetDataValue<bool>(dr, "Deleted");
            return cita;
        }
    }
}

