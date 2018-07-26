
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSUCURSALList.
	/// </summary>
    public class DLSUCURSALList : DLGenericBaseList<ESUCURSAL>
	{
		public DLSUCURSALList()
		{
            this._proc_select_all = "proc_select_SUCURSAL_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ESUCURSAL> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public List<ESUCURSAL> SelectAll(Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
