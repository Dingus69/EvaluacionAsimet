
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
	/// BFCLASIFICADOR1.
	/// </summary>
	public class BFCLASIFICADOR1
	{
		private DLCLASIFICADOR1 _objDAL;
		private DLCLASIFICADOR1List _objDALList;
		
		public BFCLASIFICADOR1()
		{
			_objDAL = new DLCLASIFICADOR1();
			_objDALList = new DLCLASIFICADOR1List();
		}

		public ECLASIFICADOR1 GetCLASIFICADOR1()
		{
			return new ECLASIFICADOR1();
		}

		public ECLASIFICADOR1 GetCLASIFICADOR1(long id)
		{
            return new ECLASIFICADOR1(id);
		}

		public bool Save(ECLASIFICADOR1 objCLASIFICADOR1)
		{
			try
			{
				objCLASIFICADOR1.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECLASIFICADOR1> GetCLASIFICADOR1All(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(ECLASIFICADOR1 objCLASIFICADOR1)
		{
			try
			{
                _objDAL.Delete(objCLASIFICADOR1);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECLASIFICADOR1 objCLASIFICADOR1)
        {
            try
            {
                _objDAL.Update(objCLASIFICADOR1);
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

