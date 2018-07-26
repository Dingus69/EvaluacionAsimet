
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
	/// BFCARGOINSTRUMENTO.
	/// </summary>
	public class BFCARGOINSTRUMENTO
	{
		private DLCARGOINSTRUMENTO _objDAL;
		private DLCARGOINSTRUMENTOList _objDALList;
		
		public BFCARGOINSTRUMENTO()
		{
			_objDAL = new DLCARGOINSTRUMENTO();
			_objDALList = new DLCARGOINSTRUMENTOList();
		}

		public ECARGOINSTRUMENTO GetCARGOINSTRUMENTO()
		{
			return new ECARGOINSTRUMENTO();
		}

		public ECARGOINSTRUMENTO GetCARGOINSTRUMENTO(long id)
		{
            return new ECARGOINSTRUMENTO(id);
		}

		public bool Save(ECARGOINSTRUMENTO objCARGOINSTRUMENTO)
		{
			try
			{
				objCARGOINSTRUMENTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECARGOINSTRUMENTO> GetCARGOINSTRUMENTOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ECARGOINSTRUMENTO objCARGOINSTRUMENTO)
		{
			try
			{
                _objDAL.Delete(objCARGOINSTRUMENTO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECARGOINSTRUMENTO objCARGOINSTRUMENTO)
        {
            try
            {
                _objDAL.Update(objCARGOINSTRUMENTO);
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

