
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTASECCION.
	/// </summary>
    [Serializable()]
    public class EPREGUNTASECCION : DomainObject
    {
	    	
	    private System.Decimal  _COD_PREGUNTA = 0;
        	
	    private System.Decimal  _COD_SECCION = 0;
        	
	    private System.Double  _PONDERACION = 0.0;
        	
        
	    public EPREGUNTASECCION() : base()
	    {
	    }
	    
		public EPREGUNTASECCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODPREGUNTA
	    {
		    get { return _COD_PREGUNTA; }
		    set { _COD_PREGUNTA = value; }
	    }
	    
	    	
	    public System.Decimal CODSECCION
	    {
		    get { return _COD_SECCION; }
		    set { _COD_SECCION = value; }
	    }
	    
	    	
	    public System.Double PONDERACION
	    {
		    get { return _PONDERACION; }
		    set { _PONDERACION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLPREGUNTASECCION();
        }

        #endregion	    
    }
}