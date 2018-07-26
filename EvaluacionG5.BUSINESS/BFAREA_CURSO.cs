
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
	/// BFAREACURSO.
	/// </summary>
	public class BFAREACURSO
	{
		private DLAREACURSO _objDAL;
		private DLAREACURSOList _objDALList;
		
		public BFAREACURSO()
		{
			_objDAL = new DLAREACURSO();
			_objDALList = new DLAREACURSOList();
		}

		public EAREACURSO GetAREACURSO()
		{
			return new EAREACURSO();
		}

		public EAREACURSO GetAREACURSO(long id)
		{
            return new EAREACURSO(id);
		}

		public bool Save(EAREACURSO objAREACURSO)
		{
			try
			{
				objAREACURSO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EAREACURSO> GetAREACURSOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EAREACURSO objAREACURSO)
		{
			try
			{
                _objDAL.Delete(objAREACURSO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EAREACURSO objAREACURSO)
        {
            try
            {
                _objDAL.Update(objAREACURSO);
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

