
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCORREO.
	/// </summary>
	public class DLCORREO : DLBase
	{
		public DLCORREO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CORREO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CORREO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CORREO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CORREO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CORREO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECORREO objCORREO = obj as ECORREO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCORREO.CODCORREO;
            prms[0].ParameterName = "@COD_CORREO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECORREO objCORREO = obj as ECORREO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objCORREO.CODCORREO;
            prms[0].ParameterName = "@CODCORREO";

            prms[1] = db.GetParameter();
            prms[1].Value = objCORREO.ASUNTO;
            prms[1].ParameterName = "@ASUNTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCORREO.CUERPO;
            prms[2].ParameterName = "@CUERPO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECORREO objCORREO = obj as ECORREO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCORREO.CODCORREO;
            prms[0].ParameterName = "@COD_CORREO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCORREO.ASUNTO;
            prms[1].ParameterName = "@ASUNTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objCORREO.CUERPO;
            prms[2].ParameterName = "@CUERPO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECORREO objRoot = obj as ECORREO;

            objRoot.CODCORREO = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECORREO objCORREO = obj as ECORREO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCORREO.CODCORREO = Utiles.ConvertToInt16(dr["COD_CORREO"]);
            
            objCORREO.ASUNTO = Utiles.ConvertToString(dr["ASUNTO"]);
            
            objCORREO.CUERPO = Utiles.ConvertToString(dr["CUERPO"]);
            
        }

        #endregion

	}
}
