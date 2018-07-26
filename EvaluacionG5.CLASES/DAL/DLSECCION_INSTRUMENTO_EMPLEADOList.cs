
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSECCIONINSTRUMENTOEMPLEADOList.
	/// </summary>
    public class DLSECCIONINSTRUMENTOEMPLEADOList : DLGenericBaseList<ESECCIONINSTRUMENTOEMPLEADO>
	{
		public DLSECCIONINSTRUMENTOEMPLEADOList()
		{
            this._proc_select_all = "proc_select_SECCION_INSTRUMENTO_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ESECCIONINSTRUMENTOEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<ESECCIONINSTRUMENTOEMPLEADO> GetSeccionesInstrumentoEmpleado(Decimal CodInstrumentoEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodInstrumentoEmpleado;
            prms[0].ParameterName = "@CODINSTRUMENTOEMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_SECCIONES_POR_INSTRUMENTO_EMPLEADO", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
