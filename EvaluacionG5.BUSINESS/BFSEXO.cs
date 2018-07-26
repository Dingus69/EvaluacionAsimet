
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
	/// BFSEXO.
	/// </summary>
	public class BFSEXO
	{
		private DLSEXO _objDAL;
		private DLSEXOList _objDALList;
		
		public BFSEXO()
		{
			_objDAL = new DLSEXO();
			_objDALList = new DLSEXOList();
		}

		public ESEXO GetSEXO()
		{
			return new ESEXO();
		}

		public ESEXO GetSEXO(long id)
		{
            return new ESEXO(id);
		}

		public bool Save(ESEXO objSEXO)
		{
			try
			{
				objSEXO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ESEXO> GetSEXOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(ESEXO objSEXO)
		{
			try
			{
                _objDAL.Delete(objSEXO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ESEXO objSEXO)
        {
            try
            {
                _objDAL.Update(objSEXO);
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

