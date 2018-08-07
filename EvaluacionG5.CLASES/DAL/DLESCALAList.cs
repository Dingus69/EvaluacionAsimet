
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLESCALAList.
	/// </summary>
    public class DLESCALAList : DLGenericBaseList<EESCALA>
	{
		public DLESCALAList()
		{
            this._proc_select_all = "proc_select_ESCALA_all";
		}
		
		#region Methods


        /// <summary>
        /// Selecciona todos los registros de la tabla.
        /// </summary>
        /// <returns>Una lista con los registros</returns>
        public List<EESCALA> SelectAll()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, null);

            return GetCollection(dr);
        }
        public List<EESCALA> SelectAll(Int64 RutEmpresa)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, _proc_select_all, prms);

            return GetCollection(dr);
        }
        public EESCALA GetESCALAINSTRUMENTOEMPRESA(Int64 RutEmpresa, Int16 CodEscala)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(2);

            prms[0] = db.GetParameter();
            prms[0].Value = RutEmpresa;
            prms[0].ParameterName = "@RUT_EMPRESA";

            prms[1] = db.GetParameter();
            prms[1].Value = CodEscala;
            prms[1].ParameterName = "@COD_ESCALA";

            IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, "proc_select_ESCALA_INSTRUMENTO_EMPRESA", prms);

            return GetCollection(dr)[0];
        }

        public Int16 Serial()
        {
            DB db = DatabaseFactory.Instance.GetDatabase();

            DataTable dr = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_select_SERIAL_ESCALA", null);

            return Utiles.ConvertToInt16(dr.Rows[0][0]);
        }

        public Boolean PoseeDatosRelacionados(Decimal CodEscala)
        {
            DB db = DatabaseFactory.Instance.GetDatabase();
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = CodEscala;
            prms[0].ParameterName = "@CODESCALA";

            DataTable dt = db.ExecuteDataTable(CommandType.StoredProcedure, "proc_POSEE_DATOS_RELACIONADOS", prms);
                
            return Utiles.ConvertToBoolean(dt.Rows[0][0]);
        }   

        #endregion
    }
}
