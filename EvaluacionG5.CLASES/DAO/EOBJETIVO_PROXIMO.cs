
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EOBJETIVOPROXIMO.
	/// </summary>
    public class EOBJETIVOPROXIMO : DomainObject
    {
	    	
	    private System.Decimal  _COD_OBJETIVO = 0;
        	
	    private System.Decimal  _COD_INSTRUMENTO_EMPLEADO = 0;
        	
	    private System.String  _NOM_OBJETIVO = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.Double  _PONDERACION = 0.0;
        	
	    private System.Boolean  _FLAG_ASIGNADO = false;
        	
	    private System.Boolean  _FLAG_EVALUADO = false;

        private System.Decimal _RESULTADO = 0;

        private System.String _COMENTARIO = String.Empty;


        public EOBJETIVOPROXIMO() : base()
	    {
	    }
	    
		public EOBJETIVOPROXIMO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODOBJETIVO
	    {
		    get { return _COD_OBJETIVO; }
		    set { _COD_OBJETIVO = value; }
	    }
	    
	    	
	    public System.Decimal CODINSTRUMENTOEMPLEADO
	    {
		    get { return _COD_INSTRUMENTO_EMPLEADO; }
		    set { _COD_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.String NOMOBJETIVO
	    {
		    get { return _NOM_OBJETIVO; }
		    set { _NOM_OBJETIVO = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.Double PONDERACION
	    {
		    get { return _PONDERACION; }
		    set { _PONDERACION = value; }
	    }
	    
	    	
	    public System.Boolean FLAGASIGNADO
	    {
		    get { return _FLAG_ASIGNADO; }
		    set { _FLAG_ASIGNADO = value; }
	    }
	    
	    	
	    public System.Boolean FLAGEVALUADO
	    {
		    get { return _FLAG_EVALUADO; }
		    set { _FLAG_EVALUADO = value; }
	    }

        public decimal RESULTADO
        {
            get
            {
                return _RESULTADO;
            }

            set
            {
                _RESULTADO = value;
            }
        }

        public string COMENTARIO
        {
            get
            {
                return _COMENTARIO;
            }

            set
            {
                _COMENTARIO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLOBJETIVOPROXIMO();
        }

        #endregion	    
    }
}