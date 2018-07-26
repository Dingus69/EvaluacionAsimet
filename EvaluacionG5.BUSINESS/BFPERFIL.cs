
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
	/// BFPERFIL.
	/// </summary>
	public class BFPERFIL
	{
		private DLPERFIL _objDAL;
		private DLPERFILList _objDALList;
		
		public BFPERFIL()
		{
			_objDAL = new DLPERFIL();
			_objDALList = new DLPERFILList();
		}

		public EPERFIL GetPERFIL()
		{
			return new EPERFIL();
		}

		public EPERFIL GetPERFIL(long id)
		{
            return new EPERFIL(id);
		}

		public bool Save(EPERFIL objPERFIL)
		{
			try
			{
				objPERFIL.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EPERFIL> GetPERFILAll()
		{
			return _objDALList.SelectAll();
        }

        public List<EPERFIL> GetPerfilesAsignados(Int64 RutUsuario)
        {
            return _objDALList.GetPerfilesAsignados(RutUsuario);
        }

        public List<EPERFIL> GetPerfilesDisponibles(Int64 RutUsuario)
        {
            return _objDALList.GetPerfilesDisponibles(RutUsuario);
        }

        public bool Delete(EPERFIL objPERFIL)
		{
			try
			{
                _objDAL.Delete(objPERFIL);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EPERFIL objPERFIL)
        {
            try
            {
                _objDAL.Update(objPERFIL);
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

