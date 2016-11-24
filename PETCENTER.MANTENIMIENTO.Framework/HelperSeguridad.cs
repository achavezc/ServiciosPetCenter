using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCENTER.MANTENIMIENTO.Framework
{
    public class HelperSeguridad
    {
        public static string GenerarContrasenia()
        {
            string generado = string.Empty;

            Random r = new Random((int)DateTime.Now.Ticks);

            while (generado.Length < 8)
            {
                int numero = r.Next(48, 57);
                int mayus = r.Next(65, 90);
                int minus = r.Next(97, 122);

                if (numero % 2 == 0)
                    generado += string.Format("{0}", (char)numero);

                if (mayus % 2 != 0)
                    generado += string.Format("{0}", (char)mayus);

                if (minus % 2 != 0)
                    generado += string.Format("{0}", (char)minus);
            }
            return generado;
        }

    }
}
