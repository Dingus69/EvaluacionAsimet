
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCURSOList.
	/// </summary>
    public class DLCURSOList : DLGenericBaseList<ECURSO>
	{
		public DLCURSOList()
		{
            this._proc_select_all = "proc_select_CURSO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECURSO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public ECURSO GetCursoByCodigo(string Codigo)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = Codigo;
            prms[0].ParameterName = "@CODIGO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CURSO_BY_CODIGO", prms);

            return GetCollection(dr)[0];
        }

        public List<ECURSO> GetCursosByNombreAndArea(string NombreCurso, Decimal CodArea)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2); 

            prms[0] = db.GetParameter();
            prms[0].Value = NombreCurso;
            prms[0].ParameterName = "@NOM_CURSO";

            prms[1] = db.GetParameter();
            prms[1].Value = CodArea;
            prms[1].ParameterName = "@COD_AREA_CURSO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CURSO_BY_NOM_AND_AREA", prms);

            return GetCollection(dr);
        }

        public DataTable GetCursosDisponiblesArea(Decimal CodInstrumento, Decimal CodArea)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = CodArea;
            prms[1].ParameterName = "@CODAREACURSO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CURSOS_DISPONIBLES_AREA", prms);

            return dt;
        }

        public DataTable GetCursosAsignadosArea(Decimal CodInstrumento, Decimal CodArea)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            prms[1] = db.GetParameter();
            prms[1].Value = CodArea;
            prms[1].ParameterName = "@CODAREACURSO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_CURSOS_ASIGNADOS_AREA", prms);

            return dt;
        }
        public List<ECURSO> GetCursosByInstrumento(Decimal CodInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO"; 

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CURSO_BY_INSTRUMENTO", prms);

            return GetCollection(dr);
        }

        public List<ECURSO> GetCursosByInstrumentoEmpleado(Decimal CodInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CURSO_BY_INSTRUMENTO_EMPLEADO", prms);

            return GetCollection(dr);
        }


        #endregion
    }
}
