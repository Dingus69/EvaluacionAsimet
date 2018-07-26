
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EROL.
	/// </summary>
    [Serializable()]
    public class EROL : DomainObject
    {
	    	
	    private System.String  _COD_ROL = String.Empty;
        	
	    private System.String  _NOMBRE_ROL = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public EROL() : base()
	    {
	    }
	    
		public EROL(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODROL
	    {
		    get { return _COD_ROL; }
		    set { _COD_ROL = value; }
	    }
	    
	    	
	    public System.String NOMBREROL
	    {
		    get { return _NOMBRE_ROL; }
		    set { _NOMBRE_ROL = value; }
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
            return new DLROL();
        }

        #endregion	    
    }
}