using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objCapDato = new CD_Cliente();

        public int Add(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if(string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "Por favor, ingresa un Nombre";
            }else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "Por favor, ingresa tus Apellidos";
            }else if(string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "Por favor, ingresa tu email";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                obj.Clave = CN_Recursos.ConvertToSha256(obj.Clave);
                return objCapDato.Add(obj, out Mensaje);
            }
            else
            {
                return 0;
            }

        }

        public List<Cliente> Fetch()
        {
            return objCapDato.Fetch();
        }

        public bool ChangePassword(int idCliente, string newPass, out string Mensaje)
        {
            return objCapDato.ChangePassword(idCliente, newPass, out Mensaje);  
        }

        public bool RestorePass(int idCliente, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string newPass = CN_Recursos.GenerarClave();
            bool result = objCapDato.RestorePassword(idCliente, CN_Recursos.ConvertToSha256(newPass), out Mensaje);

            if (result)
            {
                string asunto = "Contraseña Reestablecidad";
                string mensaje_mail = "<h3>Tu cuenta fue restablecida correctamente</h3></br><p>Su nueva contraseña para acceder es !clave!</p>";
                mensaje_mail = mensaje_mail.Replace("!clave!", newPass);


                bool rpta = CN_Recursos.SendMail(correo, asunto, mensaje_mail);

                if (rpta)
                {
                    return true;
                }
                else
                {
                    Mensaje = "No se pudo enviar el email";
                    return false;
                }
            }
            else
            {
                Mensaje = "No se pudo reestablecer la contraseña";
                return false;
            }
        }


    }
}
