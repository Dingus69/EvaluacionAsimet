
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
	/// BFCARGO.
	/// </summary>
	public class BFCARGO
	{
		private DLCARGO _objDAL;
		private DLCARGOList _objDALList;
		
		public BFCARGO()
		{
			_objDAL = new DLCARGO();
			_objDALList = new DLCARGOList();
		}

		public ECARGO GetCARGO()
		{
			return new ECARGO();
		}

		public ECARGO GetCARGO(long id)
		{
            return new ECARGO(id);
		}

		public bool Save(ECARGO objCARGO)
		{
			try
			{
				objCARGO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECARGO> GetCARGOAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(ECARGO objCARGO)
		{
			try
			{
                _objDAL.Delete(objCARGO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECARGO objCARGO)
        {
            try
            {
                _objDAL.Update(objCARGO);
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

