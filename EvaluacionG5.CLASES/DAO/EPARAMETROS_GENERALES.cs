
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPARAMETROSGENERALES.
	/// </summary>
    [Serializable()]
    public class EPARAMETROSGENERALES : DomainObject
    {
	    	
	    private System.String  _DOMINIO = String.Empty;
        	
	    private System.String  _EMAIL = String.Empty;
        	
	    private System.String  _PASSWORD = String.Empty;
        	
	    private System.String  _PUERTO = String.Empty;

        private System.String _SMTP = String.Empty;

        private System.String _NOMBRE_CLASIFICADOR_1 = String.Empty;

        private System.String _NOMBRE_CLASIFICADOR_2 = String.Empty;

        private System.String _URL_PLATAFORMA = String.Empty;


        public EPARAMETROSGENERALES() : base()
	    {
	    }
	    
		public EPARAMETROSGENERALES(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String DOMINIO
	    {
		    get { return _DOMINIO; }
		    set { _DOMINIO = value; }
	    }
	    
	    	
	    public System.String EMAIL
	    {
		    get { return _EMAIL; }
		    set { _EMAIL = value; }
	    }
	    
	    	
	    public System.String PASSWORD
	    {
		    get { return _PASSWORD; }
		    set { _PASSWORD = value; }
	    }
	    
	    	
	    public System.String PUERTO
	    {
		    get { return _PUERTO; }
		    set { _PUERTO = value; }
	    }

        public string SMTP
        {
            get
            {
                return _SMTP;
            }

            set
            {
                _SMTP = value;
            }
        }

        public string NOMBRE_CLASIFICADOR_1
        {
            get
            {
                return _NOMBRE_CLASIFICADOR_1;
            }

            set
            {
                _NOMBRE_CLASIFICADOR_1 = value;
            }
        }

        public string NOMBRE_CLASIFICADOR_2
        {
            get
            {
                return _NOMBRE_CLASIFICADOR_2;
            }

            set
            {
                _NOMBRE_CLASIFICADOR_2 = value;
            }
        }

        public string URL_PLATAFORMA
        {
            get
            {
                return _URL_PLATAFORMA;
            }

            set
            {
                _URL_PLATAFORMA = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPARAMETROSGENERALES();
        }

        #endregion	    
    }
}