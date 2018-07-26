

using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EHOJADEVIDA.
	/// </summary>
    public class EHOJADEVIDA : DomainObject
    {
	    	
	    private System.Decimal  _COD_HOJA_DE_VIDA = 0;
        	
	    private System.Int64  _RUT_EMPLEADO = 0;
        	
	    private System.String  _OBSERVACION = String.Empty;
        	
	    private System.DateTime  _FECHA_INGRESO = DateTime.Now;
        	
	    private System.Int64  _RUT_USUARIO = 0;
        	
        
	    public EHOJADEVIDA() : base()
	    {
	    }
	    
		public EHOJADEVIDA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODHOJADEVIDA
	    {
		    get { return _COD_HOJA_DE_VIDA; }
		    set { _COD_HOJA_DE_VIDA = value; }
	    }
	    
	    	
	    public System.Int64 RUTEMPLEADO
	    {
		    get { return _RUT_EMPLEADO; }
		    set { _RUT_EMPLEADO = value; }
	    }
	    
	    	
	    public System.String OBSERVACION
	    {
		    get { return _OBSERVACION; }
		    set { _OBSERVACION = value; }
	    }
	    
	    	
	    public System.DateTime FECHAINGRESO
	    {
		    get { return _FECHA_INGRESO; }
		    set { _FECHA_INGRESO = value; }
	    }
	    
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLHOJADEVIDA();
        }

        #endregion	    
    }
}