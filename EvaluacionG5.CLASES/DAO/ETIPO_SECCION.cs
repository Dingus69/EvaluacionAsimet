
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ETIPOSECCION.
	/// </summary>
    [Serializable()]
    public class ETIPOSECCION : DomainObject
    {
	    	
	    private System.Int16  _COD_TIPO_SECCION = 0;
        	
	    private System.String  _NOMBRE_TIPO_SECCION = String.Empty;
        	
        
	    public ETIPOSECCION() : base()
	    {
	    }
	    
		public ETIPOSECCION(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int16 CODTIPOSECCION
	    {
		    get { return _COD_TIPO_SECCION; }
		    set { _COD_TIPO_SECCION = value; }
	    }
	    
	    	
	    public System.String NOMBRETIPOSECCION
	    {
		    get { return _NOMBRE_TIPO_SECCION; }
		    set { _NOMBRE_TIPO_SECCION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLTIPOSECCION();
        }

        #endregion	    
    }
}