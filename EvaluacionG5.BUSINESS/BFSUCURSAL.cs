
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
	/// BFSUCURSAL.
	/// </summary>
	public class BFSUCURSAL
	{
		private DLSUCURSAL _objDAL;
		private DLSUCURSALList _objDALList;
		
		public BFSUCURSAL()
		{
			_objDAL = new DLSUCURSAL();
			_objDALList = new DLSUCURSALList();
		}

		public ESUCURSAL GetSUCURSAL()
		{
			return new ESUCURSAL();
		}

		public ESUCURSAL GetSUCURSAL(long id)
		{
            return new ESUCURSAL(id);
		}

		public bool Save(ESUCURSAL objSUCURSAL)
		{
			try
			{
				objSUCURSAL.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ESUCURSAL> GetSUCURSALAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(ESUCURSAL objSUCURSAL)
		{
			try
			{
                _objDAL.Delete(objSUCURSAL);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ESUCURSAL objSUCURSAL)
        {
            try
            {
                _objDAL.Update(objSUCURSAL);
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

