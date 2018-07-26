
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EGERENCIA.
	/// </summary>
    [Serializable()]
    public class EGERENCIA : DomainObject
    {
	    	
	    private System.String  _COD_GERENCIA = String.Empty;
        	
	    private System.String  _NOMBRE_GERENCIA = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public EGERENCIA() : base()
	    {
	    }
	    
		public EGERENCIA(long id) : base(id)
		{
        }

        #region Properties    	

        public System.String CODGERENCIA
	    {
		    get { return _COD_GERENCIA; }
		    set { _COD_GERENCIA = value; }
	    }
	    
	    	
	    public System.String NOMBREGERENCIA
	    {
		    get { return _NOMBRE_GERENCIA; }
		    set { _NOMBRE_GERENCIA = value; }
	    }

        public long RUT_EMPRESA
        {
            get
            {
                return _RUT_EMPRESA;
            }

            set
            {
                _RUT_EMPRESA = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLGERENCIA();
        }

        #endregion	    
    }
}