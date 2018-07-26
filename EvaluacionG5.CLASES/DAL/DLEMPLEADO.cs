
using System;
using System.Data;
using EvaluacionG5.CLASES.DAO;
using EvaluacionG5.COMMON;
using EvaluacionG5.DATAACCESS;

namespace EvaluacionG5.CLASES.DAL
{
	/// <summary>
	/// Summary description for DLEMPLEADO.
	/// </summary>
	public class DLEMPLEADO : DLBase
	{
		public DLEMPLEADO()
		{
		}

        #region Protected Methods

        protected override string GetDeleteProcedure()
        {
            return "proc_delete_EMPLEADO";
        }

        protected override string GetInsertProcedure()
        {
            return "proc_insert_EMPLEADO";
        }

        protected override string GetSelectProcedure()
        {
            return "proc_select_EMPLEADO";
        }

        protected override string GetUpdateProcedure()
        {
            return "proc_update_EMPLEADO";
        }

        protected override IDbDataParameter[] GetSelectParameters(long id, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);

            prms[0] = db.GetParameter();
            prms[0].Value = id;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetDeleteParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(1);
            EEMPLEADO objEMPLEADO = obj as EEMPLEADO;

            prms[0] = db.GetParameter();
            prms[0].Value = objEMPLEADO.RUTEMPLEADO;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            return prms;
        }

        protected override IDbDataParameter[] GetInsertParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(25);
            EEMPLEADO objEMPLEADO = obj as EEMPLEADO;

            //Poner las rutinas del Tools que se necesiten
            	
            prms[0] = db.GetParameter();
            prms[0].Value = objEMPLEADO.RUTEMPLEADO;
            prms[0].ParameterName = "@RUT_EMPLEADO";
            	
            prms[1] = db.GetParameter();
            prms[1].Value = objEMPLEADO.NOMBREEMPLEADO;
            prms[1].ParameterName = "@NOMBRE_EMPLEADO";
            	
            prms[2] = db.GetParameter();
            prms[2].Value = objEMPLEADO.APELLIDOPATERNO;
            prms[2].ParameterName = "@APELLIDO_PATERNO";
            	
            prms[3] = db.GetParameter();
            prms[3].Value = objEMPLEADO.APELLIDOMATERNO;
            prms[3].ParameterName = "@APELLIDO_MATERNO";
            	
            prms[4] = db.GetParameter();
            prms[4].Value = objEMPLEADO.EMAIL;
            prms[4].ParameterName = "@EMAIL";

            prms[5] = db.GetParameter();
            prms[5].Value = objEMPLEADO.FECHA_NACIMIENTO;
            prms[5].ParameterName = "@FECHA_NACIMIENTO";

            prms[6] = db.GetParameter();
            prms[6].Value = objEMPLEADO.COD_SEXO;
            prms[6].ParameterName = "@SEXO";

            prms[7] = db.GetParameter();
            prms[7].Value = objEMPLEADO.COD_COMUNA;
            prms[7].ParameterName = "@COD_COMUNA";

            prms[8] = db.GetParameter();
            prms[8].Value = objEMPLEADO.COD_NIVEL_EDUCACIONAL;
            prms[8].ParameterName = "@COD_NIVEL_EDUCACION";

            prms[9] = db.GetParameter();
            prms[9].Value = objEMPLEADO.COD_NIVEL_OCUPACIONAL;
            prms[9].ParameterName = "@COD_NIVEL_OCUPACIONAL";
            	
            prms[10] = db.GetParameter();
            prms[10].Value = objEMPLEADO.RUTEMPRESA;
            prms[10].ParameterName = "@RUT_EMPRESA";

            prms[11] = db.GetParameter();
            prms[11].Value = objEMPLEADO.COD_GERENCIA;
            prms[11].ParameterName = "@COD_GERENCIA";

            prms[12] = db.GetParameter();
            prms[12].Value = objEMPLEADO.COD_CENTRO_COSTO;
            prms[12].ParameterName = "@COD_CENTRO_COSTO";

            prms[13] = db.GetParameter();
            prms[13].Value = objEMPLEADO.CODSUCURSAL;
            prms[13].ParameterName = "@COD_SUCURSAL";
            	
            prms[14] = db.GetParameter();
            prms[14].Value = objEMPLEADO.CODAREA;
            prms[14].ParameterName = "@COD_AREA";

            prms[15] = db.GetParameter();
            prms[15].Value = objEMPLEADO.COD_UNIDAD;
            prms[15].ParameterName = "@COD_UNIDAD";

            prms[16] = db.GetParameter();
            prms[16].Value = objEMPLEADO.COD_DIRECCION;
            prms[16].ParameterName = "@COD_DIRECCION";

            prms[17] = db.GetParameter();
            prms[17].Value = objEMPLEADO.CODCARGO;
            prms[17].ParameterName = "@COD_CARGO";
            	
            prms[18] = db.GetParameter();
            prms[18].Value = objEMPLEADO.CODROL;
            prms[18].ParameterName = "@COD_ROL";

            prms[19] = db.GetParameter();
            prms[19].Value = objEMPLEADO.COD_CLASIFICADOR_1;
            prms[19].ParameterName = "@COD_CLASIFICADOR_1";

            prms[20] = db.GetParameter();
            prms[20].Value = objEMPLEADO.COD_CLASIFICADOR_2;
            prms[20].ParameterName = "@COD_CLASIFICADOR_2";

            prms[21] = db.GetParameter();
            prms[21].Value = objEMPLEADO.RUTJEFE;
            prms[21].ParameterName = "@RUT_JEFE";

            prms[22] = db.GetParameter();
            prms[22].Value = objEMPLEADO.RUTVISADOR;
            prms[22].ParameterName = "@RUT_VISADOR";

            prms[23] = db.GetParameter();
            prms[23].Value = objEMPLEADO.FECHAINGRESO;
            prms[23].ParameterName = "@FECHA_INGRESO";

            prms[24] = db.GetParameter();
            prms[24].Value = objEMPLEADO.COD_FAMILIA_CARGO;
            prms[24].ParameterName = "@COD_FAMILIA_CARGO";

            return prms;
        }

        protected override IDbDataParameter[] GetUpdateParameters(DomainObject obj, DB db)
        {
            IDbDataParameter[] prms = db.GetArrayParameter(25);
            EEMPLEADO objEMPLEADO = obj as EEMPLEADO;

            //Poner las rutinas del Tools que se necesiten

            prms[0] = db.GetParameter();
            prms[0].Value = objEMPLEADO.RUTEMPLEADO;
            prms[0].ParameterName = "@RUT_EMPLEADO";

            prms[1] = db.GetParameter();
            prms[1].Value = objEMPLEADO.NOMBREEMPLEADO;
            prms[1].ParameterName = "@NOMBRE_EMPLEADO";

            prms[2] = db.GetParameter();
            prms[2].Value = objEMPLEADO.APELLIDOPATERNO;
            prms[2].ParameterName = "@APELLIDO_PATERNO";

            prms[3] = db.GetParameter();
            prms[3].Value = objEMPLEADO.APELLIDOMATERNO;
            prms[3].ParameterName = "@APELLIDO_MATERNO";

            prms[4] = db.GetParameter();
            prms[4].Value = objEMPLEADO.EMAIL;
            prms[4].ParameterName = "@EMAIL";

            prms[5] = db.GetParameter();
            prms[5].Value = objEMPLEADO.FECHA_NACIMIENTO;
            prms[5].ParameterName = "@FECHA_NACIMIENTO";

            prms[6] = db.GetParameter();
            prms[6].Value = objEMPLEADO.COD_SEXO;
            prms[6].ParameterName = "@SEXO";

            prms[7] = db.GetParameter();
            prms[7].Value = objEMPLEADO.COD_COMUNA;
            prms[7].ParameterName = "@COD_COMUNA";

            prms[8] = db.GetParameter();
            prms[8].Value = objEMPLEADO.COD_NIVEL_EDUCACIONAL;
            prms[8].ParameterName = "@COD_NIVEL_EDUCACION";

            prms[9] = db.GetParameter();
            prms[9].Value = objEMPLEADO.COD_NIVEL_OCUPACIONAL;
            prms[9].ParameterName = "@COD_NIVEL_OCUPACIONAL";

            prms[10] = db.GetParameter();
            prms[10].Value = objEMPLEADO.RUTEMPRESA;
            prms[10].ParameterName = "@RUT_EMPRESA";

            prms[11] = db.GetParameter();
            prms[11].Value = objEMPLEADO.COD_GERENCIA;
            prms[11].ParameterName = "@COD_GERENCIA";

            prms[12] = db.GetParameter();
            prms[12].Value = objEMPLEADO.COD_CENTRO_COSTO;
            prms[12].ParameterName = "@COD_CENTRO_COSTO";

            prms[13] = db.GetParameter();
            prms[13].Value = objEMPLEADO.CODSUCURSAL;
            prms[13].ParameterName = "@COD_SUCURSAL";

            prms[14] = db.GetParameter();
            prms[14].Value = objEMPLEADO.CODAREA;
            prms[14].ParameterName = "@COD_AREA";

            prms[15] = db.GetParameter();
            prms[15].Value = objEMPLEADO.COD_UNIDAD;
            prms[15].ParameterName = "@COD_UNIDAD";

            prms[16] = db.GetParameter();
            prms[16].Value = objEMPLEADO.COD_DIRECCION;
            prms[16].ParameterName = "@COD_DIRECCION";

            prms[17] = db.GetParameter();
            prms[17].Value = objEMPLEADO.CODCARGO;
            prms[17].ParameterName = "@COD_CARGO";

            prms[18] = db.GetParameter();
            prms[18].Value = objEMPLEADO.CODROL;
            prms[18].ParameterName = "@COD_ROL";

            prms[19] = db.GetParameter();
            prms[19].Value = objEMPLEADO.COD_CLASIFICADOR_1;
            prms[19].ParameterName = "@COD_CLASIFICADOR_1";

            prms[20] = db.GetParameter();
            prms[20].Value = objEMPLEADO.COD_CLASIFICADOR_2;
            prms[20].ParameterName = "@COD_CLASIFICADOR_2";

            prms[21] = db.GetParameter();
            prms[21].Value = objEMPLEADO.RUTJEFE;
            prms[21].ParameterName = "@RUT_JEFE";

            prms[22] = db.GetParameter();
            prms[22].Value = objEMPLEADO.RUTVISADOR;
            prms[22].ParameterName = "@RUT_VISADOR";

            prms[23] = db.GetParameter();
            prms[23].Value = objEMPLEADO.FECHAINGRESO;
            prms[23].ParameterName = "@FECHA_INGRESO";

            prms[24] = db.GetParameter();
            prms[24].Value = objEMPLEADO.COD_FAMILIA_CARGO;
            prms[24].ParameterName = "@COD_FAMILIA_CARGO";

            return prms;
        }

        protected override void SetPrimaryKey(DomainObject obj, long id)
        {
            EEMPLEADO objRoot = obj as EEMPLEADO;

            objRoot.RUTEMPLEADO = Utiles.ConvertToInt64(id);
        }

        #endregion

        #region Public Methods

         public override void Fill(DomainObject obj, IDataReader dr)
        {
            EEMPLEADO objEMPLEADO = obj as EEMPLEADO;
    
            //Poner las rutinas del Tools que se necesiten
            
            objEMPLEADO.RUTEMPLEADO = Utiles.ConvertToInt64(dr["RUT_EMPLEADO"]);
            
            objEMPLEADO.NOMBREEMPLEADO = Utiles.ConvertToString(dr["NOMBRE_EMPLEADO"]);
            
            objEMPLEADO.APELLIDOPATERNO = Utiles.ConvertToString(dr["APELLIDO_PATERNO"]);
            
            objEMPLEADO.APELLIDOMATERNO = Utiles.ConvertToString(dr["APELLIDO_MATERNO"]);
            
            objEMPLEADO.EMAIL = Utiles.ConvertToString(dr["EMAIL"]);

            objEMPLEADO.FECHA_NACIMIENTO = Utiles.ConvertToDateTime(dr["FECHA_NACIMIENTO"]);

            objEMPLEADO.COD_SEXO = Utiles.ConvertToString(dr["COD_SEXO"]);

            objEMPLEADO.COD_COMUNA = Utiles.ConvertToString(dr["COD_COMUNA"]);

            objEMPLEADO.NOM_COMUNA = Utiles.ConvertToString(dr["NOM_COMUNA"]);

            objEMPLEADO.COD_NIVEL_EDUCACIONAL = Utiles.ConvertToInt16(dr["COD_NIVEL_EDUCACIONAL"]);

            objEMPLEADO.NIVEL_EDUCACIONAL = Utiles.ConvertToString(dr["NOM_NIVEL_EDUCACIONAL"]);

            objEMPLEADO.COD_NIVEL_OCUPACIONAL = Utiles.ConvertToInt16(dr["COD_NIVEL_OCUPACIONAL"]);

            objEMPLEADO.NIVEL_OCUPACIONAL = Utiles.ConvertToString(dr["NOM_NIVEL_OCUPACIONAL"]);

            objEMPLEADO.FECHAINGRESO = Utiles.ConvertToDateTime(dr["FECHA_INGRESO"]);
            
            objEMPLEADO.RUTEMPRESA = Utiles.ConvertToInt64(dr["RUT_EMPRESA"]);

            objEMPLEADO.NOMBRE_FANTASIA = Utiles.ConvertToString(dr["NOMBRE_FANTASIA"]);

            objEMPLEADO.COD_GERENCIA = Utiles.ConvertToString(dr["COD_GERENCIA"]);

            objEMPLEADO.NOMBRE_GERENCIA = Utiles.ConvertToString(dr["NOMBRE_GERENCIA"]);

            objEMPLEADO.CODSUCURSAL = Utiles.ConvertToString(dr["COD_SUCURSAL"]);

            objEMPLEADO.NOMBRE_SUCURSAL = Utiles.ConvertToString(dr["NOMBRE_SUCURSAL"]);

            objEMPLEADO.CODAREA = Utiles.ConvertToString(dr["COD_AREA"]);

            objEMPLEADO.NOMBRE_AREA = Utiles.ConvertToString(dr["NOMBRE_AREA"]);

            objEMPLEADO.COD_UNIDAD = Utiles.ConvertToString(dr["COD_UNIDAD"]);

            objEMPLEADO.NOMBRE_UNIDAD = Utiles.ConvertToString(dr["NOMBRE_UNIDAD"]);

            objEMPLEADO.COD_DIRECCION = Utiles.ConvertToString(dr["COD_DIRECCION"]);

            objEMPLEADO.NOMBRE_DIRECCION = Utiles.ConvertToString(dr["NOMBRE_DIRECCION"]);

            objEMPLEADO.COD_FAMILIA_CARGO = Utiles.ConvertToString(dr["COD_FAMILIA_CARGO"]);

            objEMPLEADO.NOMBRE_FAMILIA_CARGO = Utiles.ConvertToString(dr["NOM_FAMILIA_CARGO"]);

            objEMPLEADO.CODCARGO = Utiles.ConvertToString(dr["COD_CARGO"]);

            objEMPLEADO.NOMBRE_CARGO = Utiles.ConvertToString(dr["NOMBRE_CARGO"]);

            objEMPLEADO.CODROL = Utiles.ConvertToString(dr["COD_ROL"]);

            objEMPLEADO.NOMBRE_ROL = Utiles.ConvertToString(dr["NOMBRE_ROL"]);

            objEMPLEADO.RUTJEFE = Utiles.ConvertToInt64(dr["RUT_JEFE"]);

            objEMPLEADO.JEFE = Utiles.ConvertToString(dr["JEFE"]);

            objEMPLEADO.RUTVISADOR = Utiles.ConvertToInt64(dr["RUT_VISADOR"]);

            objEMPLEADO.VISADOR = Utiles.ConvertToString(dr["VISADOR"]);

            objEMPLEADO.FLAG_ACTIVO = Utiles.ConvertToBoolean(dr["FLAG_ACTIVO"]);

        }

        #endregion

	}
}
