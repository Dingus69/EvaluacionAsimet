
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLOBJETIVOINSTRUMENTOEMPLEADO.
	/// </summary>
	public class DLOBJETIVOINSTRUMENTOEMPLEADO : DLBase
	{
		public DLOBJETIVOINSTRUMENTOEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_OBJETIVO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_OBJETIVO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_OBJETIVO_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_OBJETIVO_INSTRUMENTO_EMPLEADO";
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
            EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO = obj as EOBJETIVOINSTRUMENTOEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO = obj as EOBJETIVOINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETIVOINSTRUMENTOEMPLEADO.CODOBJETIVO;
            prms[1].ParameterName = "@COD_OBJETIVO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objOBJETIVOINSTRUMENTOEMPLEADO.RESULTADO;
            prms[2].ParameterName = "@RESULTADO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objOBJETIVOINSTRUMENTOEMPLEADO.COMENTARIO;
            prms[3].ParameterName = "@COMENTARIO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(4);
            EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO = obj as EOBJETIVOINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETIVOINSTRUMENTOEMPLEADO.CODOBJETIVO;
            prms[1].ParameterName = "@COD_OBJETIVO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objOBJETIVOINSTRUMENTOEMPLEADO.RESULTADO;
            prms[2].ParameterName = "@RESULTADO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objOBJETIVOINSTRUMENTOEMPLEADO.COMENTARIO;
            prms[3].ParameterName = "@COMENTARIO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EOBJETIVOINSTRUMENTOEMPLEADO objRoot = obj as EOBJETIVOINSTRUMENTOEMPLEADO;

            objRoot.CODINSTRUMENTOEMPLEADO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EOBJETIVOINSTRUMENTOEMPLEADO objOBJETIVOINSTRUMENTOEMPLEADO = obj as EOBJETIVOINSTRUMENTOEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objOBJETIVOINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objOBJETIVOINSTRUMENTOEMPLEADO.CODOBJETIVO = Utiles.ConvertToDecimal(dr["COD_OBJETIVO"]);
            
            objOBJETIVOINSTRUMENTOEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);
            
            objOBJETIVOINSTRUMENTOEMPLEADO.COMENTARIO = Utiles.ConvertToString(dr["COMENTARIO"]);
            
        }

        #endregion

	}
}
