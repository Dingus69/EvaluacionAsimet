
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EOBJETIVOINSTRUMENTOEMPLEADO.
	/// </summary>
    public class EOBJETIVOINSTRUMENTOEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_INSTRUMENTO_EMPLEADO = 0;
        	
	    private System.Decimal  _COD_OBJETIVO = 0;
        	
	    private System.Double  _RESULTADO = 0.0;
        	
	    private System.String  _COMENTARIO = String.Empty;
        	
        
	    public EOBJETIVOINSTRUMENTOEMPLEADO() : base()
	    {
	    }
	    
		public EOBJETIVOINSTRUMENTOEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODINSTRUMENTOEMPLEADO
	    {
		    get { return _COD_INSTRUMENTO_EMPLEADO; }
		    set { _COD_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.Decimal CODOBJETIVO
	    {
		    get { return _COD_OBJETIVO; }
		    set { _COD_OBJETIVO = value; }
	    }
	    
	    	
	    public System.Double RESULTADO
	    {
		    get { return _RESULTADO; }
		    set { _RESULTADO = value; }
	    }
	    
	    	
	    public System.String COMENTARIO
	    {
		    get { return _COMENTARIO; }
		    set { _COMENTARIO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLOBJETIVOINSTRUMENTOEMPLEADO();
        }

        #endregion	    
    }
}