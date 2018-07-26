
using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
	/// <summary>
	/// Summary description for EPREGUNTASECCIONEMPLEADO.
	/// </summary>
    [Serializable()]
    public class EPREGUNTASECCIONEMPLEADO : DomainObject
    {
	    	
	    private System.Decimal  _COD_PREGUNTA_EMPLEADO = 0;
        	
	    private System.Decimal  _COD_SECCION_INSTRUMENTO = 0;
        	
	    private System.Double  _PONDERACION = 0.0;
        	
	    private System.Double  _RESULTADO = 0.0;

        private System.String _COMENTARIO = String.Empty;


        public EPREGUNTASECCIONEMPLEADO() : base()
	    {
	    }
	    
		public EPREGUNTASECCIONEMPLEADO(long id) : base(id)
		{
		}
        
        #region Properties    	
	    	
	    public System.Decimal CODPREGUNTAEMPLEADO
	    {
		    get { return _COD_PREGUNTA_EMPLEADO; }
		    set { _COD_PREGUNTA_EMPLEADO = value; }
	    }
	    
	    	
	    public System.Decimal CODSECCIONINSTRUMENTO
	    {
		    get { return _COD_SECCION_INSTRUMENTO; }
		    set { _COD_SECCION_INSTRUMENTO = value; }
	    }
	    
	    	
	    public System.Double PONDERACION
	    {
		    get { return _PONDERACION; }
		    set { _PONDERACION = value; }
	    }
	    
	    	
	    public System.Double RESULTADO
	    {
		    get { return _RESULTADO; }
		    set { _RESULTADO = value; }
	    }

        public string COMENTARIO
        {
            get
            {
                return _COMENTARIO;
            }

            set
            {
                _COMENTARIO = value;
            }
        }


        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLPREGUNTASECCIONEMPLEADO();
        }

        #endregion	    
    }
}