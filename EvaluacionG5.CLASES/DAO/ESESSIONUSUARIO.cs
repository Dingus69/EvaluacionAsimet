using System;
using EvaluacionG5.CLASES.DAL;

namespace EvaluacionG5.CLASES.DAO
{
    public class ESESSIONUSUARIO : DomainObject
    {

        private System.Int64 _rut_usuario = 0;

        private System.String _nombres = String.Empty;

        private System.String _apellidos = String.Empty;

        private System.String _email = String.Empty;

        private System.String _clave_sence = String.Empty;

        private System.Boolean _EsSuperAdministrador = false;

        private System.Boolean _EsAdministrador = false;

        private System.Boolean _EsGestion = false;

        private System.Boolean _EsEvaluador = false;

        private System.Boolean _EsVisador = false;

        private System.Int64 _rut_empresa = 0;



        public ESESSIONUSUARIO()
            : base()
        {
        }

        public ESESSIONUSUARIO(long id)
            : base(id)
        {
        }

        #region Properties

        public System.Int64 RutUsuario
        {
            get { return _rut_usuario; }
            set { _rut_usuario = value; }
        }

        public System.String Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public System.String Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public System.String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public System.String ClaveSence
        {
            get { return _clave_sence; }
            set { _clave_sence = value; }
        }

        public System.Boolean EsAdministrador
        {
            get { return _EsAdministrador; }
            set { _EsAdministrador = value; }
        }

        public System.Boolean EsGestion
        {
            get { return _EsGestion; }
            set { _EsGestion = value; }
        }

        public bool EsEvaluador
        {
            get
            {
                return _EsEvaluador;
            }

            set
            {
                _EsEvaluador = value;
            }
        }

        public bool EsVisador
        {
            get
            {
                return _EsVisador;
            }

            set
            {
                _EsVisador = value;
            }
        }

        public bool EsSuperAdministrador
        {
            get
            {
                return _EsSuperAdministrador;
            }

            set
            {
                _EsSuperAdministrador = value;
            }
        }

        public long RutEmpresa
        {
            get
            {
                return _rut_empresa;
            }

            set
            {
                _rut_empresa = value;
            }
        }
        #endregion

        #region Methods

        protected override DLBase GetMapper()
        {
            return new DLSESSIONUSUARIO();
        }

        #endregion

    }
}
