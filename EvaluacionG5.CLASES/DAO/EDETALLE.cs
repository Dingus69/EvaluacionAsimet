
using System;
using EvaluacionG5.CLASES.DAL;
using System.Data;

namespace EvaluacionG5.CLASES.DAO
{
    [Serializable()]
    public class EDETALLE : DomainObject
    {
        private System.String _COMENTARIO_FEEDBACK = String.Empty;

        private DataTable _SECCIONES = new DataTable();

        public string COMENTARIO_FEEDBACK
        {
            get
            {
                return _COMENTARIO_FEEDBACK;
            }

            set
            {
                _COMENTARIO_FEEDBACK = value;
            }
        }

        public DataTable SECCIONES
        {
            get
            {
                return _SECCIONES;
            }

            set
            {
                _SECCIONES = value;
            }
        }

        public EDETALLE() : base()
	    {
        }

        public EDETALLE(long id) : base(id)
		{
        }

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLACCION();
        }

        #endregion	



    }
}
