
using System;
using System.Collections.Generic;
using System.Data;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
	/// <summary>
	/// BFEMPLEADO.
	/// </summary>
	public class BFEMPLEADO
	{
		private DLEMPLEADO _objDAL;
		private DLEMPLEADOList _objDALList;

        private DataTable _dtErroresCarga;

        public DataTable DtErroresCarga
        {
            get
            {
                return _dtErroresCarga;
            }

            set
            {
                _dtErroresCarga = value;
            }
        }

        public BFEMPLEADO()
		{
			_objDAL = new DLEMPLEADO();
			_objDALList = new DLEMPLEADOList();
            IniciaDtErrores();
        }

        private void IniciaDtErrores()
        {
            _dtErroresCarga = new DataTable();
            _dtErroresCarga.Columns.Add("Rut");
            _dtErroresCarga.Columns.Add("Error");
        }

		public EEMPLEADO GetEMPLEADO()
		{
			return new EEMPLEADO();
		}

		public EEMPLEADO GetEMPLEADO(long id)
		{
            return new EEMPLEADO(id);
		}

		public bool Save(EEMPLEADO objEMPLEADO)
		{
			try
			{
				objEMPLEADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EEMPLEADO> GetEMPLEADOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EEMPLEADO> GetEMPLEADO(Int64 Rut, string Nombre)
        {
            return _objDALList.GetEmpleados(Rut, Nombre);
        }

        public DataTable GetEMPLEADOSCARGADOS(string ListaRut)
        {
            return _objDALList.SelectCargados(ListaRut);
        }

        public List<EEMPLEADO> GetEMPLEADOSBYCARGONOMBRE(string CodCargo, string Nombre)
        {
            return _objDALList.GetEmpleadosByCargoAndNombre(CodCargo, Nombre);
        }

        public List<EEMPLEADO> GetEMPLEADOSBYRUTJEFE(Int64 RutJefe)
        {
            return _objDALList.GetEmpleadosByRutJefe(RutJefe);
        }

        public List<EEMPLEADO> GetEmpleadosPorFiltros(string Nombre, Int64 RutEmpresa, string CodGerencia,
                                string CodCentroCosto, string CodSucursal, string CodArea, string CodCargo,
                                string CodRol, string CodClasificador1, string CodClasificador2)
        {
            return _objDALList.GetEmpleadosPorFiltros(Nombre, RutEmpresa, CodGerencia,
                                CodCentroCosto, CodSucursal, CodArea, CodCargo, CodRol, CodClasificador1,
                                CodClasificador2);
        }

        public DataTable GetEvaluadoresPorEvaluacion(string NombreInstrumento)
        {
            return _objDALList.GetEvaluadoresPorEvaluacion(NombreInstrumento);
        }

        public DataTable GetVisadoresPorEvaluacion(string NombreInstrumento)
        {
            return _objDALList.GetVisadoresPorEvaluacion(NombreInstrumento);
        }

        public bool Delete(EEMPLEADO objEMPLEADO)
		{
			try
			{
                _objDAL.Delete(objEMPLEADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EEMPLEADO objEMPLEADO)
        {
            try
            {
                _objDAL.Update(objEMPLEADO);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        private void AgregaError(string Rut, string Error)
        {
            DataRow drError;
            drError = DtErroresCarga.NewRow();
            drError["Rut"] = Rut;
            drError["Error"] = Error;
            DtErroresCarga.Rows.Add(drError);
        }

        public DataTable GetEmpleadosExcel(string newFile, Int64 RutEmpresa)
        {
            IniciaDtErrores();

            DataTable dtTmp = new DataTable();
            string strWhere = " WHERE EM.RUT_EMPLEADO IN (";
            List<EEMPLEADO> lstEM = new List<EEMPLEADO>();
            List<EEMPLEADO> lstEM2 = new List<EEMPLEADO>();
            List<EUSUARIO> lstUS = new List<EUSUARIO>();

            //List<EEMPRESA> lstEMPR = new List<EEMPRESA>();
            List<ESUCURSAL> lstSUC = new List<ESUCURSAL>();
            List<EGERENCIA> lstGER = new List<EGERENCIA>();
            List<ECENTROCOSTO> lstCENC = new List<ECENTROCOSTO>();
            List<EUNIDAD> lstUN = new List<EUNIDAD>();
            List<EDIRECCION> lstDIR = new List<EDIRECCION>();
            List<EFAMILIACARGO> lstFC = new List<EFAMILIACARGO>();
            List<ECARGO> lstCAR = new List<ECARGO>();
            List<EAREA> lstAREA = new List<EAREA>();
            List<EROL> lstROL = new List<EROL>();
            List<ECLASIFICADOR1> lstCLA1 = new List<ECLASIFICADOR1>();
            List<ECLASIFICADOR2> lstCLA2 = new List<ECLASIFICADOR2>();

            // PARA VALIDAR
            BFNIVELEDUCACIONAL objBFNE = new BFNIVELEDUCACIONAL();
            BFNIVELOCUPACIONAL objBFNO = new BFNIVELOCUPACIONAL();
            BFCOMUNA objBFCO = new BFCOMUNA();
            BFEMPRESA objBFEMP = new BFEMPRESA();

            try
            {
                DataSet excelList = _objDALList.SelectEmpleadosByExcel(newFile);
                if (excelList.Tables.Count > 0)
                {
                    DataTable dt = excelList.Tables[0];
                    EEMPLEADO objEM = new EEMPLEADO();
                    EEMPLEADO objEM2 = new EEMPLEADO();
                    EUSUARIO objUS = new EUSUARIO();
                    int i = 0;
                    bool blnValido = true;
                    foreach (DataRow dr in dt.Rows)
                    { 
                        if (Utiles.ConvertToString(dr[0]).Trim() != "")
                        {
                            blnValido = true;
                            if (!Utiles.ValidarRut(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim()))
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "El Rut ingresado no es valido");
                                blnValido = false;
                            }
                            if (RutEmpresa != Utiles.RutUsrALng(Utiles.ConvertToString(dr[16])))
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "La empresa ingresada no es valida");
                                blnValido = false;
                            }
                            if (Utiles.ConvertToString(dr[2]).Trim() == "")
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "Debe ingresar un nombre al usuario");
                                blnValido = false;
                            }
                            if (Utiles.ConvertToString(dr[3]).Trim() == "")
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "Debe ingresar un apellido al usuario");
                                blnValido = false;
                            }
                            if (objBFCO.GetCOMUNA(Utiles.ConvertToInt64(dr[9])).CODCOMUNA == "")
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "La comuna SENCE no tiene un código valido");
                                blnValido = false;
                            }
                            if (objBFNE.GetNIVELEDUCACIONAL(Utiles.ConvertToInt16(dr[11])).CODNIVELEDUCACIONAL == 0)
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "El nivel eduacional SENCE no tiene un código valido");
                                blnValido = false;
                            }
                            if (objBFNO.GetNIVELOCUPACIONAL(Utiles.ConvertToInt16(dr[13])).CODNIVELOCUPACIONAL == 0)
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "El nivel ocupacional SENCE no tiene un código valido");
                                blnValido = false;
                            }
                            //if (objBFEMP.GetEMPRESA(Utiles.ConvertToInt16(dr[16])).RUTEMPRESA != 0)
                            //{
                            //    AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "");
                            //    blnValido = false;
                            //}
                            if (!Utiles.ValidarMail(Utiles.ConvertToString(dr[6])))
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "El email ingresado no es valido");
                                blnValido = false;
                            }
                            if (!Utiles.ValidarFecha(Utiles.ConvertToString(dr[7])))
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "La fecha de nacimiento ingresada no es valida");
                                blnValido = false;
                            }
                            if (!Utiles.ValidarFecha(Utiles.ConvertToString(dr[15])))
                            {
                                AgregaError(Utiles.ConvertToString(dr[0]).Trim() + '-' + Utiles.ConvertToString(dr[1]).Trim(), "La fecha de ingreso ingresada no es valida");
                                blnValido = false;
                            }

                            if (blnValido == true)
                            {
                                objEM = new EEMPLEADO();
                                objEM.RUTEMPLEADO = Utiles.ConvertToInt64(dr[0].ToString().Trim());
                                objEM.NOMBREEMPLEADO = Utiles.ConvertToString(dr[2].ToString().Trim());
                                objEM.APELLIDOPATERNO = Utiles.ConvertToString(dr[3].ToString().Trim());
                                objEM.APELLIDOMATERNO = Utiles.ConvertToString(dr[4].ToString().Trim());
                                objEM.EMAIL = Utiles.ConvertToString(dr[6].ToString().Trim());
                                objEM.FECHA_NACIMIENTO = Utiles.ConvertToDateTime(dr[7].ToString().Trim());
                                objEM.COD_SEXO = Utiles.ConvertToString(dr[8].ToString().Trim());
                                objEM.COD_COMUNA = Utiles.ConvertToString(dr[9].ToString().Trim());
                                objEM.COD_NIVEL_EDUCACIONAL = Utiles.ConvertToInt16(dr[11].ToString().Trim());
                                objEM.COD_NIVEL_OCUPACIONAL = Utiles.ConvertToInt16(dr[13].ToString().Trim());
                                objEM.FECHAINGRESO = Utiles.ConvertToDateTime(dr[15].ToString().Trim());
                                objEM.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                objEM.CODSUCURSAL = Utiles.ConvertToString(dr[18].ToString().Trim());
                                objEM.COD_GERENCIA = Utiles.ConvertToString(dr[20].ToString().Trim());
                                objEM.COD_CENTRO_COSTO = Utiles.ConvertToString(dr[22].ToString().Trim());
                                objEM.CODAREA = Utiles.ConvertToString(dr[24].ToString().Trim());
                                objEM.COD_UNIDAD = Utiles.ConvertToString(dr[26].ToString().Trim());
                                objEM.COD_DIRECCION = Utiles.ConvertToString(dr[28].ToString().Trim());
                                objEM.COD_FAMILIA_CARGO = Utiles.ConvertToString(dr[30].ToString().Trim());
                                objEM.CODCARGO = Utiles.ConvertToString(dr[32].ToString().Trim());
                                objEM.CODROL = Utiles.ConvertToString(dr[34].ToString().Trim());
                                objEM.COD_CLASIFICADOR_1 = Utiles.ConvertToString(dr[36].ToString().Trim());
                                objEM.COD_CLASIFICADOR_2 = Utiles.ConvertToString(dr[38].ToString().Trim());
                                objEM.RUTJEFE = Utiles.RutUsrALng(Utiles.ConvertToString(dr[40].ToString().Trim()));
                                objEM.RUTVISADOR = Utiles.RutUsrALng(Utiles.ConvertToString(dr[41].ToString().Trim()));
                                lstEM.Add(objEM);

                                objEM2 = new EEMPLEADO();
                                objEM2.RUTEMPLEADO = Utiles.ConvertToInt64(dr[0].ToString().Trim());
                                objEM2.NOMBREEMPLEADO = Utiles.ConvertToString(dr[2].ToString().Trim());
                                objEM2.APELLIDOPATERNO = Utiles.ConvertToString(dr[3].ToString().Trim());
                                objEM2.APELLIDOMATERNO = Utiles.ConvertToString(dr[4].ToString().Trim());
                                objEM2.EMAIL = Utiles.ConvertToString(dr[6].ToString().Trim());
                                objEM2.FECHA_NACIMIENTO = Utiles.ConvertToDateTime(dr[7].ToString().Trim());
                                objEM2.COD_SEXO = Utiles.ConvertToString(dr[8].ToString().Trim());
                                objEM2.COD_COMUNA = Utiles.ConvertToString(dr[9].ToString().Trim());
                                objEM2.COD_NIVEL_EDUCACIONAL = Utiles.ConvertToInt16(dr[11].ToString().Trim());
                                objEM2.COD_NIVEL_OCUPACIONAL = Utiles.ConvertToInt16(dr[13].ToString().Trim());
                                objEM2.FECHAINGRESO = Utiles.ConvertToDateTime(dr[15].ToString().Trim());
                                objEM2.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                objEM2.CODSUCURSAL = Utiles.ConvertToString(dr[18].ToString().Trim());
                                objEM2.COD_GERENCIA = Utiles.ConvertToString(dr[20].ToString().Trim());
                                objEM2.COD_CENTRO_COSTO = Utiles.ConvertToString(dr[22].ToString().Trim());
                                objEM2.CODAREA = Utiles.ConvertToString(dr[24].ToString().Trim());
                                objEM2.COD_UNIDAD = Utiles.ConvertToString(dr[26].ToString().Trim());
                                objEM2.COD_DIRECCION = Utiles.ConvertToString(dr[28].ToString().Trim());
                                objEM2.COD_FAMILIA_CARGO = Utiles.ConvertToString(dr[30].ToString().Trim());
                                objEM2.CODCARGO = Utiles.ConvertToString(dr[32].ToString().Trim());
                                objEM2.CODROL = Utiles.ConvertToString(dr[34].ToString().Trim());
                                objEM2.COD_CLASIFICADOR_1 = Utiles.ConvertToString(dr[36].ToString().Trim());
                                objEM2.COD_CLASIFICADOR_2 = Utiles.ConvertToString(dr[38].ToString().Trim());
                                objEM2.RUTJEFE = Utiles.RutUsrALng(Utiles.ConvertToString(dr[40].ToString().Trim()));
                                objEM2.RUTVISADOR = Utiles.RutUsrALng(Utiles.ConvertToString(dr[41].ToString().Trim()));
                                lstEM2.Add(objEM2);

                                //EEMPRESA objEMPR = new EEMPRESA();
                                ESUCURSAL objSUC = new ESUCURSAL();
                                EGERENCIA objGER = new EGERENCIA();
                                ECENTROCOSTO objCENC = new ECENTROCOSTO();
                                EAREA objAREA = new EAREA();
                                EUNIDAD objUNI = new EUNIDAD();
                                EDIRECCION objDIR = new EDIRECCION();
                                EFAMILIACARGO objFC = new EFAMILIACARGO();
                                ECARGO objCAR = new ECARGO();
                                EROL objROL = new EROL();
                                ECLASIFICADOR1 objCLA1 = new ECLASIFICADOR1();
                                ECLASIFICADOR2 objCLA2 = new ECLASIFICADOR2();

                                //objEMPR.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[8].ToString().Trim()));
                                //objEMPR.RAZONSOCIAL = Utiles.ConvertToString(Utiles.ConvertToString(dr[9].ToString().Trim()));
                                //objEMPR.NOMBREFANTASIA = Utiles.ConvertToString(Utiles.ConvertToString(dr[9].ToString().Trim()));
                                if ((Utiles.ConvertToString(dr[18].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[19].ToString().Trim()).Trim() != ""))
                                {
                                    objSUC.CODSUCURSAL = Utiles.ConvertToString(dr[18].ToString().Trim());
                                    objSUC.NOMBRESUCURSAL = Utiles.ConvertToString(dr[19].ToString().Trim());
                                    objSUC.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstSUC.Add(objSUC);
                                }

                                if ((Utiles.ConvertToString(dr[20].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[21].ToString().Trim()).Trim() != ""))
                                {
                                    objGER.CODGERENCIA = Utiles.ConvertToString(dr[20].ToString().Trim());
                                    objGER.NOMBREGERENCIA = Utiles.ConvertToString(dr[21].ToString().Trim());
                                    objGER.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstGER.Add(objGER);
                                }

                                if ((Utiles.ConvertToString(dr[22].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[23].ToString().Trim()).Trim() != ""))
                                {
                                    objCENC.CODCENTROCOSTO = Utiles.ConvertToString(dr[22].ToString().Trim());
                                    objCENC.NOMBRECENTROCOSTO = Utiles.ConvertToString(dr[23].ToString().Trim());
                                    objCENC.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstCENC.Add(objCENC);
                                }

                                if ((Utiles.ConvertToString(dr[24].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[25].ToString().Trim()).Trim() != ""))
                                {
                                    objAREA.CODAREA = Utiles.ConvertToString(dr[24].ToString().Trim());
                                    objAREA.NOMBREAREA = Utiles.ConvertToString(dr[25].ToString().Trim());
                                    objAREA.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstAREA.Add(objAREA);
                                }

                                if ((Utiles.ConvertToString(dr[26].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[27].ToString().Trim()).Trim() != ""))
                                {
                                    objUNI.CODUNIDAD = Utiles.ConvertToString(dr[26].ToString().Trim());
                                    objUNI.NOMUNIDAD = Utiles.ConvertToString(dr[27].ToString().Trim());
                                    objUNI.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstUN.Add(objUNI);
                                }

                                if ((Utiles.ConvertToString(dr[28].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[29].ToString().Trim()).Trim() != ""))
                                {
                                    objDIR.CODDIRECCION = Utiles.ConvertToString(dr[28].ToString().Trim());
                                    objDIR.NOMDIRECCION = Utiles.ConvertToString(dr[29].ToString().Trim());
                                    objDIR.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstDIR.Add(objDIR);
                                }

                                if ((Utiles.ConvertToString(dr[30].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[31].ToString().Trim()).Trim() != ""))
                                {
                                    objFC.CODFAMILIACARGO = Utiles.ConvertToString(dr[30].ToString().Trim());
                                    objFC.NOMFAMILIACARGO = Utiles.ConvertToString(dr[31].ToString().Trim());
                                    objFC.RUTEMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstFC.Add(objFC);
                                }

                                if ((Utiles.ConvertToString(dr[30].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[31].ToString().Trim()).Trim() != ""))
                                {
                                    objCAR.CODCARGO = Utiles.ConvertToString(dr[32].ToString().Trim());
                                    objCAR.NOMBRECARGO = Utiles.ConvertToString(dr[33].ToString().Trim());
                                    objCAR.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstCAR.Add(objCAR);
                                }

                                if ((Utiles.ConvertToString(dr[32].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[33].ToString().Trim()).Trim() != ""))
                                {
                                    objROL.CODROL = Utiles.ConvertToString(dr[34].ToString().Trim());
                                    objROL.NOMBREROL = Utiles.ConvertToString(dr[35].ToString().Trim());
                                    objROL.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstROL.Add(objROL);
                                }

                                if ((Utiles.ConvertToString(dr[34].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[35].ToString().Trim()).Trim() != ""))
                                {
                                    objCLA1.CODCLASIFICADOR1 = Utiles.ConvertToString(dr[36].ToString().Trim());
                                    objCLA1.NOMBRECLASIFICADOR1 = Utiles.ConvertToString(dr[37].ToString().Trim());
                                    objCLA1.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstCLA1.Add(objCLA1);
                                }

                                if ((Utiles.ConvertToString(dr[36].ToString().Trim()).Trim() != "") || (Utiles.ConvertToString(dr[37].ToString().Trim()).Trim() != ""))
                                {
                                    objCLA2.CODCLASIFICADOR2 = Utiles.ConvertToString(dr[38].ToString().Trim());
                                    objCLA2.NOMBRECLASIFICADOR2 = Utiles.ConvertToString(dr[39].ToString().Trim());
                                    objCLA2.RUT_EMPRESA = Utiles.RutUsrALng(Utiles.ConvertToString(dr[16].ToString().Trim()));
                                    lstCLA2.Add(objCLA2);
                                }

                                objUS = new EUSUARIO();
                                objUS.RUTUSUARIO = Utiles.ConvertToInt64(dr[0].ToString().Trim());
                                objUS.NOMBREUSUARIO = Utiles.ConvertToString(dr[2].ToString().Trim());
                                objUS.APELLIDOPATERNO = Utiles.ConvertToString(dr[3].ToString().Trim());
                                objUS.APELLIDOMATERNO = Utiles.ConvertToString(dr[4].ToString().Trim());
                                objUS.PASSWORD = CCryptografia.Encriptar(Utiles.ConvertToString(dr[5].ToString().Trim()));
                                objUS.EMAIL = Utiles.ConvertToString(dr[6].ToString().Trim());
                                objUS.FLAGACTIVO = true;
                                lstUS.Add(objUS);

                                strWhere = strWhere + Utiles.ConvertToString(dr[0].ToString().Trim()) + ",";
                            }
                        } 
                    }

                    foreach (ESUCURSAL obj in lstSUC)
                    {
                        obj.Save();
                    }
                    foreach (EGERENCIA obj in lstGER)
                    {
                        obj.Save();
                    }
                    foreach (ECENTROCOSTO obj in lstCENC)
                    {
                        obj.Save();
                    }
                    foreach (EAREA obj in lstAREA)
                    {
                        obj.Save();
                    }
                    foreach (EUNIDAD obj in lstUN)
                    {
                        obj.Save();
                    }
                    foreach (EDIRECCION obj in lstDIR)
                    {
                        obj.Save();
                    }
                    foreach (EFAMILIACARGO obj in lstFC)
                    {
                        obj.Save();
                    }
                    foreach (ECARGO obj in lstCAR)
                    {
                        obj.Save();
                    }
                    foreach (EROL obj in lstROL)
                    {
                        obj.Save();
                    }
                    foreach (ECLASIFICADOR1 obj in lstCLA1)
                    {
                        obj.Save();
                    }
                    foreach (ECLASIFICADOR2 obj in lstCLA2)
                    {
                        obj.Save();
                    }

                    foreach (EEMPLEADO obj in lstEM)
                    {
                        if (GetEMPLEADO(obj.RUTEMPLEADO).RUTEMPLEADO == obj.RUTEMPLEADO)
                        {
                            obj.IsPersisted = true;
                        }
                        else
                        {
                            obj.IsPersisted = false;
                        }
                        obj.Save();
                    }
                    foreach (EEMPLEADO obj2 in lstEM2)
                    {
                        obj2.IsPersisted = true;
                        obj2.Save();
                    }

                    BFUSUARIO objBFUS = new BFUSUARIO();
                    foreach (EUSUARIO  obj in lstUS)
                    {
                        if (objBFUS.GetUSUARIO(obj.RUTUSUARIO).RUTUSUARIO == obj.RUTUSUARIO)
                        {
                            obj.IsPersisted = true;
                        }
                        else
                        {
                            obj.IsPersisted = false;
                        }
                        obj.Save();
                    }

                    strWhere = strWhere.Substring(0, strWhere.Length - 1) + ") ";

                }
                return GetEMPLEADOSCARGADOS(strWhere);
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return dtTmp;
            }
        }

    }
}

