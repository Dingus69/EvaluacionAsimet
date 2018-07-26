
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
	/// BFINSTRUMENTOCURSO.
	/// </summary>
	public class BFINSTRUMENTOCURSO
	{
		private DLINSTRUMENTOCURSO _objDAL;
		private DLINSTRUMENTOCURSOList _objDALList;
		
		public BFINSTRUMENTOCURSO()
		{
			_objDAL = new DLINSTRUMENTOCURSO();
			_objDALList = new DLINSTRUMENTOCURSOList();
		}

		public EINSTRUMENTOCURSO GetINSTRUMENTOCURSO()
		{
			return new EINSTRUMENTOCURSO();
		}

		public EINSTRUMENTOCURSO GetINSTRUMENTOCURSO(long id)
		{
            return new EINSTRUMENTOCURSO(id);
		}

		public bool Save(EINSTRUMENTOCURSO objINSTRUMENTOCURSO)
		{
			try
			{
				objINSTRUMENTOCURSO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EINSTRUMENTOCURSO> GetINSTRUMENTOCURSOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EINSTRUMENTOCURSO objINSTRUMENTOCURSO)
		{
			try
			{
                _objDAL.Delete(objINSTRUMENTOCURSO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EINSTRUMENTOCURSO objINSTRUMENTOCURSO)
        {
            try
            {
                _objDAL.Update(objINSTRUMENTOCURSO);
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

