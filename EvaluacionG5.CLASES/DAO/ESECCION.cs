
using System;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESECCION.
	/// </summary>
    [Serializable()]
    public class ESECCION : DomainObject
    {
	    	
	    private System.Decimal  _COD_SECCION = 0;
        	
	    private System.Decimal  _COD_INSTRUMENTO = 0;
        	
	    private System.Int16  _COD_TIPO_SECCION = 0;
        	
	    private System.String  _NOMBRE = String.Empty;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
	    private System.Int16  _ORDEN = 0;

        private System.Boolean _FLAG_AGREGAR_PREGUNTA = false;

        private System.Double  _PONDERACION = 0.0;

        private List<EPREGUNTA> _PREGUNTAS = new List<EPREGUNTA>();
        	
        
	    public ESECCION() : base()
	    {
	    }
	    
		public ESECCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODSECCION
	    {
		    get { return _COD_SECCION; }
		    set { _COD_SECCION = value; }
	    }
	    
	    	
	    public System.Decimal CODINSTRUMENTO
	    {
		    get { return _COD_INSTRUMENTO; }
		    set { _COD_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.Int16 CODTIPOSECCION
	    {
		    get { return _COD_TIPO_SECCION; }
		    set { _COD_TIPO_SECCION = value; }
	    }
	    
	    	
	    public System.String NOMBRE
	    {
		    get { return _NOMBRE; }
		    set { _NOMBRE = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    	
	    public System.Int16 ORDEN
	    {
		    get { return _ORDEN; }
		    set { _ORDEN = value; }
	    }
	    
	    	
	    public System.Double PONDERACION
	    {
		    get { return _PONDERACION; }
		    set { _PONDERACION = value; }
	    }

        public List<EPREGUNTA> PREGUNTAS
        {
            get { return _PREGUNTAS; }
            set { _PREGUNTAS = value; }
        }

        public bool FLAG_AGREGAR_PREGUNTA
        {
            get { return _FLAG_AGREGAR_PREGUNTA; }
            set { _FLAG_AGREGAR_PREGUNTA = value; }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSECCION();
        }

        #endregion	    
    }
}