
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
	/// BFTIPOSECCION.
	/// </summary>
	public class BFTIPOSECCION
	{
		private DLTIPOSECCION _objDAL;
		private DLTIPOSECCIONList _objDALList;
		
		public BFTIPOSECCION()
		{
			_objDAL = new DLTIPOSECCION();
			_objDALList = new DLTIPOSECCIONList();
		}

		public ETIPOSECCION GetTIPOSECCION()
		{
			return new ETIPOSECCION();
		}

		public ETIPOSECCION GetTIPOSECCION(long id)
		{
            return new ETIPOSECCION(id);
        }

        public Boolean PoseeDatosRelacionados(Decimal CodTipoSeccion)
        {
            return _objDALList.PoseeDatosRelacionados(CodTipoSeccion);
        }

        public bool Save(ETIPOSECCION objTIPOSECCION)
		{
			try
			{
                if (GetTIPOSECCION(objTIPOSECCION.CODTIPOSECCION).CODTIPOSECCION == objTIPOSECCION.CODTIPOSECCION)
                {
                    objTIPOSECCION.IsPersisted = true;
                }
                else
                {
                    objTIPOSECCION.CODTIPOSECCION = Serial();
                    objTIPOSECCION.IsPersisted = false;
                }

                objTIPOSECCION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ETIPOSECCION> GetTIPOSECCIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ETIPOSECCION objTIPOSECCION)
		{
			try
			{
                _objDAL.Delete(objTIPOSECCION);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ETIPOSECCION objTIPOSECCION)
        {
            try
            {
                _objDAL.Update(objTIPOSECCION);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public Int16 Serial()
        {
            Int16 intSerial = 0;
            try
            {
                return _objDALList.Serial();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return intSerial;
            }
        }

    }
}

