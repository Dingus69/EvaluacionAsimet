
using System;
using EvaluacionG5.CLASES.DAL;
using System.Collections.Generic;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EESCALA.
	/// </summary>
    [Serializable()]
    public class EESCALA : DomainObject
    {
	    	
	    private System.Decimal  _CODESCALA = 0;
        	
	    private System.String  _NOMESCALA = String.Empty;
        	
	    private System.Double  _VALORMENOR = 0.0;
        	
	    private System.Double  _VALORMAYOR = 0.0;

        private System.String _INSTRUCCIONES = String.Empty;

        private System.Boolean _FLAG_RANGOS = false;

        private System.Int64 _RUT_EMPRESA = 0;

        private List<ECATEGORIA> _CATEGORIAS = new List<ECATEGORIA>();

        private List<ERANGO> _RANGOS = new List<ERANGO>();


        public EESCALA() : base()
	    {
	    }
	    
		public EESCALA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODESCALA
	    {
		    get { return _CODESCALA; }
		    set { _CODESCALA = value; }
	    }
	    
	    	
	    public System.String NOMESCALA
	    {
		    get { return _NOMESCALA; }
		    set { _NOMESCALA = value; }
	    }
	    
	    	
	    public System.Double VALORMENOR
	    {
		    get { return _VALORMENOR; }
		    set { _VALORMENOR = value; }
	    }
	    
	    	
	    public System.Double VALORMAYOR
	    {
		    get { return _VALORMAYOR; }
		    set { _VALORMAYOR = value; }
	    }

        public string INSTRUCCIONES
        {
            get
            {
                return _INSTRUCCIONES;
            }

            set
            {
                _INSTRUCCIONES = value;
            }
        }

        public List<ECATEGORIA> CATEGORIAS
        {
            get
            {
                return _CATEGORIAS;
            }

            set
            {
                _CATEGORIAS = value;
            }
        }

        public bool FLAG_RANGOS
        {
            get
            {
                return _FLAG_RANGOS;
            }

            set
            {
                _FLAG_RANGOS = value;
            }
        }

        public List<ERANGO> RANGOS
        {
            get
            {
                return _RANGOS;
            }

            set
            {
                _RANGOS = value;
            }
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
            return new DLESCALA();
        }

        #endregion	    
    }
}