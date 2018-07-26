
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECURSOINSTRUMENTOEMPLEADO.
	/// </summary>
    public class ECURSOINSTRUMENTOEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_INSTRUMENTO_EMPLEADO = 0;
        	
	    private System.String  _COD_CURSO = String.Empty;
        	
        
	    public ECURSOINSTRUMENTOEMPLEADO() : base()
	    {
	    }
	    
		public ECURSOINSTRUMENTOEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODINSTRUMENTOEMPLEADO
	    {
		    get { return _COD_INSTRUMENTO_EMPLEADO; }
		    set { _COD_INSTRUMENTO_EMPLEADO = value; }
	    }
	    
	    	
	    public System.String CODCURSO
	    {
		    get { return _COD_CURSO; }
		    set { _COD_CURSO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCURSOINSTRUMENTOEMPLEADO();
        }

        #endregion	    
    }
}