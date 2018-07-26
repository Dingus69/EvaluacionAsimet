
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
	/// BFESTADOINSTRUMENTO.
	/// </summary>
	public class BFESTADOINSTRUMENTO
	{
		private DLESTADOINSTRUMENTO _objDAL;
		private DLESTADOINSTRUMENTOList _objDALList;
		
		public BFESTADOINSTRUMENTO()
		{
			_objDAL = new DLESTADOINSTRUMENTO();
			_objDALList = new DLESTADOINSTRUMENTOList();
		}

		public EESTADOINSTRUMENTO GetESTADOINSTRUMENTO()
		{
			return new EESTADOINSTRUMENTO();
		}

		public EESTADOINSTRUMENTO GetESTADOINSTRUMENTO(long id)
		{
            return new EESTADOINSTRUMENTO(id);
		}

		public bool Save(EESTADOINSTRUMENTO objESTADOINSTRUMENTO)
		{
			try
			{
				objESTADOINSTRUMENTO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EESTADOINSTRUMENTO> GetESTADOINSTRUMENTOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EESTADOINSTRUMENTO objESTADOINSTRUMENTO)
		{
			try
			{
                _objDAL.Delete(objESTADOINSTRUMENTO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EESTADOINSTRUMENTO objESTADOINSTRUMENTO)
        {
            try
            {
                _objDAL.Update(objESTADOINSTRUMENTO);
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

