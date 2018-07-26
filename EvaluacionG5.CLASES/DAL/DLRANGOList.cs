
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLRANGOList.
	/// </summary>
    public class DLRANGOList : DLGenericBaseList<ERANGO>
	{
		public DLRANGOList()
		{
            this._proc_select_all = "proc_select_RANGO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ERANGO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<ERANGO> GetRangosPorEscala(Decimal CodEscala)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEscala;
            prms[0].ParameterName = "@CODESCALA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_RANGOS_POR_ESCALA", prms);

            return GetCollection(dr);
        }

        public void DeletePorEscala(Decimal CodEscala)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEscala;
            prms[0].ParameterName = "@CODESCALA";

            db.ExecuteNonQuery(CommandType.StoredProcedure, "proc_delete_RANGO_POR_ESCALA", prms);
        }

        #endregion
    }
}
