
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
	/// BFFAMILIACARGO.
	/// </summary>
	public class BFFAMILIACARGO
	{
		private DLFAMILIACARGO _objDAL;
		private DLFAMILIACARGOList _objDALList;
		
		public BFFAMILIACARGO()
		{
			_objDAL = new DLFAMILIACARGO();
			_objDALList = new DLFAMILIACARGOList();
		}

		public EFAMILIACARGO GetFAMILIACARGO()
		{
			return new EFAMILIACARGO();
		}

		public EFAMILIACARGO GetFAMILIACARGO(long id)
		{
            return new EFAMILIACARGO(id);
		}

		public bool Save(EFAMILIACARGO objFAMILIACARGO)
		{
			try
			{
				objFAMILIACARGO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EFAMILIACARGO> GetFAMILIACARGOAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EFAMILIACARGO> GetFAMILIACARGOAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EFAMILIACARGO objFAMILIACARGO)
		{
			try
			{
                _objDAL.Delete(objFAMILIACARGO);
			    return true;
            }
            catch (Exception ex)
            {
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EFAMILIACARGO objFAMILIACARGO)
        {
            try
            {
                _objDAL.Update(objFAMILIACARGO);
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

