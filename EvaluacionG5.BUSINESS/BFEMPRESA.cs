
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
	/// BFEMPRESA.
	/// </summary>
	public class BFEMPRESA
	{
		private DLEMPRESA _objDAL;
		private DLEMPRESAList _objDALList;
		
		public BFEMPRESA()
		{
			_objDAL = new DLEMPRESA();
			_objDALList = new DLEMPRESAList();
		}

		public EEMPRESA GetEMPRESA()
		{
			return new EEMPRESA();
		}

		public EEMPRESA GetEMPRESA(long id)
		{
            return new EEMPRESA(id);
		}

		public bool Save(EEMPRESA objEMPRESA)
		{
			try
			{
				objEMPRESA.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EEMPRESA> GetEMPRESAAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EEMPRESA> GetEMPRESAAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll();
        }

        public List<EEMPRESA> GetEmpresasByRutOrName(Int64 RutEmpresa, string Nombre)
        {
            return _objDALList.GetEmpresasByRutOrName(RutEmpresa, Nombre);
        }

        public bool Delete(EEMPRESA objEMPRESA)
		{
			try
			{
                _objDAL.Delete(objEMPRESA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EEMPRESA objEMPRESA)
        {
            try
            {
                _objDAL.Update(objEMPRESA);
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

