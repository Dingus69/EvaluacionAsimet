
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLTIPOSECCION.
	/// </summary>
	public class DLTIPOSECCION : DLBase
	{
		public DLTIPOSECCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_TIPO_SECCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_TIPO_SECCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_TIPO_SECCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_TIPO_SECCION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_TIPO_SECCION";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ETIPOSECCION objTIPOSECCION = obj as ETIPOSECCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOSECCION.CODTIPOSECCION;
            prms[0].ParameterName = "@COD_TIPO_SECCION";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOSECCION objTIPOSECCION = obj as ETIPOSECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOSECCION.CODTIPOSECCION;
            prms[0].ParameterName = "@COD_TIPO_SECCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOSECCION.NOMBRETIPOSECCION;
            prms[1].ParameterName = "@NOMBRE_TIPO_SECCION";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ETIPOSECCION objTIPOSECCION = obj as ETIPOSECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objTIPOSECCION.CODTIPOSECCION;
            prms[0].ParameterName = "@COD_TIPO_SECCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objTIPOSECCION.NOMBRETIPOSECCION;
            prms[1].ParameterName = "@NOMBRE_TIPO_SECCION";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ETIPOSECCION objRoot = obj as ETIPOSECCION;

            objRoot.CODTIPOSECCION = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ETIPOSECCION objTIPOSECCION = obj as ETIPOSECCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objTIPOSECCION.CODTIPOSECCION = Utiles.ConvertToInt16(dr["COD_TIPO_SECCION"]);
            
            objTIPOSECCION.NOMBRETIPOSECCION = Utiles.ConvertToString(dr["NOMBRE_TIPO_SECCION"]);
            
        }

        #endregion

	}
}
