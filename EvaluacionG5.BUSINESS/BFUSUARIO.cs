
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
	/// BFUSUARIO.
	/// </summary>
	public class BFUSUARIO
	{
		private DLUSUARIO _objDAL;
		private DLUSUARIOList _objDALList;
		
		public BFUSUARIO()
		{
			_objDAL = new DLUSUARIO();
			_objDALList = new DLUSUARIOList();
		}

		public EUSUARIO GetUSUARIO()
		{
			return new EUSUARIO();
		}

		public EUSUARIO GetUSUARIO(long id)
		{
            return new EUSUARIO(id);
        }

        public DataTable GetUsuariosDT(Int64 Rut, string Nombre)
        {
            return _objDALList.GetUsuariosDT(Rut, Nombre);
        }

        public List<EUSUARIO> GetUsuarios(Int64 Rut, string Nombre)
        {
            return _objDALList.GetUsuarios(Rut, Nombre);
        }

        public bool Save(EUSUARIO objUSUARIO)
		{
			try
			{
				objUSUARIO.Save();
				return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
		}

		public List<EUSUARIO> GetUSUARIOAll()
		{
			return _objDALList.SelectAll();
		}

        public bool Delete(EUSUARIO objUSUARIO)
		{
			try
			{
                _objDAL.Delete(objUSUARIO);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EUSUARIO objUSUARIO)
        {
            try
            {
                _objDAL.Update(objUSUARIO);
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

