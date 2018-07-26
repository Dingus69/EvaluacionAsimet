
using System;
using EvaluacionG5.CLASES.DAL;
using EvaluacionG5.COMMON;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EUSUARIO.
	/// </summary>
    [Serializable()]
    public class EUSUARIO : DomainObject
    {
	    	
	    private System.Int64  _RUT_USUARIO = 0;
        	
	    private System.String  _NOMBRE_USUARIO = String.Empty;
        	
	    private System.String  _APELLIDO_PATERNO = String.Empty;
        	
	    private System.String  _APELLIDO_MATERNO = String.Empty;
        	
	    private System.String  _PASSWORD = String.Empty;
        	
	    private System.String  _EMAIL = String.Empty;
        	
	    private System.Boolean  _FLAG_ACTIVO = false;
        	
        
	    public EUSUARIO() : base()
	    {
	    }
	    
		public EUSUARIO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Int64 RUTUSUARIO
	    {
		    get { return _RUT_USUARIO; }
		    set { _RUT_USUARIO = value; }
        }
        public System.String RUTCOMPLETO
        {
            get { return Utiles.ConvertToString(_RUT_USUARIO) + '-' + Utiles.digito_verificador(_RUT_USUARIO); }
        }


        public System.String NOMBREUSUARIO
	    {
		    get { return _NOMBRE_USUARIO; }
		    set { _NOMBRE_USUARIO = value; }
	    }
	    
	    	
	    public System.String APELLIDOPATERNO
	    {
		    get { return _APELLIDO_PATERNO; }
		    set { _APELLIDO_PATERNO = value; }
	    }
	    
	    	
	    public System.String APELLIDOMATERNO
	    {
		    get { return _APELLIDO_MATERNO; }
		    set { _APELLIDO_MATERNO = value; }
        }

        public System.String NOMBRECOMPLETO
        {
            get { return _NOMBRE_USUARIO + ' ' + _APELLIDO_PATERNO + ' ' + _APELLIDO_MATERNO; }
        }


        public System.String PASSWORD
	    {
		    get { return _PASSWORD; }
		    set { _PASSWORD = value; }
	    }
	    
	    	
	    public System.String EMAIL
	    {
		    get { return _EMAIL; }
		    set { _EMAIL = value; }
	    }
	    
	    	
	    public System.Boolean FLAGACTIVO
	    {
		    get { return _FLAG_ACTIVO; }
		    set { _FLAG_ACTIVO = value; }
	    }
	    
	    
	    #endregion
	    
        #region Methods
        
        protected override DLBase GetMapper()
        {
            return new DLUSUARIO();
        }

        #endregion	    
    }
}