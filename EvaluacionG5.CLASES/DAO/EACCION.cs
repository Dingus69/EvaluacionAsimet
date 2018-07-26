
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EACCION.
	/// </summary>
    [Serializable()]
    public class EACCION : DomainObject
    {
	    	
	    private System.Int16  _COD_ACCION = 0;
        	
	    private System.String  _NOMBRE_ACCION = String.Empty;
        	
        
	    public EACCION() : base()
	    {
	    }
	    
		public EACCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODACCION
	    {
		    get { return _COD_ACCION; }
		    set { _COD_ACCION = value; }
	    }
	    
	    	
	    public System.String NOMBREACCION
	    {
		    get { return _NOMBRE_ACCION; }
		    set { _NOMBRE_ACCION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLACCION();
        }

        #endregion	    
    }
}