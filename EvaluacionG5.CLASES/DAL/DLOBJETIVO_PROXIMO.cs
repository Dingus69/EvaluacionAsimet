
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLOBJETIVOPROXIMO.
	/// </summary>
	public class DLOBJETIVOPROXIMO : DLBase
	{
		public DLOBJETIVOPROXIMO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_OBJETIVO_PROXIMO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_OBJETIVO_PROXIMO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_OBJETIVO_PROXIMO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_OBJETIVO_PROXIMO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@COD_OBJETIVO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EOBJETIVOPROXIMO objOBJETIVOPROXIMO = obj as EOBJETIVOPROXIMO;

            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOPROXIMO.CODOBJETIVO;
            prms[0].ParameterName = "@COD_OBJETIVO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EOBJETIVOPROXIMO objOBJETIVOPROXIMO = obj as EOBJETIVOPROXIMO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOPROXIMO.CODOBJETIVO;
            prms[0].ParameterName = "@COD_OBJETIVO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETIVOPROXIMO.CODINSTRUMENTOEMPLEADO;
            prms[1].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objOBJETIVOPROXIMO.NOMOBJETIVO;
            prms[2].ParameterName = "@NOM_OBJETIVO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objOBJETIVOPROXIMO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objOBJETIVOPROXIMO.PONDERACION;
            prms[4].ParameterName = "@PONDERACION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objOBJETIVOPROXIMO.FLAGASIGNADO;
            prms[5].ParameterName = "@FLAG_ASIGNADO";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objOBJETIVOPROXIMO.FLAGEVALUADO;
            prms[6].ParameterName = "@FLAG_EVALUADO";
            
            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(7);
            EOBJETIVOPROXIMO objOBJETIVOPROXIMO = obj as EOBJETIVOPROXIMO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objOBJETIVOPROXIMO.CODOBJETIVO;
            prms[0].ParameterName = "@COD_OBJETIVO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objOBJETIVOPROXIMO.CODINSTRUMENTOEMPLEADO;
            prms[1].ParameterName = "@COD_INSTRUMENTO_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objOBJETIVOPROXIMO.NOMOBJETIVO;
            prms[2].ParameterName = "@NOM_OBJETIVO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objOBJETIVOPROXIMO.DESCRIPCION;
            prms[3].ParameterName = "@DESCRIPCION";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objOBJETIVOPROXIMO.PONDERACION;
            prms[4].ParameterName = "@PONDERACION";
            	
            prms[5] = db.GetParameter();
            prms[5].Value = objOBJETIVOPROXIMO.FLAGASIGNADO;
            prms[5].ParameterName = "@FLAG_ASIGNADO";
            	
            prms[6] = db.GetParameter();
            prms[6].Value = objOBJETIVOPROXIMO.FLAGEVALUADO;
            prms[6].ParameterName = "@FLAG_EVALUADO";
            
            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EOBJETIVOPROXIMO objRoot = obj as EOBJETIVOPROXIMO;

            objRoot.CODOBJETIVO = id;
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EOBJETIVOPROXIMO objOBJETIVOPROXIMO = obj as EOBJETIVOPROXIMO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objOBJETIVOPROXIMO.CODOBJETIVO = Utiles.ConvertToDecimal(dr["COD_OBJETIVO"]);
            
            objOBJETIVOPROXIMO.CODINSTRUMENTOEMPLEADO = Utiles.ConvertToDecimal(dr["COD_INSTRUMENTO_EMPLEADO"]);
            
            objOBJETIVOPROXIMO.NOMOBJETIVO = Utiles.ConvertToString(dr["NOM_OBJETIVO"]);
            
            objOBJETIVOPROXIMO.DESCRIPCION = Utiles.ConvertToString(dr["DESCRIPCION"]);
            
            objOBJETIVOPROXIMO.PONDERACION = Utiles.ConvertToDouble(dr["PONDERACION"]);
            
            objOBJETIVOPROXIMO.FLAGASIGNADO = Utiles.ConvertToBoolean(dr["FLAG_ASIGNADO"]);
            
            objOBJETIVOPROXIMO.FLAGEVALUADO = Utiles.ConvertToBoolean(dr["FLAG_EVALUADO"]);

            objOBJETIVOPROXIMO.RESULTADO = Utiles.ConvertToDecimal(dr["RESULTADO"]);

            objOBJETIVOPROXIMO.COMENTARIO = Utiles.ConvertToString(dr["COMENTARIO"]);

        }

        #endregion

	}
}
