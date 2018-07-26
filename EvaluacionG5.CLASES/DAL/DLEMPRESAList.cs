
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLEMPRESAList.
	/// </summary>
    public class DLEMPRESAList : DLGenericBaseList<EEMPRESA>
	{
		public DLEMPRESAList()
		{
            this._proc_select_all = "proc_select_EMPRESA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EEMPRESA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EEMPRESA> SelectAll(Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }

        public List<EEMPRESA> GetEmpresasByRutOrName(Int64 RutEmpresa, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2); 

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBRE";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_EMPRESA_BY_RUT_OR_NAME", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
