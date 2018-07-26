
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCLASIFICADOR1.
	/// </summary>
	public class DLCLASIFICADOR1 : DLBase
	{
		public DLCLASIFICADOR1()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CLASIFICADOR_1";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CLASIFICADOR_1";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CLASIFICADOR_1";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CLASIFICADOR_1";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_CLASIFICADOR_1";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECLASIFICADOR1 objCLASIFICADOR1 = obj as ECLASIFICADOR1;

            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR1.CODCLASIFICADOR1;
            prms[0].ParameterName = "@COD_CLASIFICADOR_1";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECLASIFICADOR1 objCLASIFICADOR1 = obj as ECLASIFICADOR1;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR1.CODCLASIFICADOR1;
            prms[0].ParameterName = "@COD_CLASIFICADOR_1";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCLASIFICADOR1.NOMBRECLASIFICADOR1;
            prms[1].ParameterName = "@NOMBRE_CLASIFICADOR_1";

            prms[2] = db.GetParameter();
            prms[2].Value = objCLASIFICADOR1.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            ECLASIFICADOR1 objCLASIFICADOR1 = obj as ECLASIFICADOR1;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCLASIFICADOR1.CODCLASIFICADOR1;
            prms[0].ParameterName = "@COD_CLASIFICADOR_1";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCLASIFICADOR1.NOMBRECLASIFICADOR1;
            prms[1].ParameterName = "@NOMBRE_CLASIFICADOR_1";

            prms[2] = db.GetParameter();
            prms[2].Value = objCLASIFICADOR1.RUT_EMPRESA;
            prms[2].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECLASIFICADOR1 objRoot = obj as ECLASIFICADOR1;

            objRoot.CODCLASIFICADOR1 = Utiles.ConvertToString(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECLASIFICADOR1 objCLASIFICADOR1 = obj as ECLASIFICADOR1;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCLASIFICADOR1.CODCLASIFICADOR1 = Utiles.ConvertToString(dr["COD_CLASIFICADOR_1"]);
            
            objCLASIFICADOR1.NOMBRECLASIFICADOR1 = Utiles.ConvertToString(dr["NOMBRE_CLASIFICADOR_1"]);

            objCLASIFICADOR1.RUT_EMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

        }

        #endregion

	}
}
