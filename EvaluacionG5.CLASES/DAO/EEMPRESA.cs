
using System;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EEMPRESA.
	/// </summary>
    [Serializable()]
    public class EEMPRESA : DomainObject
    {
	    	
	    private System.Int64  _RUT_EMPRESA = 0;
        	
	    private System.String  _NOMBRE_FANTASIA = String.Empty;
        	
	    private System.String  _RAZON_SOCIAL = String.Empty;

        private System.String _NOMBRE_CONTACTO = String.Empty;

        private System.String _CARGO_CONTACTO = String.Empty;

        private System.String _FONO_CONTACTO = String.Empty;

        private System.String _EMAIL_CONTACTO = String.Empty;

        private System.String _GIRO = String.Empty;

        private System.Boolean _FLAG_ACTIVO = false;


        public EEMPRESA() : base()
	    {
	    }
	    
		public EEMPRESA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTEMPRESA
	    {
		    get { return _RUT_EMPRESA; }
		    set { _RUT_EMPRESA = value; }
        }

        public System.String RUTCOMPLETO
        {
            get { return Utiles.RutLngAUsr(_RUT_EMPRESA); } 
        }


        public System.String NOMBREFANTASIA
	    {
		    get { return _NOMBRE_FANTASIA; }
		    set { _NOMBRE_FANTASIA = value; }
	    }
	    
	    	
	    public System.String RAZONSOCIAL
	    {
		    get { return _RAZON_SOCIAL; }
		    set { _RAZON_SOCIAL = value; }
	    }

        public string NOMBRE_CONTACTO
        {
            get
            {
                return _NOMBRE_CONTACTO;
            }

            set
            {
                _NOMBRE_CONTACTO = value;
            }
        }

        public string CARGO_CONTACTO
        {
            get
            {
                return _CARGO_CONTACTO;
            }

            set
            {
                _CARGO_CONTACTO = value;
            }
        }

        public string FONO_CONTACTO
        {
            get
            {
                return _FONO_CONTACTO;
            }

            set
            {
                _FONO_CONTACTO = value;
            }
        }

        public string EMAIL_CONTACTO
        {
            get
            {
                return _EMAIL_CONTACTO;
            }

            set
            {
                _EMAIL_CONTACTO = value;
            }
        }

        public string GIRO
        {
            get
            {
                return _GIRO;
            }

            set
            {
                _GIRO = value;
            }
        }

        public bool FLAG_ACTIVO
        {
            get
            {
                return _FLAG_ACTIVO;
            }

            set
            {
                _FLAG_ACTIVO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLEMPRESA();
        }

        #endregion	    
    }
}