
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLEMPRESA.
	/// </summary>
	public class DLEMPRESA : DLBase
	{
		public DLEMPRESA()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_EMPRESA";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_EMPRESA";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_EMPRESA";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_EMPRESA";
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
            EEMPRESA objEMPRESA = obj as EEMPRESA;

            prms[0] = db.GetParameter();
            prms[0].Value = objEMPRESA.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EEMPRESA objEMPRESA = obj as EEMPRESA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objEMPRESA.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objEMPRESA.NOMBREFANTASIA;
            prms[1].ParameterName = "@NOMBRE_FANTASIA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objEMPRESA.RAZONSOCIAL;
            prms[2].ParameterName = "@RAZON_SOCIAL";

            prms[3] = db.GetParameter();
            prms[3].Value = objEMPRESA.NOMBRE_CONTACTO;
            prms[3].ParameterName = "@NOMBRE_CONTACTO";

            prms[4] = db.GetParameter();
            prms[4].Value = objEMPRESA.CARGO_CONTACTO;
            prms[4].ParameterName = "@CARGO_CONTACTO";

            prms[5] = db.GetParameter();
            prms[5].Value = objEMPRESA.FONO_CONTACTO;
            prms[5].ParameterName = "@FONO_CONTACTO";

            prms[6] = db.GetParameter();
            prms[6].Value = objEMPRESA.EMAIL_CONTACTO;
            prms[6].ParameterName = "@EMAIL_CONTACTO";

            prms[7] = db.GetParameter();
            prms[7].Value = objEMPRESA.GIRO;
            prms[7].ParameterName = "@GIRO";

            prms[8] = db.GetParameter();
            prms[8].Value = objEMPRESA.FLAG_ACTIVO;
            prms[8].ParameterName = "@FLAG_ACTIVO";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            EEMPRESA objEMPRESA = obj as EEMPRESA;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objEMPRESA.RUTEMPRESA;
            prms[0].ParameterName = "@RUT_EMPRESA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objEMPRESA.NOMBREFANTASIA;
            prms[1].ParameterName = "@NOMBRE_FANTASIA";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objEMPRESA.RAZONSOCIAL;
            prms[2].ParameterName = "@RAZON_SOCIAL";

            prms[3] = db.GetParameter();
            prms[3].Value = objEMPRESA.NOMBRE_CONTACTO;
            prms[3].ParameterName = "@NOMBRE_CONTACTO";

            prms[4] = db.GetParameter();
            prms[4].Value = objEMPRESA.CARGO_CONTACTO;
            prms[4].ParameterName = "@CARGO_CONTACTO";

            prms[5] = db.GetParameter();
            prms[5].Value = objEMPRESA.FONO_CONTACTO;
            prms[5].ParameterName = "@FONO_CONTACTO";

            prms[6] = db.GetParameter();
            prms[6].Value = objEMPRESA.EMAIL_CONTACTO;
            prms[6].ParameterName = "@EMAIL_CONTACTO";

            prms[7] = db.GetParameter();
            prms[7].Value = objEMPRESA.GIRO;
            prms[7].ParameterName = "@GIRO";

            prms[8] = db.GetParameter();
            prms[8].Value = objEMPRESA.FLAG_ACTIVO;
            prms[8].ParameterName = "@FLAG_ACTIVO";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EEMPRESA objRoot = obj as EEMPRESA;

            objRoot.RUTEMPRESA = Utiles.ConvertToInt64(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EEMPRESA objEMPRESA = obj as EEMPRESA;
    
            //Poner las rutinas del Tools que se necesiten
            
            objEMPRESA.RUTEMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);
            
            objEMPRESA.NOMBREFANTASIA = Utiles.ConvertToString(dr["NOMBRE_FANTASIA"]);
            
            objEMPRESA.RAZONSOCIAL = Utiles.ConvertToString(dr["RAZON_SOCIAL"]);

            objEMPRESA.NOMBRE_CONTACTO = Utiles.ConvertToString(dr["NOMBRE_CONTACTO"]);

            objEMPRESA.CARGO_CONTACTO = Utiles.ConvertToString(dr["CARGO_CONTACTO"]);

            objEMPRESA.FONO_CONTACTO = Utiles.ConvertToString(dr["FONO_CONTACTO"]);

            objEMPRESA.EMAIL_CONTACTO = Utiles.ConvertToString(dr["EMAIL_CONTACTO"]);

            objEMPRESA.GIRO = Utiles.ConvertToString(dr["GIRO"]);

            objEMPRESA.FLAG_ACTIVO = Utiles.ConvertToBoolean(dr["FLAG_ACTIVO"]);

        }

        #endregion

	}
}
