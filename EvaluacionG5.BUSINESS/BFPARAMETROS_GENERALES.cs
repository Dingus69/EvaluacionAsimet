
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
	/// BFPARAMETROSGENERALES.
	/// </summary>
	public class BFPARAMETROSGENERALES
	{
		private DLPARAMETROSGENERALES _objDAL;
		private DLPARAMETROSGENERALESList _objDALList;
		
		public BFPARAMETROSGENERALES()
		{
			_objDAL = new DLPARAMETROSGENERALES();
			_objDALList = new DLPARAMETROSGENERALESList();
		}

		public EPARAMETROSGENERALES GetPARAMETROSGENERALES()
		{
			return new EPARAMETROSGENERALES();
		}

		public EPARAMETROSGENERALES GetPARAMETROSGENERALES(long id)
		{
            return new EPARAMETROSGENERALES(id);
		}

		public bool Save(EPARAMETROSGENERALES objPARAMETROSGENERALES)
		{
			try
			{
				objPARAMETROSGENERALES.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPARAMETROSGENERALES> GetPARAMETROSGENERALESAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EPARAMETROSGENERALES objPARAMETROSGENERALES)
		{
			try
			{
                _objDAL.Delete(objPARAMETROSGENERALES);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPARAMETROSGENERALES objPARAMETROSGENERALES)
        {
            try
            {
                _objDAL.Update(objPARAMETROSGENERALES);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

	}
}

