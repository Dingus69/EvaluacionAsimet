
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLBITACORAList.
	/// </summary>
    public class DLBITACORAList : DLGenericBaseList<EBITACORA>
	{
		public DLBITACORAList()
		{
            this._proc_select_all = "proc_select_BITACORA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EBITACORA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public DataTable GetBitacoraEmpleado(Int64 RutEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpleado;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BITACORA_EMPLEADO", prms);

            return dt;
        }

        public DataTable GetBitacoraInstrumento(Decimal CodInstrumento)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumento;
            prms[0].ParameterName = "@CODINSTRUMENTO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BITACORA_INSTRUMENTO", prms);

            return dt;
        }

        public DataTable GetBitacoraInstrumentoEmpleado(Decimal CodInstrumentoEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_BITACORA_INSTRUMENTO_EMPLEADO", prms);

            return dt;
        }

        #endregion
    }
}
