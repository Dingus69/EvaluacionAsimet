
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
	/// BFCOMUNA.
	/// </summary>
	public class BFCOMUNA
	{
		private DLCOMUNA _objDAL;
		private DLCOMUNAList _objDALList;
		
		public BFCOMUNA()
		{
			_objDAL = new DLCOMUNA();
			_objDALList = new DLCOMUNAList();
		}

		public ECOMUNA GetCOMUNA()
		{
			return new ECOMUNA();
		}

		public ECOMUNA GetCOMUNA(long id)
		{
            return new ECOMUNA(id);
		}

		public bool Save(ECOMUNA objCOMUNA)
		{
			try
			{
				objCOMUNA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECOMUNA> GetCOMUNAAll()
		{
			return _objDALList.SelectAll();
        }

        public List<ECOMUNA> GetCOMUNAAll(int CodRegion)
        {
            return _objDALList.SelectAll(CodRegion);
        }

        public bool Delete(ECOMUNA objCOMUNA)
		{
			try
			{
                _objDAL.Delete(objCOMUNA);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECOMUNA objCOMUNA)
        {
            try
            {
                _objDAL.Update(objCOMUNA);
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

