
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EGRADO.
	/// </summary>
    [Serializable()]
    public class EGRADO : DomainObject
    {
	    	
	    private System.Int16  _COD_GRADO = 0;
        	
	    private System.String  _NOMBRE_GRADO = String.Empty;
        	
        
	    public EGRADO() : base()
	    {
	    }
	    
		public EGRADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODGRADO
	    {
		    get { return _COD_GRADO; }
		    set { _COD_GRADO = value; }
	    }
	    
	    	
	    public System.String NOMBREGRADO
	    {
		    get { return _NOMBRE_GRADO; }
		    set { _NOMBRE_GRADO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLGRADO();
        }

        #endregion	    
    }
}