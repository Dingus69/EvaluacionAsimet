
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLGRADO.
	/// </summary>
	public class DLGRADO : DLBase
	{
		public DLGRADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_GRADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_GRADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_GRADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_GRADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_GRADO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EGRADO objGRADO = obj as EGRADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objGRADO.CODGRADO;
            prms[0].ParameterName = "@COD_GRADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EGRADO objGRADO = obj as EGRADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objGRADO.CODGRADO;
            prms[0].ParameterName = "@COD_GRADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objGRADO.NOMBREGRADO;
            prms[1].ParameterName = "@NOMBRE_GRADO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            EGRADO objGRADO = obj as EGRADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objGRADO.CODGRADO;
            prms[0].ParameterName = "@COD_GRADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objGRADO.NOMBREGRADO;
            prms[1].ParameterName = "@NOMBRE_GRADO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EGRADO objRoot = obj as EGRADO;

            objRoot.CODGRADO = Utiles.ConvertToInt16(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EGRADO objGRADO = obj as EGRADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objGRADO.CODGRADO = Utiles.ConvertToInt16(dr["COD_GRADO"]);
            
            objGRADO.NOMBREGRADO = Utiles.ConvertToString(dr["NOMBRE_GRADO"]);
            
        }

        #endregion

	}
}
