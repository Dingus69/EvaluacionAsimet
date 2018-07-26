
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLUNIDAD.
	/// </summary>
	public class DLUNIDAD : DLBase
	{
		public DLUNIDAD()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_UNIDAD";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_UNIDAD";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_UNIDAD";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_UNIDAD";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDAD.CODUNIDAD;
            prms[1].ParameterName = "@COD_UNIDAD";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUNIDAD.NOMUNIDAD;
            prms[2].ParameterName = "@NOM_UNIDAD";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(3);
            EUNIDAD objUNIDAD = obj as EUNIDAD;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objUNIDAD.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objUNIDAD.CODUNIDAD;
            prms[1].ParameterName = "@COD_UNIDAD";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objUNIDAD.NOMUNIDAD;
            prms[2].ParameterName = "@NOM_UNIDAD";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EUNIDAD objRoot = obj as EUNIDAD;

            objRoot.RUTEMPRESA = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EUNIDAD objUNIDAD = obj as EUNIDAD;
    
            //Poner las rutinas del Tools que se necesiten
            
            objUNIDAD.RUTEMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);
            
            objUNIDAD.CODUNIDAD = Utiles.ConvertToString(dr["COD_UNIDAD"]);
            
            objUNIDAD.NOMUNIDAD = Utiles.ConvertToString(dr["NOM_UNIDAD"]);
            
        }

        #endregion

	}
}
