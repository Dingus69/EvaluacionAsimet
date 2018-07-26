
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
	/// BFGRADO.
	/// </summary>
	public class BFGRADO
	{
		private DLGRADO _objDAL;
		private DLGRADOList _objDALList;
		
		public BFGRADO()
		{
			_objDAL = new DLGRADO();
			_objDALList = new DLGRADOList();
		}

		public EGRADO GetGRADO()
		{
			return new EGRADO();
		}

		public EGRADO GetGRADO(long id)
		{
            return new EGRADO(id);
		}

		public bool Save(EGRADO objGRADO)
		{
			try
			{
				objGRADO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EGRADO> GetGRADOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EGRADO objGRADO)
		{
			try
			{
                _objDAL.Delete(objGRADO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EGRADO objGRADO)
        {
            try
            {
                _objDAL.Update(objGRADO);
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

