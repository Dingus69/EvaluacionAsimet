
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EINSTRUMENTOCURSO.
	/// </summary>
    public class EINSTRUMENTOCURSO : DomainObject
    {
	    	
	    private System.Decimal  _COD_INSTRUMENTO = 0;
        	
	    private System.String  _COD_CURSO = String.Empty;
        	
        
	    public EINSTRUMENTOCURSO() : base()
	    {
	    }
	    
		public EINSTRUMENTOCURSO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODINSTRUMENTO
	    {
		    get { return _COD_INSTRUMENTO; }
		    set { _COD_INSTRUMENTO = value; }
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
            return new DLINSTRUMENTOCURSO();
        }

        #endregion	    
    }
}