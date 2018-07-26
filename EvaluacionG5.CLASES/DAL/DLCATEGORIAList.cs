
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCATEGORIAList.
	/// </summary>
    public class DLCATEGORIAList : DLGenericBaseList<ECATEGORIA>
	{
		public DLCATEGORIAList()
		{
            this._proc_select_all = "proc_select_CATEGORIA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ECATEGORIA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<ECATEGORIA> GetCategoriasPorEscala(Decimal CodEscala)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEscala;
            prms[0].ParameterName = "@CODESCALLA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_CATEGORIAS_POR_ESCALA", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
