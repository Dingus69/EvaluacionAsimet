using System;
using System.Collections.Generic;
using EvaluacionG5.COMMON;
using EvaluacionG5.BUSINESS;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.CLASES.DAO;

namespace EvaluacionG5.BUSINESS
{
    public class BFSESSIONUSUARIO
    {
        private DLSESSIONUSUARIO _objDAL;

        public BFSESSIONUSUARIO()
        {
            _objDAL = new DLSESSIONUSUARIO();
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIO()
        {
            return new ESESSIONUSUARIO();
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIO(long id)
        {
            return new ESESSIONUSUARIO(id);
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIO(long Rut, String Passwd)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuario(Rut, Passwd);

            return objUSUARIO;
        }

        public ESESSIONUSUARIO GetSESSIONUSUARIONONSECURE(long Rut)
        {
            ESESSIONUSUARIO objUSUARIO = _objDAL.SelectSessionUsuarioNonSecure(Rut);

            return objUSUARIO;
        }

        public bool Update(ESESSIONUSUARIO objSESSIONUSUARIO)
        {
            try
            {
                _objDAL.Update(objSESSIONUSUARIO);
                return true;
            }
            catch (Exception ex)
            {
                Log objLog = new Log();
                objLog.EscribirLog(ex);
                return false;
            }
        }

    }
}

