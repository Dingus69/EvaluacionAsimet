
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EAREA.
	/// </summary>
    [Serializable()]
    public class EAREA : DomainObject
    {
	    	
	    private System.String  _COD_AREA = String.Empty;
        	
	    private System.String  _NOMBRE_AREA = String.Empty;

        private System.Int64 _RUT_EMPRESA = 0;


        public EAREA() : base()
	    {
	    }
	    
		public EAREA(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.String CODAREA
	    {
		    get { return _COD_AREA; }
		    set { _COD_AREA = value; }
	    }
	    
	    	
	    public System.String NOMBREAREA
	    {
		    get { return _NOMBRE_AREA; }
		    set { _NOMBRE_AREA = value; }
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
            return new DLAREA();
        }

        #endregion	    
    }
}