
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
	/// BFESCALA.
	/// </summary>
	public class BFESCALA
	{
		private DLESCALA _objDAL;
		private DLESCALAList _objDALList;
		
		public BFESCALA()
		{
			_objDAL = new DLESCALA();
			_objDALList = new DLESCALAList();
		}

		public EESCALA GetESCALA()
		{
			return new EESCALA();
		}

		public EESCALA GetESCALA(long id)
		{
            return new EESCALA(id);
		}

		public bool Save(EESCALA objESCALA)
		{
			try
            {
                if (GetESCALA(Utiles.ConvertToInt64(objESCALA.CODESCALA)).CODESCALA == objESCALA.CODESCALA)
                {
                    objESCALA.IsPersisted = true;
                }
                else
                {
                    objESCALA.CODESCALA = Serial();
                    objESCALA.IsPersisted = false;
                }
                objESCALA.Save();

                BFCATEGORIA objBFCA = new BFCATEGORIA();
                BFCATEGORIAESCALA objBFCE = new BFCATEGORIAESCALA();
                objBFCE.DeletePorEscala(objESCALA.CODESCALA);

                foreach (ECATEGORIA objCA in objESCALA.CATEGORIAS)
                {
                    objBFCA.Save(objCA);
                    ECATEGORIAESCALA objCE = new ECATEGORIAESCALA();
                    objCE.CODCATEGORIA = objCA.CODCATEGORIA;
                    objCE.CODESCALA = objESCALA.CODESCALA;
                    objBFCE.Save(objCE);
                }

                BFRANGO objBFRA = new BFRANGO();
                objBFRA.DeletePorEscala(objESCALA.CODESCALA);

                foreach (ERANGO objRA in objESCALA.RANGOS)
                {
                    objRA.CODESCALA = objESCALA.CODESCALA;
                    objBFRA.Save(objRA);
                }

                return true;
			}
			catch (Exception ex)
			{
				Log log = new Log();
                log.EscribirLog(ex);
                return false;
			}
        }

        public Boolean PoseeDatosRelacionados(Decimal CodEscala)
        {
            return _objDALList.PoseeDatosRelacionados(CodEscala);
        }

  //      public List<EESCALA> GetESCALAAll()
		//{
		//	return _objDALList.SelectAll();
  //      }

        public List<EESCALA> GetESCALAAll(Int64 RutEmpresa)
        {
            return _objDALList.SelectAll(RutEmpresa);
        }

        public bool Delete(EESCALA objESCALA)
		{
			try
			{
                _objDAL.Delete(objESCALA);
			    return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
		}

        public bool Update(EESCALA objESCALA)
        {
            try
            {
                _objDAL.Update(objESCALA);
                return true;
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return false;
            }
        }

        public Int16 Serial()
        {
            Int16 intSerial = 0;
            try
            {
                return _objDALList.Serial();
            }
            catch (Exception ex)
            {
                Log log = new Log();
                log.EscribirLog(ex);
                return intSerial;
            }
        }

    }
}

