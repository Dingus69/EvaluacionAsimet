
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLOBJETIVOINSTRUMENTOEMPLEADOList.
	/// </summary>
    public class DLOBJETIVOINSTRUMENTOEMPLEADOList : DLGenericBaseList<EOBJETIVOINSTRUMENTOEMPLEADO>
	{
		public DLOBJETIVOINSTRUMENTOEMPLEADOList()
		{
            this._proc_select_all = "proc_select_OBJETIVO_INSTRUMENTO_EMPLEADO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EOBJETIVOINSTRUMENTOEMPLEADO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

		#endregion
	}
}
