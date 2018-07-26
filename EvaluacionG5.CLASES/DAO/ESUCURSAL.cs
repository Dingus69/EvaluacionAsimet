
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for ESUCURSAL.
	/// </summary>
    [Serializable()]
    public class ESUCURSAL : DomainObject
    {
	    	
	    private System.String  _COD_SUCURSAL = String.Empty;
        	
	    private System.String  _NOMBRE_SUCURSAL = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public ESUCURSAL() : base()
	    {
	    }
	    
		public ESUCURSAL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODSUCURSAL
	    {
		    get { return _COD_SUCURSAL; }
		    set { _COD_SUCURSAL = value; }
	    }
	    
	    	
	    public System.String NOMBRESUCURSAL
	    {
		    get { return _NOMBRE_SUCURSAL; }
		    set { _NOMBRE_SUCURSAL = value; }
	    }

        public long RUT_EMPRESA
        {
            get
            {
                return _RUT_EMPRESA;
            }

            set
            {
                _RUT_EMPRESA = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSUCURSAL();
        }

        #endregion	    
    }
}