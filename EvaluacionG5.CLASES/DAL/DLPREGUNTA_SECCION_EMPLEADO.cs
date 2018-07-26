
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTASECCIONEMPLEADO.
	/// </summary>
	public class DLPREGUNTASECCIONEMPLEADO : DLBase
	{
		public DLPREGUNTASECCIONEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA_SECCION_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA_SECCION_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA_SECCION_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA_SECCION_EMPLEADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO = obj as EPREGUNTASECCIONEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCIONEMPLEADO.CODPREGUNTAEMPLEADO;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO = obj as EPREGUNTASECCIONEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCIONEMPLEADO.CODPREGUNTAEMPLEADO;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTASECCIONEMPLEADO.CODSECCIONINSTRUMENTO;
            prms[1].ParameterName = "@COD_SECCION_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTASECCIONEMPLEADO.PONDERACION;
            prms[2].ParameterName = "@PONDERACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTASECCIONEMPLEADO.RESULTADO;
            prms[3].ParameterName = "@RESULTADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTASECCIONEMPLEADO.COMENTARIO;
            prms[4].ParameterName = "@COMENTARIO";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO = obj as EPREGUNTASECCIONEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTASECCIONEMPLEADO.CODPREGUNTAEMPLEADO;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTASECCIONEMPLEADO.CODSECCIONINSTRUMENTO;
            prms[1].ParameterName = "@COD_SECCION_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTASECCIONEMPLEADO.PONDERACION;
            prms[2].ParameterName = "@PONDERACION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTASECCIONEMPLEADO.RESULTADO;
            prms[3].ParameterName = "@RESULTADO";

            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTASECCIONEMPLEADO.COMENTARIO;
            prms[4].ParameterName = "@COMENTARIO";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTASECCIONEMPLEADO objRoot = obj as EPREGUNTASECCIONEMPLEADO;

            objRoot.CODPREGUNTAEMPLEADO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTASECCIONEMPLEADO objPREGUNTASECCIONEMPLEADO = obj as EPREGUNTASECCIONEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTASECCIONEMPLEADO.CODPREGUNTAEMPLEADO = Utiles.ConvertToDecimal(dr["COD_PREGUNTA_EMPLEADO"]);
            
            objPREGUNTASECCIONEMPLEADO.CODSECCIONINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_SECCION_INSTRUMENTO"]);
            
            objPREGUNTASECCIONEMPLEADO.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);
            
            objPREGUNTASECCIONEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);

            objPREGUNTASECCIONEMPLEADO.COMENTARIO = Utiles.ConvertToString(dr["COMENTARIO"]);

        }

        #endregion

	}
}
