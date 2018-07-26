
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAEMPLEADOList.
	/// </summary>
    public class DLPREGUNTAEMPLEADOList : DLGenericBaseList<EPREGUNTAEMPLEADO>
	{
		public DLPREGUNTAEMPLEADOList()
		{
            this._proc_select_all = "proc_select_PREGUNTA_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPREGUNTAEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<EPREGUNTAEMPLEADO> GetPreguntasSeccionEmpleado(Decimal CodSeccionEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodSeccionEmpleado;
            prms[0].ParameterName = "@CODSECCIONEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PREGUNTAS_POR_SECCION_EMPLEADO", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
