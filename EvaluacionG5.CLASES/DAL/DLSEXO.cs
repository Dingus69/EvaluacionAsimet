
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSEXO.
	/// </summary>
	public class DLSEXO : DLBase
	{
		public DLSEXO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SEXO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SEXO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SEXO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SEXO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_SEXO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESEXO objSEXO = obj as ESEXO;

            prms[0] = db.GetParameter();
            prms[0].Value = objSEXO.CODSEXO;
            prms[0].ParameterName = "@COD_SEXO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ESEXO objSEXO = obj as ESEXO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSEXO.CODSEXO;
            prms[0].ParameterName = "@COD_SEXO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSEXO.NOMSEXO;
            prms[1].ParameterName = "@NOM_SEXO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ESEXO objSEXO = obj as ESEXO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSEXO.CODSEXO;
            prms[0].ParameterName = "@COD_SEXO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSEXO.NOMSEXO;
            prms[1].ParameterName = "@NOM_SEXO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESEXO objRoot = obj as ESEXO;

            objRoot.CODSEXO = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESEXO objSEXO = obj as ESEXO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objSEXO.CODSEXO = Utiles.ConvertToString(dr["COD_SEXO"]);
            
            objSEXO.NOMSEXO = Utiles.ConvertToString(dr["NOM_SEXO"]);
            
        }

        #endregion

	}
}
