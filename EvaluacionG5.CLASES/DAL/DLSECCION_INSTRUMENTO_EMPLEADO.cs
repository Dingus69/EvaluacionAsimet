
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSECCIONINSTRUMENTOEMPLEADO.
	/// </summary>
	public class DLSECCIONINSTRUMENTOEMPLEADO : DLBase
	{
		public DLSECCIONINSTRUMENTOEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SECCION_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SECCION_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SECCION_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SECCION_INSTRUMENTO_EMPLEADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_SECCION_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO = obj as ESECCIONINSTRUMENTOEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objSECCIONINSTRUMENTOEMPLEADO.CODSECCIONINSTRUMENTO;
            prms[0].ParameterName = "@COD_SECCION_INSTRUMENTO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO = obj as ESECCIONINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSECCIONINSTRUMENTOEMPLEADO.RESULTADO;
            prms[0].ParameterName = "@RESULTADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSECCIONINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[1].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSECCIONINSTRUMENTOEMPLEADO.NOMBRE;
            prms[2].ParameterName = "@NOMBRE";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objSECCIONINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objSECCIONINSTRUMENTOEMPLEADO.ORDEN;
            prms[4].ParameterName = "@ORDEN";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objSECCIONINSTRUMENTOEMPLEADO.PONDERACION;
            prms[5].ParameterName = "@PONDERACION";

            prms[6] = db.GetParameter();
            prms[6].Value = objSECCIONINSTRUMENTOEMPLEADO.FLAG_AGREGAR_PREGUNTAS;
            prms[6].ParameterName = "@FLAG_AGREGAR_PREGUNTA";

            prms[7] = db.GetParameter();
            prms[7].Value = objSECCIONINSTRUMENTOEMPLEADO.COD_TIPO_SECCION;
            prms[7].ParameterName = "@CODTIPOSECCION";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(9);
            ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO = obj as ESECCIONINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSECCIONINSTRUMENTOEMPLEADO.CODSECCIONINSTRUMENTO;
            prms[0].ParameterName = "@COD_SECCION_INSTRUMENTO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSECCIONINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[1].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSECCIONINSTRUMENTOEMPLEADO.NOMBRE;
            prms[2].ParameterName = "@NOMBRE";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objSECCIONINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objSECCIONINSTRUMENTOEMPLEADO.ORDEN;
            prms[4].ParameterName = "@ORDEN";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objSECCIONINSTRUMENTOEMPLEADO.PONDERACION;
            prms[5].ParameterName = "@PONDERACION";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objSECCIONINSTRUMENTOEMPLEADO.RESULTADO;
            prms[6].ParameterName = "@RESULTADO";

            prms[7] = db.GetParameter();
            prms[7].Value = objSECCIONINSTRUMENTOEMPLEADO.FLAG_AGREGAR_PREGUNTAS;
            prms[7].ParameterName = "@FLAG_AGREGAR_PREGUNTA";

            prms[8] = db.GetParameter();
            prms[8].Value = objSECCIONINSTRUMENTOEMPLEADO.COD_TIPO_SECCION;
            prms[8].ParameterName = "@CODTIPOSECCION";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESECCIONINSTRUMENTOEMPLEADO objRoot = obj as ESECCIONINSTRUMENTOEMPLEADO;

            objRoot.CODSECCIONINSTRUMENTO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESECCIONINSTRUMENTOEMPLEADO objSECCIONINSTRUMENTOEMPLEADO = obj as ESECCIONINSTRUMENTOEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objSECCIONINSTRUMENTOEMPLEADO.CODSECCIONINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_SECCION_INSTRUMENTO"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.ORDEN = Utiles.ConvertToInt16(dr["ORDEN"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);
            
            objSECCIONINSTRUMENTOEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);

            objSECCIONINSTRUMENTOEMPLEADO.FLAG_AGREGAR_PREGUNTAS = Utiles.ConvertToBoolean(dr["FLAG_AGREGAR_PREGUNTA"]);

            objSECCIONINSTRUMENTOEMPLEADO.COD_TIPO_SECCION = Utiles.ConvertToInt16(dr["COD_TIPO_SECCION"]);

            DLPREGUNTAEMPLEADOList objDLPR = new DLPREGUNTAEMPLEADOList();
            List<EPREGUNTAEMPLEADO> lstPREG = objDLPR.GetPreguntasSeccionEmpleado(objSECCIONINSTRUMENTOEMPLEADO.CODSECCIONINSTRUMENTO);
            if (lstPREG.Count > 0) 
            {
                objSECCIONINSTRUMENTOEMPLEADO.PREGUNTAS = lstPREG;
            }
            else
            {
                EPREGUNTAEMPLEADO objPR = new EPREGUNTAEMPLEADO();
                objSECCIONINSTRUMENTOEMPLEADO.PREGUNTAS.Add(objPR);
            }

        }

        #endregion

	}
}
