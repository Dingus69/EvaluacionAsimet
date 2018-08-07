
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLOBJETIVOPROXIMOList.
	/// </summary>
    public class DLOBJETIVOPROXIMOList : DLGenericBaseList<EOBJETIVOPROXIMO>
	{
		public DLOBJETIVOPROXIMOList()
		{
            this._proc_select_all = "proc_select_OBJETIVO_PROXIMO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EOBJETIVOPROXIMO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EOBJETIVOPROXIMO> GetObjetivosProximos(Decimal CodInstrumentoEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_OBJETIVOS_PROXIMOS_INSTRUMENTO", prms);

            return GetCollection(dr);
        }

        public List<EOBJETIVOPROXIMO> GetObjetivosActuales(Decimal CodInstrumentoEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_OBJETIVOS_ACTUALES_INSTRUMENTO", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
