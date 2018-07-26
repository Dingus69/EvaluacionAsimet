
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLCURSOINSTRUMENTOEMPLEADO.
	/// </summary>
	public class DLCURSOINSTRUMENTOEMPLEADO : DLBase
	{
		public DLCURSOINSTRUMENTOEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_CURSO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_CURSO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_CURSO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_CURSO_INSTRUMENTO_EMPLEADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO = obj as ECURSOINSTRUMENTOEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO = obj as ECURSOINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOINSTRUMENTOEMPLEADO.CODCURSO;
            prms[1].ParameterName = "@COD_CURSO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(2);
            ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO = obj as ECURSOINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objCURSOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objCURSOINSTRUMENTOEMPLEADO.CODCURSO;
            prms[1].ParameterName = "@COD_CURSO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ECURSOINSTRUMENTOEMPLEADO objRoot = obj as ECURSOINSTRUMENTOEMPLEADO;

            objRoot.CODINSTRUMENTOEMPLEADO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ECURSOINSTRUMENTOEMPLEADO objCURSOINSTRUMENTOEMPLEADO = obj as ECURSOINSTRUMENTOEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objCURSOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objCURSOINSTRUMENTOEMPLEADO.CODCURSO = Utiles.ConvertToString(dr["COD_CURSO"]);
            
        }

        #endregion

	}
}
