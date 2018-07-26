
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESTADOINSTRUMENTOList.
	/// </summary>
    public class DLESTADOINSTRUMENTOList : DLGenericBaseList<EESTADOINSTRUMENTO>
	{
		public DLESTADOINSTRUMENTOList()
		{
            this._proc_select_all = "proc_select_ESTADO_INSTRUMENTO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EESTADOINSTRUMENTO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

		#endregion
	}
}
