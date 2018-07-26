
using System;
using System.Collections.Generic;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESEXO.
	/// </summary>
    public class ESEXO : DomainObject
    {
	    	
	    private System.String  _COD_SEXO = String.Empty;
        	
	    private System.String  _NOM_SEXO = String.Empty;
        	
        
	    public ESEXO() : base()
	    {
	    }
	    
		public ESEXO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODSEXO
	    {
		    get { return _COD_SEXO; }
		    set { _COD_SEXO = value; }
	    }
	    
	    	
	    public System.String NOMSEXO
	    {
		    get { return _NOM_SEXO; }
		    set { _NOM_SEXO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLSEXO();
        }

        #endregion	    
    }
}