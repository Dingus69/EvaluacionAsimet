
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLPREGUNTAEMPLEADO.
	/// </summary>
	public class DLPREGUNTAEMPLEADO : DLBase
	{
		public DLPREGUNTAEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_PREGUNTA_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_PREGUNTA_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_PREGUNTA_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_PREGUNTA_EMPLEADO";
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
            EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO = obj as EPREGUNTAEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAEMPLEADO.CODPREGUNTAEMPLEADO;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(5);
            EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO = obj as EPREGUNTAEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAEMPLEADO.INDICADOR;
            prms[0].ParameterName = "@INDICADOR";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAEMPLEADO.TEXTO;
            prms[1].ParameterName = "@TEXTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAEMPLEADO.DESCRIPCION;
            prms[2].ParameterName = "@DESCRIPCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAEMPLEADO.ACCION;
            prms[3].ParameterName = "@ACCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAEMPLEADO.COMPROMISO;
            prms[4].ParameterName = "@COMPROMISO";
            	
            //prms[5] = db.GetParameter();
            //prms[5].Value = objPREGUNTAEMPLEADO.INDICADOR;
            //prms[5].ParameterName = "@INDICADOR";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(6);
            EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO = obj as EPREGUNTAEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objPREGUNTAEMPLEADO.CODPREGUNTAEMPLEADO;
            prms[0].ParameterName = "@COD_PREGUNTA_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objPREGUNTAEMPLEADO.TEXTO;
            prms[1].ParameterName = "@TEXTO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objPREGUNTAEMPLEADO.DESCRIPCION;
            prms[2].ParameterName = "@DESCRIPCION";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objPREGUNTAEMPLEADO.ACCION;
            prms[3].ParameterName = "@ACCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objPREGUNTAEMPLEADO.COMPROMISO;
            prms[4].ParameterName = "@COMPROMISO";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objPREGUNTAEMPLEADO.INDICADOR;
            prms[5].ParameterName = "@INDICADOR";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EPREGUNTAEMPLEADO objRoot = obj as EPREGUNTAEMPLEADO;

            objRoot.CODPREGUNTAEMPLEADO = Utiles.ConvertToDecimal(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EPREGUNTAEMPLEADO objPREGUNTAEMPLEADO = obj as EPREGUNTAEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objPREGUNTAEMPLEADO.CODPREGUNTAEMPLEADO = Utiles.ConvertToDecimal(dr["COD_PREGUNTA_EMPLEADO"]);
            
            objPREGUNTAEMPLEADO.TEXTO = Utiles.ConvertToString(dr["TEXTO"]);
            
            objPREGUNTAEMPLEADO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objPREGUNTAEMPLEADO.ACCION = Utiles.ConvertToString(dr["ACCION"]);
            
            objPREGUNTAEMPLEADO.COMPROMISO = Utiles.ConvertToString(dr["COMPROMISO"]);
            
            objPREGUNTAEMPLEADO.INDICADOR = Utiles.ConvertToString(dr["INDICADOR"]);

            objPREGUNTAEMPLEADO.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);

            objPREGUNTAEMPLEADO.RESULTADO = Utiles.ConvertToDouble(dr["RESULTADO"]);

            objPREGUNTAEMPLEADO.COMENTARIO = Utiles.ConvertToString(dr["COMENTARIO"]);

        }

        #endregion

	}
}
