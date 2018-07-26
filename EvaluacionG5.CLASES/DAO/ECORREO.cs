
using System;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ECORREO.
	/// </summary>
    public class ECORREO : DomainObject
    {
	    	
	    private System.Int16  _COD_CORREO = 0;
        	
	    private System.String  _ASUNTO = String.Empty;
        	
	    private System.String  _CUERPO = String.Empty;
        	
        
	    public ECORREO() : base()
	    {
	    }
	    
		public ECORREO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODCORREO
	    {
		    get { return _COD_CORREO; }
		    set { _COD_CORREO = value; }
	    }
	    
	    	
	    public System.String ASUNTO
	    {
		    get { return _ASUNTO; }
		    set { _ASUNTO = value; }
	    }
	    
	    	
	    public System.String CUERPO
	    {
		    get { return _CUERPO; }
		    set { _CUERPO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLCORREO();
        }

        #endregion	    
    }
}