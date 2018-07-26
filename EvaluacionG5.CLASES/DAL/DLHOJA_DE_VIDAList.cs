
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLHOJADEVIDAList.
	/// </summary>
    public class DLHOJADEVIDAList : DLGenericBaseList<EHOJADEVIDA>
	{
		public DLHOJADEVIDAList()
		{
            this._proc_select_all = "proc_select_HOJA_DE_VIDA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EHOJADEVIDA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EHOJADEVIDA> GetHOJADEVIDABYRUTEMPLEADO(Int64 RutEmpleado)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpleado;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_HOJA_DE_VIDA_BY_RUT_EMPLEADO", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
