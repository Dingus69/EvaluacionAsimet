
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUSUARIOList.
	/// </summary>
    public class DLUSUARIOList : DLGenericBaseList<EUSUARIO>
	{
		public DLUSUARIOList()
		{
            this._proc_select_all = "proc_select_USUARIO_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EUSUARIO> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public DataTable GetUsuariosDT(Int64 Rut, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBRE";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_GET_USUARIOS", prms);

            return dt;
        }
        public List<EUSUARIO> GetUsuarios(Int64 Rut, string Nombre)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = Rut;
            prms[0].ParameterName = "@RUT_USUARIO";

            prms[1] = db.GetParameter();
            prms[1].Value = Nombre;
            prms[1].ParameterName = "@NOMBRE";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_GET_USUARIOS", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
