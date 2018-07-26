using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvaluacionG5.COMMON
{
    [Serializable()]
    public class CCryptografia
    {
        public static string Encriptar(string Texto)
        {
            EncryptionSoleduc.EncryptionSoleduc Encript = new EncryptionSoleduc.EncryptionSoleduc();
            string Clave = Encript.EncryptINI(Texto);
            return Clave;
        }

        public static String Desencriptar(string Texto)
        {
            EncryptionSoleduc.EncryptionSoleduc Encript = new EncryptionSoleduc.EncryptionSoleduc();
            string Clave = Encript.DecryptINI(Texto);
            return Clave;
        }
    }
}
