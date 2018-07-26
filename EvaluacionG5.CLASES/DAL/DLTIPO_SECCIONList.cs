
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOSECCIONList.
	/// </summary>
    public class DLTIPOSECCIONList : DLGenericBaseList<ETIPOSECCION>
	{
		public DLTIPOSECCIONList()
		{
            this._proc_select_all = "proc_select_TIPO_SECCION_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<ETIPOSECCION> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            DataTable dr = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_SERIAL_TIPO_SECCION", null);

            return Utiles.ConvertToInt16(dr.Rows[0][0]);
        }

        public Boolean PoseeDatosRelacionados(Decimal CodTipoSeccion)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodTipoSeccion;
            prms[0].ParameterName = "@CODTIPOSECCION";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_POSEE_DATOS_RELACIONADOS_TS", prms);

            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }

        #endregion
    }
}
