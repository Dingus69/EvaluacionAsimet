
using System;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
	/// <summary>
	/// BFCORREO.
	/// </summary>
	public class BFCORREO
	{
		private DLCORREO _objDAL;
		private DLCORREOList _objDALList;
		
		public BFCORREO()
		{
			_objDAL = new DLCORREO();
			_objDALList = new DLCORREOList();
		}

		public ECORREO GetCORREO()
		{
			return new ECORREO();
		}

		public ECORREO GetCORREO(long id)
		{
            return new ECORREO(id);
		}

		public bool Save(ECORREO objCORREO)
		{
			try
			{
				objCORREO.Save();
				return true;
			}
			catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

		public List<ECORREO> GetCORREOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECORREO objCORREO)
		{
			try
			{
                _objDAL.Delete(objCORREO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECORREO objCORREO)
        {
            try
            {
                _objDAL.Update(objCORREO);
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

