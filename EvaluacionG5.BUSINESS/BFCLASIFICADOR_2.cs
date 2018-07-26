
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
	/// BFCLASIFICADOR2.
	/// </summary>
	public class BFCLASIFICADOR2
	{
		private DLCLASIFICADOR2 _objDAL;
		private DLCLASIFICADOR2List _objDALList;
		
		public BFCLASIFICADOR2()
		{
			_objDAL = new DLCLASIFICADOR2();
			_objDALList = new DLCLASIFICADOR2List();
		}

		public ECLASIFICADOR2 GetCLASIFICADOR2()
		{
			return new ECLASIFICADOR2();
		}

		public ECLASIFICADOR2 GetCLASIFICADOR2(long id)
		{
            return new ECLASIFICADOR2(id);
		}

		public bool Save(ECLASIFICADOR2 objCLASIFICADOR2)
		{
			try
			{
				objCLASIFICADOR2.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<ECLASIFICADOR2> GetCLASIFICADOR2All(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(ECLASIFICADOR2 objCLASIFICADOR2)
		{
			try
			{
                _objDAL.Delete(objCLASIFICADOR2);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(ECLASIFICADOR2 objCLASIFICADOR2)
        {
            try
            {
                _objDAL.Update(objCLASIFICADOR2);
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

