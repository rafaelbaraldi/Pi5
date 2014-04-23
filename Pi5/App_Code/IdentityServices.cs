using Pi5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pi5.App_Code
{
    public class IdentityServices
    {
        public static void SetLoggedCliente(usuario usuario)
        {
            HttpContext.Current.Session["LoggedCliente"] = new usuario
            {
                id = usuario.id,
                endereco = usuario.endereco,
                email = usuario.email,
                nome = usuario.nome,
                telefone = usuario.telefone,
                senha = usuario.senha
            };
        }

        public static void SetLoggedCliente()
        {
            HttpContext.Current.Session["LoggedCliente"] = null;
        }

        public static usuario GetLoggedCliente()
        {
            return (usuario)HttpContext.Current.Session["LoggedCliente"];
        }
    }
}