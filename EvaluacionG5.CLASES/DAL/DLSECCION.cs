
using System;
using System.Data;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLSECCION.
	/// </summary>
	public class DLSECCION : DLBase
	{
		public DLSECCION()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_SECCION";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_SECCION";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_SECCION";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_SECCION";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_SECCION";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            ESECCION objSECCION = obj as ESECCION;

            prms[0] = db.GetParameter();
            prms[0].Value = objSECCION.CODSECCION;
            prms[0].ParameterName = "@COD_SECCION";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            ESECCION objSECCION = obj as ESECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSECCION.FLAG_AGREGAR_PREGUNTA;
            prms[0].ParameterName = "@FLAG_AGREGAR_PREGUNTA";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSECCION.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSECCION.CODTIPOSECCION;
            prms[2].ParameterName = "@COD_TIPO_SECCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objSECCION.NOMBRE;
            prms[3].ParameterName = "@NOMBRE";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objSECCION.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objSECCION.ORDEN;
            prms[5].ParameterName = "@ORDEN";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objSECCION.PONDERACION;
            prms[6].ParameterName = "@PONDERACION";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(8);
            ESECCION objSECCION = obj as ESECCION;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objSECCION.CODSECCION;
            prms[0].ParameterName = "@COD_SECCION";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objSECCION.CODINSTRUMENTO;
            prms[1].ParameterName = "@COD_INSTRUMENTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objSECCION.CODTIPOSECCION;
            prms[2].ParameterName = "@COD_TIPO_SECCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objSECCION.NOMBRE;
            prms[3].ParameterName = "@NOMBRE";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objSECCION.DESCRIPCION;
            prms[4].ParameterName = "@DESCRIPCION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objSECCION.ORDEN;
            prms[5].ParameterName = "@ORDEN";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objSECCION.PONDERACION;
            prms[6].ParameterName = "@PONDERACION";

            prms[7] = db.GetParameter();
            prms[7].Value = objSECCION.FLAG_AGREGAR_PREGUNTA;
            prms[7].ParameterName = "@FLAG_AGREGAR_PREGUNTA";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            ESECCION objRoot = obj as ESECCION;

            objRoot.CODSECCION = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            ESECCION objSECCION = obj as ESECCION;
    
            //Poner las rutinas del Tools que se necesiten
            
            objSECCION.CODSECCION = Utiles.ConvertToDecimal(dr["COD_SECCION"]);
            
            objSECCION.CODINSTRUMENTO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO"]);
            
            objSECCION.CODTIPOSECCION = Utiles.ConvertToInt16(dr["COD_TIPO_SECCION"]);
            
            objSECCION.NOMBRE = Utiles.ConvertToString(dr["NOMBRE"]);
            
            objSECCION.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objSECCION.ORDEN = Utiles.ConvertToInt16(dr["ORDEN"]);

            objSECCION.FLAG_AGREGAR_PREGUNTA = Utiles.ConvertToBoolean(dr["FLAG_AGREGAR_PREGUNTA"]);

            objSECCION.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);

            DLPREGUNTAList objDLPR = new DLPREGUNTAList();
            List<EPREGUNTA> lstPREG = objDLPR.GetPreguntasSeccion(objSECCION.CODSECCION);
            if (lstPREG.Count > 0)
            { 
                objSECCION.PREGUNTAS = lstPREG;
            }
            else
            {
                EPREGUNTA objPR = new EPREGUNTA();
                objSECCION.PREGUNTAS.Add(objPR);
            }

        }

        #endregion

	}
}
