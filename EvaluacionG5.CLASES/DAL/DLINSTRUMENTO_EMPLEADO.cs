
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLINSTRUMENTOEMPLEADO.
	/// </summary>
	public class DLINSTRUMENTOEMPLEADO : DLBase
	{
		public DLINSTRUMENTOEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_INSTRUMENTO_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_INSTRUMENTO_EMPLEADO";
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
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(14);
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.FLAGVISADO;
            prms[0].ParameterName = "@FLAG_VISADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO;
            prms[2].ParameterName = "@NOM_INSTRUMENTO_EMPLEADO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTOEMPLEADO.RUTEMPLEADO;
            prms[3].ParameterName = "@RUT_EMPLEADO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTOEMPLEADO.RUTEVALUADOR;
            prms[4].ParameterName = "@RUT_EVALUADOR";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTOEMPLEADO.RUTVISADOR;
            prms[5].ParameterName = "@RUT_VISADOR";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTOEMPLEADO.CODTIPOEVAL;
            prms[6].ParameterName = "@COD_TIPO_EVAL";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTOEMPLEADO.CODESTADOEVAL;
            prms[7].ParameterName = "@CODESTADOEVAL";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTOEMPLEADO.INICIOEVALUACION;
            prms[8].ParameterName = "@INICIO_EVALUACION";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTOEMPLEADO.FINEVALUACION;
            prms[9].ParameterName = "@FIN_EVALUACION";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTOEMPLEADO.FECHAEVALUACION;
            prms[10].ParameterName = "@FECHA_EVALUACION";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTOEMPLEADO.RESULTADO;
            prms[11].ParameterName = "@RESULTADO";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[12].ParameterName = "@DESCRIPCION";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTOEMPLEADO.OBSERVACION;
            prms[13].ParameterName = "@OBSERVACION";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(15);
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO;
            prms[0].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objINSTRUMENTOEMPLEADO.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO;
            prms[2].ParameterName = "@NOM_INSTRUMENTO_EMPLEADO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objINSTRUMENTOEMPLEADO.RUTEMPLEADO;
            prms[3].ParameterName = "@RUT_EMPLEADO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objINSTRUMENTOEMPLEADO.RUTEVALUADOR;
            prms[4].ParameterName = "@RUT_EVALUADOR";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objINSTRUMENTOEMPLEADO.RUTVISADOR;
            prms[5].ParameterName = "@RUT_VISADOR";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objINSTRUMENTOEMPLEADO.CODTIPOEVAL;
            prms[6].ParameterName = "@COD_TIPO_EVAL";
            	
            prms[7] = db.GetParameter();
            prms[7].Value = objINSTRUMENTOEMPLEADO.CODESTADOEVAL;
            prms[7].ParameterName = "@CODESTADOEVAL";
            	
            prms[8] = db.GetParameter();
            prms[8].Value = objINSTRUMENTOEMPLEADO.INICIOEVALUACION;
            prms[8].ParameterName = "@INICIO_EVALUACION";
            	
            prms[9] = db.GetParameter();
            prms[9].Value = objINSTRUMENTOEMPLEADO.FINEVALUACION;
            prms[9].ParameterName = "@FIN_EVALUACION";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objINSTRUMENTOEMPLEADO.FECHAEVALUACION;
            prms[10].ParameterName = "@FECHA_EVALUACION";
            	
            prms[11] = db.GetParameter();
            prms[11].Value = objINSTRUMENTOEMPLEADO.RESULTADO;
            prms[11].ParameterName = "@RESULTADO";
            	
            prms[12] = db.GetParameter();
            prms[12].Value = objINSTRUMENTOEMPLEADO.FLAGVISADO;
            prms[12].ParameterName = "@FLAG_VISADO";

            prms[13] = db.GetParameter();
            prms[13].Value = objINSTRUMENTOEMPLEADO.DESCRIPCION;
            prms[13].ParameterName = "@DESCRIPCION";

            prms[14] = db.GetParameter();
            prms[14].Value = objINSTRUMENTOEMPLEADO.OBSERVACION;
            prms[14].ParameterName = "@OBSERVACION";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EINSTRUMENTOEMPLEADO objRoot = obj as EINSTRUMENTOEMPLEADO;

            objRoot.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EINSTRUMENTOEMPLEADO objINSTRUMENTOEMPLEADO = obj as EINSTRUMENTOEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objINSTRUMENTOEMPLEADO.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
            objINSTRUMENTOEMPLEADO.NOMINSTRUMENTOEMPLEADO = Utiles.ConvertToString(dr["NOM_INSTRUMENTO_EMPLEADO"]);

            objINSTRUMENTOEMPLEADO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);

            objINSTRUMENTOEMPLEADO.OBSERVACION = Utiles.ConvertToString(dr["OBSERVACION"]);

            objINSTRUMENTOEMPLEADO.RUTEMPLEADO = Utiles.ConvertToInt64(dr["RUT_EMPLEADO"]);

            objINSTRUMENTOEMPLEADO.RUTEVALUADOR = Utiles.ConvertToInt64(dr["RUT_EVALUADOR"]);
            
            objINSTRUMENTOEMPLEADO.RUTVISADOR = Utiles.ConvertToInt64(dr["RUT_VISADOR"]);
            
            objINSTRUMENTOEMPLEADO.CODTIPOEVAL = Utiles.ConvertToInt16(dr["COD_TIPO_EVAL"]);
            
            objINSTRUMENTOEMPLEADO.CODESTADOEVAL = Utiles.ConvertToDecimal(dr["CODESTADOEVAL"]);
            
            objINSTRUMENTOEMPLEADO.INICIOEVALUACION = Utiles.ConvertToDateTime(dr["INICIO_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.FINEVALUACION = Utiles.ConvertToDateTime(dr["FIN_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.FECHAEVALUACION = Utiles.ConvertToDateTime(dr["FECHA_EVALUACION"]);
            
            objINSTRUMENTOEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);
            
            objINSTRUMENTOEMPLEADO.FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(dr["FLAG_AGREGAR_PREGUNTA"]);

            objINSTRUMENTOEMPLEADO.FLAG_VISACION = Utiles.ConvertToBoolean(dr["FLAG_VISACION"]);

            objINSTRUMENTOEMPLEADO.FLAG_APELACION = Utiles.ConvertToBoolean(dr["FLAG_APELACION"]);

            objINSTRUMENTOEMPLEADO.FLAG_AUTOEVALUACION = Utiles.ConvertToBoolean(dr["FLAG_AUTOEVALUACION"]);

            objINSTRUMENTOEMPLEADO.FLAGVISADO = Utiles.ConvertToBoolean(dr["FLAG_VISADO"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_EVALUADO = Utiles.ConvertToString(dr["EVALUADO"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_EVALUADOR = Utiles.ConvertToString(dr["EVALUADOR"]);

            objINSTRUMENTOEMPLEADO.NOMBRE_VISADOR = Utiles.ConvertToString(dr["VISADOR"]);

            objINSTRUMENTOEMPLEADO.COD_TIPO_INTRUMENTO = Utiles.ConvertToInt16(dr["COD_TIPO_INSTRUMENTO"]);

            objINSTRUMENTOEMPLEADO.PLAN_DESARROLLO = Utiles.ConvertToString(dr["PLAN_DESARROLLO"]);

            objINSTRUMENTOEMPLEADO.FLAG_ACUERDO = Utiles.ConvertToBoolean(dr["FLAG_ACUERDO"]);

            objINSTRUMENTOEMPLEADO.COMENTARIO_FEEDBACK = Utiles.ConvertToString(dr["COMENTARIO_FEEDBACK"]);

            DLSECCIONINSTRUMENTOEMPLEADOList objDLSE = new DLSECCIONINSTRUMENTOEMPLEADOList();
            List<ESECCIONINSTRUMENTOEMPLEADO> lstSE = objDLSE.GetSeccionesInstrumentoEmpleado(objINSTRUMENTOEMPLEADO.CODINSTRUMENTOEMPLEADO);
            if (lstSE.Count > 0)
            {
                objINSTRUMENTOEMPLEADO.SECCIONES = lstSE;
            }
            else
            {
                ESECCIONINSTRUMENTOEMPLEADO objSE = new ESECCIONINSTRUMENTOEMPLEADO();
                objINSTRUMENTOEMPLEADO.SECCIONES.Add(objSE);
            }

            //DLEMPLEADO objDLEM = new DLEMPLEADO();
            //EEMPLEADO objEM;

            //objEM = new EEMPLEADO();
            //objEM = objDLEM.Select(objINSTRUMENTOEMPLEADO.RUTEMPLEADO);

        }

        #endregion

	}
}
