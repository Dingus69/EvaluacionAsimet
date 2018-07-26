
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPERFILList.
	/// </summary>
    public class DLPERFILList : DLGenericBaseList<EPERFIL>
	{
		public DLPERFILList()
		{
            this._proc_select_all = "proc_select_PERFIL_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EPERFIL> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EPERFIL> GetPerfilesAsignados(Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RutUsuario";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PERFILES_ASIGNADOS", prms);

            return GetCollection(dr);
        }
        public List<EPERFIL> GetPerfilesDisponibles(Int64 RutUsuario)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutUsuario;
            prms[0].ParameterName = "@RutUsuario";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_PERFILES_DISPONIBLES", prms);

            return GetCollection(dr);
        }

        #endregion
    }
}
