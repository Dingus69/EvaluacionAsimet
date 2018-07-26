
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
	/// BFSECCION.
	/// </summary>
	public class BFSECCION
	{
		private DLSECCION _objDAL;
		private DLSECCIONList _objDALList;
		
		public BFSECCION()
		{
			_objDAL = new DLSECCION();
			_objDALList = new DLSECCIONList();
		}

		public ESECCION GetSECCION()
		{
			return new ESECCION();
		}

		public ESECCION GetSECCION(long id)
		{
            return new ESECCION(id);
		}

		public bool Save(ESECCION objSECCION)
		{
			try
			{
				objSECCION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ESECCION> GetSECCIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ESECCION objSECCION)
		{
			try
			{
                _objDAL.Delete(objSECCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ESECCION objSECCION)
        {
            try
            {
                _objDAL.Update(objSECCION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public List<ESECCION> GetSeccionesExcel(string newFile)
        {
            List<ESECCION> lst = new List<ESECCION>();
            try
            {
                DataSet excelList = _objDALList.SelectPreguntasByExcel(newFile);
                if (excelList.Tables.Count > 0)
                {
                    DataTable dt = excelList.Tables[0];
                    ESECCION objSE = new ESECCION();
                    objSE.NOMBRE = Utiles.ConvertToString(dt.Rows[0][0]);
                    objSE.CODTIPOSECCION = Utiles.ConvertToInt16(dt.Rows[0][1]);
                    objSE.ORDEN = Utiles.ConvertToInt16(dt.Rows[0][2]);
                    objSE.PONDERACION = Utiles.ConvertToDouble(dt.Rows[0][3]);
                    objSE.DESCRIPCION = Utiles.ConvertToString(dt.Rows[0][4]);
                    lst.Add(objSE);

                    string strNombre = Utiles.ConvertToString(dt.Rows[0][0]);
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (strNombre != Utiles.ConvertToString(dr[0]))
                        {
                            objSE = new ESECCION();
                            objSE.NOMBRE = Utiles.ConvertToString(dr[0]);
                            objSE.CODTIPOSECCION = Utiles.ConvertToInt16(dr[1]);
                            objSE.ORDEN = Utiles.ConvertToInt16(dr[2]);
                            objSE.PONDERACION = Utiles.ConvertToDouble(dr[3]);
                            objSE.DESCRIPCION = Utiles.ConvertToString(dr[4]);
                            lst.Add(objSE);
                            strNombre = Utiles.ConvertToString(dr[0]);
                        }

                    }
                    foreach (ESECCION obj in lst)
                    {
                        List<EPREGUNTA> lstPR = new List<EPREGUNTA>();
                        EPREGUNTA objPR = new EPREGUNTA();
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (obj.NOMBRE == Utiles.ConvertToString(dr[0]))
                            {
                                objPR = new EPREGUNTA();
                                objPR.TEXTO = Utiles.ConvertToString(dr[5]);
                                objPR.PONDERACION = Utiles.ConvertToDouble(dr[6]);
                                objPR.DESCRIPCION = Utiles.ConvertToString(dr[7]);
                                objPR.ACCION = Utiles.ConvertToString(dr[8]);
                                objPR.COMPROMISO = Utiles.ConvertToString(dr[9]);
                                objPR.INDICADOR = Utiles.ConvertToString(dr[10]);
                                lstPR.Add(objPR);
                            }
                        }
                        if (lstPR.Count == 0)
                        {
                            lstPR.Add(objPR);
                        }
                        obj.PREGUNTAS = lstPR;
                    }
                }
                return lst;
            }
            catch(Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return lst;
            }
        }

	}
}

