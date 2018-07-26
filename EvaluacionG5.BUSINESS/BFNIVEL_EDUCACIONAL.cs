
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
	/// BFNIVELEDUCACIONAL.
	/// </summary>
	public class BFNIVELEDUCACIONAL
	{
		private DLNIVELEDUCACIONAL _objDAL;
		private DLNIVELEDUCACIONALList _objDALList;
		
		public BFNIVELEDUCACIONAL()
		{
			_objDAL = new DLNIVELEDUCACIONAL();
			_objDALList = new DLNIVELEDUCACIONALList();
		}

		public ENIVELEDUCACIONAL GetNIVELEDUCACIONAL()
		{
			return new ENIVELEDUCACIONAL();
		}

		public ENIVELEDUCACIONAL GetNIVELEDUCACIONAL(long id)
		{
            return new ENIVELEDUCACIONAL(id);
		}

		public bool Save(ENIVELEDUCACIONAL objNIVELEDUCACIONAL)
		{
			try
			{
				objNIVELEDUCACIONAL.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ENIVELEDUCACIONAL> GetNIVELEDUCACIONALAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ENIVELEDUCACIONAL objNIVELEDUCACIONAL)
		{
			try
			{
                _objDAL.Delete(objNIVELEDUCACIONAL);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ENIVELEDUCACIONAL objNIVELEDUCACIONAL)
        {
            try
            {
                _objDAL.Update(objNIVELEDUCACIONAL);
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

