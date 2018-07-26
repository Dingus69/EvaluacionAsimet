
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
	/// BFREGION.
	/// </summary>
	public class BFREGION
	{
		private DLREGION _objDAL;
		private DLREGIONList _objDALList;
		
		public BFREGION()
		{
			_objDAL = new DLREGION();
			_objDALList = new DLREGIONList();
		}

		public EREGION GetREGION()
		{
			return new EREGION();
		}

		public EREGION GetREGION(long id)
		{
            return new EREGION(id);
		}

		public bool Save(EREGION objREGION)
		{
			try
			{
				objREGION.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EREGION> GetREGIONAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EREGION objREGION)
		{
			try
			{
                _objDAL.Delete(objREGION);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EREGION objREGION)
        {
            try
            {
                _objDAL.Update(objREGION);
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

