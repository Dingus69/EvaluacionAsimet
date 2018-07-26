
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EBITACORA.
	/// </summary>
    [Serializable()]
    public class EBITACORA : DomainObject
    {
	    	
	    private System.Decimal  _CODBITACORA = 0;
        	
	    private System.Int16  _COD_ACCION = 0;
        	
	    private System.Int64  _RUT_USUARIO = 0;
        	
	    private System.DateTime  _FECHA = System.DateTime.Now;
        	
	    private System.String  _DESCRIPCION = String.Empty;
        	
        
	    public EBITACORA() : base()
	    {
	    }
	    
		public EBITACORA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODBITACORA
	    {
		    get { return _CODBITACORA; }
		    set { _CODBITACORA = value; }
	    }
	    
	    	
	    public System.Int16 CODACCION
	    {
		    get { return _COD_ACCION; }
		    set { _COD_ACCION = value; }
	    }
	    
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
	    }
	    
	    	
	    public System.DateTime FECHA
	    {
		    get { return _FECHA; }
		    set { _FECHA = value; }
	    }
	    
	    	
	    public System.String DESCRIPCION
	    {
		    get { return _DESCRIPCION; }
		    set { _DESCRIPCION = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLBITACORA();
        }

        #endregion	    
    }
}