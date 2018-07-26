
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOEVALUACION.
	/// </summary>
    [Serializable()]
    public class ETIPOEVALUACION : DomainObject
    {
	    	
	    private System.Int16  _COD_TIPO_EVAL = 0;
        	
	    private System.String  _NOM_TIPO_EVAL = String.Empty;
        	
        
	    public ETIPOEVALUACION() : base()
	    {
	    }
	    
		public ETIPOEVALUACION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODTIPOEVAL
	    {
		    get { return _COD_TIPO_EVAL; }
		    set { _COD_TIPO_EVAL = value; }
	    }
	    
	    	
	    public System.String NOMTIPOEVAL
	    {
		    get { return _NOM_TIPO_EVAL; }
		    set { _NOM_TIPO_EVAL = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLTIPOEVALUACION();
        }

        #endregion	    
    }
}