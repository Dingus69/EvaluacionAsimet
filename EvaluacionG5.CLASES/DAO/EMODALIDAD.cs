
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EMODALIDAD.
	/// </summary>
    public class EMODALIDAD : DomainObject
    {
	    	
	    private System.Int16  _COD_MODALIDAD = 0;
        	
	    private System.String  _NOM_MODALIDAD = String.Empty;
        	
        
	    public EMODALIDAD() : base()
	    {
	    }
	    
		public EMODALIDAD(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODMODALIDAD
	    {
		    get { return _COD_MODALIDAD; }
		    set { _COD_MODALIDAD = value; }
	    }
	    
	    	
	    public System.String NOMMODALIDAD
	    {
		    get { return _NOM_MODALIDAD; }
		    set { _NOM_MODALIDAD = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLMODALIDAD();
        }

        #endregion	    
    }
}