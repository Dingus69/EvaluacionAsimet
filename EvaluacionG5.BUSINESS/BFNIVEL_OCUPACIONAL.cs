
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
	/// BFNIVELOCUPACIONAL.
	/// </summary>
	public class BFNIVELOCUPACIONAL
	{
		private DLNIVELOCUPACIONAL _objDAL;
		private DLNIVELOCUPACIONALList _objDALList;
		
		public BFNIVELOCUPACIONAL()
		{
			_objDAL = new DLNIVELOCUPACIONAL();
			_objDALList = new DLNIVELOCUPACIONALList();
		}

		public ENIVELOCUPACIONAL GetNIVELOCUPACIONAL()
		{
			return new ENIVELOCUPACIONAL();
		}

		public ENIVELOCUPACIONAL GetNIVELOCUPACIONAL(long id)
		{
            return new ENIVELOCUPACIONAL(id);
		}

		public bool Save(ENIVELOCUPACIONAL objNIVELOCUPACIONAL)
		{
			try
			{
				objNIVELOCUPACIONAL.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ENIVELOCUPACIONAL> GetNIVELOCUPACIONALAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ENIVELOCUPACIONAL objNIVELOCUPACIONAL)
		{
			try
			{
                _objDAL.Delete(objNIVELOCUPACIONAL);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ENIVELOCUPACIONAL objNIVELOCUPACIONAL)
        {
            try
            {
                _objDAL.Update(objNIVELOCUPACIONAL);
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

