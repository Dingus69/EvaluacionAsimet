
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAList.
	/// </summary>
    public class DLPREGUNTAList : DLGenericBaseList<EPREGUNTA>
	{
		public DLPREGUNTAList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EPREGUNTA> GetPreguntasSeccion(Decimal CodSeccion)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodSeccion;
            prms[0].ParameterName = "@CODSECCION";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PREGUNTAS_POR_SECCION", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
